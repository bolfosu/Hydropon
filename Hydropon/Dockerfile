# Use the official .NET SDK image as a build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the csproj and restore dependencies
COPY *.sln ./
COPY *.csproj ./
RUN dotnet restore

# Copy the entire project and build it
COPY . ./
RUN dotnet publish -c Release -o out

# Use the official ASP.NET runtime image as the final stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/out ./

# Copy the appsettings.json file from the root directory
COPY appsettings.json ./  # This line assumes appsettings.json is in the same directory as the Dockerfile


# Specify the command to run the application
ENTRYPOINT ["dotnet", "Hydropon.dll"]
