# Etapa 1: Imagem base para compilar a aplicação
FROM mcr.microsoft.com / dotnet / sdk:6.0 AS build
WORKDIR /app

# Copiar arquivos do projeto e restaurar dependências
COPY *.csproj ./
RUN dotnet restore

# Copiar todo o código para o contêiner
COPY . ./

# Compilar o projeto
RUN dotnet publish -c Release -o /publish

# Etapa 2: Imagem base para rodar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app

# Copiar os arquivos compilados para o contêiner
COPY --from=build /publish .

# Expor a porta onde a API estará escutando
EXPOSE 80
EXPOSE 443

# Configurar o ponto de entrada para executar a aplicação
ENTRYPOINT ["dotnet", "NomeDaSuaAPI.dll"]
