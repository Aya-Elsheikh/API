# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# نسخ ملفات الحل
COPY *.sln .
COPY Application/*.csproj Application/
COPY Domain/*.csproj Domain/
COPY Infrastructure/*.csproj Infrastructure/
COPY WebAPI/*.csproj WebAPI/

# Restore NuGet packages
RUN dotnet restore

# نسخ باقي الملفات
COPY . .

# Build و publish
RUN dotnet publish WebAPI/WebAPI.csproj -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

# Expose port
EXPOSE 8080

# Command to run the app
ENTRYPOINT ["dotnet", "WebAPI.dll"]
