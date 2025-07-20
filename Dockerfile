FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY Bot/JarbasBot/JarbasBot.csproj ./
RUN dotnet restore JarbasBot.csproj

COPY Bot/JarbasBot/. ./

RUN dotnet publish -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .

ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "JarbasBot.dll"]