# Use the official ASP.NET Core runtime as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
AS base
WORKDIR /app
EXPOSE 80

# Use the SDK image for building the app
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy the .csproj file and restore dependencies
COPY ["WebAppSample/WebAppSample.csproj", "WebAppSample/"]
RUN dotnet restore "WebAppSample/WebAppSample.csproj"

# Copy the rest of the application and build it
COPY . .
WORKDIR "/src/WebAppSample"
RUN dotnet build "WebAppSample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAppSample.csproj" -c Release -o /app/publish

# Use the runtime image again and copy the build output
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAppSample.dll"]