#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["BaseApplication.ApiApplication/BaseApplication.ApiApplication.csproj", "BaseApplication.ApiApplication/"]
RUN dotnet restore "BaseApplication.ApiApplication/BaseApplication.ApiApplication.csproj"
COPY . .
WORKDIR "/src/BaseApplication.ApiApplication"
RUN dotnet build "BaseApplication.ApiApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BaseApplication.ApiApplication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BaseApplication.ApiApplication.dll"]