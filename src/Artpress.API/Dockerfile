# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy solution and project files to restore dependencies separately
COPY src/Artpress.sln .
COPY src/Artpress.API/Artpress.API.csproj Artpress.API/
COPY src/Artpress.Application/Artpress.Application.csproj Artpress.Application/
COPY src/Artpress.Domain/Artpress.Domain.csproj Artpress.Domain/
COPY src/Artpress.Infrastructure/Artpress.Infrastructure.csproj Artpress.Infrastructure/
COPY src/Artpress.Application.UnitTests/Artpress.Application.UnitTests.csproj Artpress.Application.UnitTests/
COPY src/Artpress.Domain.UnitTests/Artpress.Domain.UnitTests.csproj Artpress.Domain.UnitTests/

# Restore dependencies
RUN dotnet restore Artpress.sln

# Copy the rest of the source code
COPY src/. .

# Publish the application
WORKDIR /src/Artpress.API
RUN dotnet publish Artpress.API.csproj -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Stage 2: Create the final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Copy the published output from the build stage
COPY --from=build /app/publish .

# Set the entrypoint for the container
ENTRYPOINT ["dotnet", "Artpress.API.dll"]
