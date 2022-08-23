FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["worker.common/worker.common.csproj", "worker.common/"]
RUN dotnet restore "worker.common/worker.common.csproj"
COPY . .
WORKDIR "/src/worker.common"
RUN dotnet build "worker.common.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "worker.common.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "worker.common.dll"]
