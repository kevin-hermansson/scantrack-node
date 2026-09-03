# Stage 1: Bygg
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Kopiera projektfilen först för bättre cache
COPY ScanTrackNode/ScanTrackNode.csproj ScanTrackNode/
RUN dotnet restore ScanTrackNode/ScanTrackNode.csproj

# Kopiera resten av projektet
COPY ScanTrackNode/ ScanTrackNode/

# Kopiera datafilen
COPY data/ data/

# Publicera appen
RUN dotnet publish ScanTrackNode/ScanTrackNode.csproj -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Kopiera publicerad app från build-steget
COPY --from=build /app/publish .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "ScanTrackNode.dll"]