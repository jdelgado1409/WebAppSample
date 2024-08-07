#Usar imagen base
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
# Establece el directorio de trabajo en el contenedor
WORKDIR /app
# Copia el archivo de proyecto y restaura las dependencias
COPY *.csproj ./
RUN dotnet restore
# Copia el resto del código fuente y construye la aplicación
COPY . ./
RUN dotnet publish -c Release -o out
# Usa una imagen base oficial del Runtime de .NET para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:6.0

# Establece el directorio de trabajo en el contenedor
WORKDIR /app
# Copia los archivos construidos desde la etapa de construcción
COPY --from=build /app/out .
# Expone el puerto en el que la aplicación escucha
EXPOSE 80
# Define el comando para ejecutar la aplicación
ENTRYPOINT ["dotnet", "WebAppSample.dll"]