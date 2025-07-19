# Etapa 1 - Build com .NET 8.0
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia o csproj e restaura
COPY JarbasBot.csproj ./
RUN dotnet restore

# Copia o restante dos arquivos
COPY . ./

# Publica
RUN dotnet publish -c Release -o /out

# Etapa 2 - Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .

ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "JarbasBot.dll"]