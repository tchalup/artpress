#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Artpress.API/Artpress.API.csproj", "src/Artpress.API/"]
COPY ["src/Artpress.Application/Artpress.Application.csproj", "src/Artpress.Application/"]
COPY ["src/Artpress.Domain/Artpress.Domain.csproj", "src/Artpress.Domain/"]
COPY ["src/Artpress.Infrastructure/Artpress.Infrastructure.csproj", "src/Artpress.Infrastructure/"]
RUN dotnet restore "src/Artpress.API/Artpress.API.csproj"
COPY . .
WORKDIR "/src/src/Artpress.API"
RUN dotnet build "Artpress.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Artpress.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Artpress.API.dll"]
