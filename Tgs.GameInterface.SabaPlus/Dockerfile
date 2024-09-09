#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM hub.lumigame.com/base/dotnet/core/aspnet:8.0-alpine-24h1.1 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
EXPOSE 9090

FROM hub.lumigame.com/base/dotnet/core/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["nuget.config", "."]
COPY ["Tgs.GameInterface.SabaPlus/Tgs.GameInterface.SabaPlus.csproj", "Tgs.GameInterface.SabaPlus/"]
COPY ["Tgs.GameInterface.SabaPlus.Core/Tgs.GameInterface.SabaPlus.Core.csproj", "Tgs.GameInterface.SabaPlus.Core/"]
RUN dotnet restore "./Tgs.GameInterface.SabaPlus/./Tgs.GameInterface.SabaPlus.csproj"
COPY . .
WORKDIR "/src/Tgs.GameInterface.SabaPlus"
RUN dotnet build "./Tgs.GameInterface.SabaPlus.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Tgs.GameInterface.SabaPlus.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tgs.GameInterface.SabaPlus.dll"]