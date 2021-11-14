# Get base SDK image from Microsoft 
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Copy the .csproj file and restore any dependencies
COPY ["User.API/User.API.csproj", "User.API/"]
COPY ["User.BusinessLogic/User.BusinessLogic.csproj", "User.BusinessLogic/"]
COPY ["User.Domain/User.Domain.csproj", "User.Domain/"]
COPY ["User.Infrastructure/User.Infrastructure.csproj", "User.Infrastructure/"]
RUN dotnet restore "User.API/User.API.csproj"

# Copy the project files and build the release
COPY . ./
RUN dotnet publish "User.API/User.API.csproj" -c Release -o out

# Generate runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "User.API.dll" ]