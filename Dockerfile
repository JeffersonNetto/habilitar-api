#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Habilitar.Api/Habilitar.Api.csproj", "src/Habilitar.Api/"]
COPY ["src/Habilitar.Core/Habilitar.Core.csproj", "src/Habilitar.Core/"]
COPY ["src/Habilitar.Infra/Habilitar.Infra.csproj", "src/Habilitar.Infra/"]
RUN dotnet restore "src/Habilitar.Api/Habilitar.Api.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "src/Habilitar.Api/Habilitar.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "src/Habilitar.Api/Habilitar.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Habilitar.Api.dll"]