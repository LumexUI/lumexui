import { spawn } from "node:child_process";
import fs from "node:fs";
import path from "node:path";

const [dllPath, outDir] = process.argv.slice(2);
if (!dllPath || !outDir) {
  console.error("Usage: node export-static.mjs <path-to-published-dll> <output-dir>");
  process.exit(1);
}

const origin = `http://localhost:${process.env.EXPORT_PORT ?? "5199"}`;
const publishDir = path.dirname(path.resolve(dllPath));
const out = path.resolve(outDir);

fs.rmSync(out, { recursive: true, force: true });
fs.cpSync(path.join(publishDir, "wwwroot"), out, {
  recursive: true,
  filter: (src) => !/\.(br|gz)$/.test(src),
});

const server = spawn("dotnet", [path.basename(dllPath)], {
  cwd: publishDir,
  env: { ...process.env, ASPNETCORE_URLS: origin, ASPNETCORE_ENVIRONMENT: "Production" },
  stdio: ["ignore", "inherit", "inherit"],
});

try {
  await waitForServer();
  const pages = await crawl();
  await copyMissingAssets(pages);
  await writeNotFoundPage();
  console.log(`Exported ${pages.length} pages to ${out}`);
} catch (error) {
  console.error(error.message);
  process.exitCode = 1;
} finally {
  server.kill();
}

async function waitForServer() {
  const deadline = Date.now() + 60_000;
  while (Date.now() < deadline) {
    if (server.exitCode !== null) {
      throw new Error(`The server exited with code ${server.exitCode}`);
    }
    try {
      if ((await fetch(origin)).ok) return;
    } catch {}
    await new Promise((resolve) => setTimeout(resolve, 500));
  }
  throw new Error("The server did not start within 60 seconds");
}

async function crawl() {
  const queue = ["/"];
  const seen = new Set(queue);
  const pages = [];
  const leaks = [];

  while (queue.length) {
    const route = queue.shift();
    const res = await fetch(origin + route, { redirect: "manual" });
    if (res.status !== 200) {
      if (route === "/") throw new Error(`The home page returned ${res.status}`);
      warn(`Broken link: ${route} returned ${res.status}`);
      continue;
    }

    const html = await res.text();
    if (html.includes(origin)) leaks.push(route);
    write(route === "/" ? "index.html" : path.join(route.slice(1), "index.html"), html);
    pages.push(html);

    for (const link of findLocalPaths(html).filter((p) => !isAsset(p))) {
      const normalized = link.replace(/\/+$/, "") || "/";
      if (!normalized.startsWith("/_") && !seen.has(normalized)) {
        seen.add(normalized);
        queue.push(normalized);
      }
    }
  }

  if (leaks.length) {
    throw new Error(`Pages contain absolute links to ${origin}:\n${leaks.join("\n")}`);
  }

  return pages;
}

async function copyMissingAssets(pages) {
  const assets = new Set(pages.flatMap((html) => findLocalPaths(html).filter(isAsset)));
  const missing = [];

  for (const asset of assets) {
    const file = asset.slice(1);
    if (fs.existsSync(path.join(out, file))) continue;

    const res = await fetch(origin + asset);
    if (!res.ok) {
      missing.push(`${asset} (${res.status})`);
      continue;
    }
    write(file, Buffer.from(await res.arrayBuffer()));
    console.log(`Fetched ${asset} from the server`);
  }

  if (missing.length) {
    throw new Error(`Referenced assets are missing:\n${missing.join("\n")}`);
  }
}

async function writeNotFoundPage() {
  const res = await fetch(`${origin}/__export-static-not-found__`);
  const html = await res.text();
  if (res.status === 404 && html.trim()) {
    write("404.html", html);
  } else {
    warn("The app has no not-found page, so the host's default 404 page will be used");
  }
}

function findLocalPaths(html) {
  const paths = [];
  for (const [, value] of html.matchAll(/\s(?:href|src)="([^"]*)"/g)) {
    try {
      const url = new URL(decodeEntities(value), `${origin}/`);
      if (url.origin === origin) paths.push(decodeURIComponent(url.pathname));
    } catch {}
  }
  return paths;
}

function isAsset(pathname) {
  return /\.[a-z0-9]+$/i.test(pathname);
}

function decodeEntities(value) {
  return value
    .replace(/&lt;/g, "<")
    .replace(/&gt;/g, ">")
    .replace(/&quot;/g, '"')
    .replace(/&#39;|&#x27;/g, "'")
    .replace(/&amp;/g, "&");
}

function write(file, content) {
  const target = path.join(out, file);
  fs.mkdirSync(path.dirname(target), { recursive: true });
  fs.writeFileSync(target, content);
}

function warn(message) {
  console.log(process.env.GITHUB_ACTIONS === "true" ? `::warning::${message}` : `warning: ${message}`);
}
