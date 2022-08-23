FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["worker.mongo/worker.mongo.csproj", "worker.mongo/"]
RUN dotnet restore "worker.mongo/worker.mongo.csproj"
COPY . .
WORKDIR "/src/worker.mongo"
RUN dotnet build "worker.mongo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "worker.mongo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "worker.mongo.dll"]
