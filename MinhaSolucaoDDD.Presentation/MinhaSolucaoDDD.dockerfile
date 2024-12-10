# Usar a imagem base do SDK do .NET 8.0 para build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiar os arquivos de projeto e restaurar as dependências
COPY MinhaSolucaoDDD.Presentation/*.csproj ./MinhaSolucaoDDD.Presentation/
COPY MinhaSolucaoDDD.Application/*.csproj ./MinhaSolucaoDDD.Application/
COPY MinhaSolucaoDDD.Domain/*.csproj ./MinhaSolucaoDDD.Domain/
COPY MinhaSolucaoDDD.Infrastructure/*.csproj ./MinhaSolucaoDDD.Infrastructure/
RUN dotnet restore ./MinhaSolucaoDDD.Presentation/MinhaSolucaoDDD.Presentation.csproj

# Copiar o restante dos arquivos e construir a aplicação
COPY MinhaSolucaoDDD.Presentation/ ./MinhaSolucaoDDD.Presentation/
COPY MinhaSolucaoDDD.Application/ ./MinhaSolucaoDDD.Application/
COPY MinhaSolucaoDDD.Domain/ ./MinhaSolucaoDDD.Domain/
COPY MinhaSolucaoDDD.Infrastructure/ ./MinhaSolucaoDDD.Infrastructure/

WORKDIR /app/MinhaSolucaoDDD.Presentation

# Diagnóstico: listar arquivos antes de publicar
RUN ls -la

# Construir a aplicação
RUN dotnet publish -c Release -o out

# Usar a imagem base do runtime do .NET 8.0 para rodar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/MinhaSolucaoDDD.Presentation/out .

# Expor a porta em que a aplicação estará rodando
EXPOSE 80
EXPOSE 7207
EXPOSE 8080
EXPOSE 8081

# Definir o comando para rodar a aplicação
ENTRYPOINT ["dotnet", "MinhaSolucaoDDD.Presentation.dll"]
