// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

const storageKey = "lumexui.theme";

function initialize() {
    const initialTheme = get();

    applyTheme(initialTheme);

    // Automatically react to system theme changes if "system" is selected
    const mediaQuery = window.matchMedia("(prefers-color-scheme: dark)");
    mediaQuery.addEventListener("change", () => {
        if (get() === "system") {
            applyTheme("system");
        }
    });

    return initialTheme;
}

function get() {
    return localStorage.getItem(storageKey) || "system";
}

function set(theme) {
    localStorage.setItem(storageKey, theme);
    applyTheme(theme);
}

function toggle() {
    const current = get();
    let next;

    if (current === "dark") next = "light";
    else if (current === "light") next = "dark";
    else next = prefersDark() ? "light" : "dark";

    set(next);
    return next;
}

function prefersDark() {
    return window.matchMedia("(prefers-color-scheme: dark)").matches;
}

function applyTheme(theme) {
    const root = document.documentElement;
    root.classList.remove("light", "dark");

    let resolved = theme;
    if (theme === "system") {
        resolved = prefersDark() ? "dark" : "light";
    }

    root.classList.add(resolved);
    root.style.colorScheme = resolved;
}

export const theme = {
    initialize,
    get,
    set,
    toggle,
    prefersDark
};