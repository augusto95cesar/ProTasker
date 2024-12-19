FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src

# Corrigir o caminho de cópia para o .csproj
COPY ProTasker.API.csproj ./

# Restaura as dependências
RUN dotnet restore "ProTasker.API.csproj"

# Copia o restante dos arquivos
COPY . .

# Construa o projeto
RUN dotnet build "ProTasker.API.csproj" -c Release -o /app/build

# Etapa de publicação
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM build AS publish
RUN dotnet publish "ProTasker.API.csproj" -c Release -o /app/publish

FROM base AS final
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "ProTasker.API.dll"]
