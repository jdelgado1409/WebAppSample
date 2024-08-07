# ASP.NET Official image as base
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
# .NET official image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebAppSample.csproj", "./"]
RUN dotnet restore "./WebAppSample.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "WebAppSample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAppSample.csproj" -c Release -o /app/publish

# Image to run app
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAppSample.dll"]