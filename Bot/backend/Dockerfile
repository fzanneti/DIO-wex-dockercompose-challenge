# Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY JarbasBot.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o /out

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .

# Porta dinâmica para Railway
ENV PORT=8080
ENV ASPNETCORE_URLS=http://+:${PORT}
EXPOSE ${PORT}

ENTRYPOINT ["dotnet", "JarbasBot.dll"]