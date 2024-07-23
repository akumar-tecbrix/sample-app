# Use the official ASP.NET Core runtime as a base image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Use the official SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SampleDockerApp.csproj", "."]
RUN dotnet restore "SampleDockerApp.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "SampleDockerApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SampleDockerApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY appsettings.json .
ENTRYPOINT ["dotnet", "SampleDockerApp.dll"]
