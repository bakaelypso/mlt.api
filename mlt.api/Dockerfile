# Build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /source
COPY . .
RUN dotnet restore "mlt.api/mlt.api.csproj" --disable-parallel
RUN dotnet publish "mlt.api/mlt.api.csproj" -c release -o /app --no-restore

# Serve stage
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal
ENV ASPNETCORE_URLS=http://+:3000
WORKDIR /app
COPY --from=build /app ./

EXPOSE 3000

ENTRYPOINT ["dotnet", "mlt.api.dll"]
