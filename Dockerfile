#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk AS build
ENV projfolder=Habilitar_API
ENV projfile=Habilitar_API.csproj
WORKDIR /src
COPY ["src/$projfolder/$projfile", ""]
RUN dotnet restore "$projfile"
COPY src/$projfolder .
RUN dotnet build "$projfile" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "$projfile" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Habilitar_API.dll"]
