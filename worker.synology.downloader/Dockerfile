FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["worker.synology.downloader/worker.synology.downloader.csproj", "worker.synology.downloader/"]
RUN dotnet restore "worker.synology.downloader/worker.synology.downloader.csproj"
COPY . .
WORKDIR "/src/worker.synology.downloader"
RUN dotnet build "worker.synology.downloader.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "worker.synology.downloader.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "worker.synology.downloader.dll"]
