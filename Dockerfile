# Etapa 1: Build da aplicação
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ProTasker.API/ProTasker.API.csproj", "ProTasker.API/"]
RUN dotnet restore "ProTasker.API/ProTasker.API.csproj"
COPY . .
WORKDIR "/src/ProTasker.API"
RUN dotnet build "ProTasker.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProTasker.API.csproj" -c Release -o /app/publish

# Etapa 2: Execução da aplicação
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProTasker.API.dll"]
