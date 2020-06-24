#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/BaseApplication.ClientApplication/BaseApplication.ClientApplication.csproj", "src/BaseApplication.ClientApplication/"]
RUN dotnet restore "src/BaseApplication.ClientApplication/BaseApplication.ClientApplication.csproj"
COPY . .
WORKDIR "/src/src/BaseApplication.ClientApplication"
RUN dotnet build "BaseApplication.ClientApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BaseApplication.ClientApplication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BaseApplication.ClientApplication.dll"]