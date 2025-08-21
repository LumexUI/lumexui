# -----------------------------
# Stage 1: build/publish
# -----------------------------
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# Install Node.js v22 (LTS current)
RUN apt-get update && apt-get install -y curl \
    && curl -fsSL https://deb.nodesource.com/setup_22.x | bash - \
    && apt-get install -y nodejs \
    && apt-get clean && rm -rf /var/lib/apt/lists/*

WORKDIR /src

COPY . .
RUN dotnet publish ./docs/LumexUI.Docs -c Release -o app

# -----------------------------
# Stage 2: runtime
# -----------------------------
FROM mcr.microsoft.com/dotnet/aspnet:9.0
COPY --from=build /src/app .

EXPOSE 8080
ENTRYPOINT ["dotnet","LumexUI.Docs.dll"]