#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Habilitar_API/Habilitar_API.csproj", "Habilitar_API/"]
RUN dotnet restore "Habilitar_API/Habilitar_API.csproj"
COPY . .
WORKDIR "/src/Habilitar_API"
RUN dotnet build "Habilitar_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Habilitar_API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Habilitar_API.dll"]