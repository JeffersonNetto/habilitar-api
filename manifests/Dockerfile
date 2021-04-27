FROM mcr.microsoft.com/dotnet/sdk AS build
WORKDIR /app
COPY *.sln .
COPY src/Habilitar_API/*.csproj ./src/Habilitar_API/
COPY test/Habilitar_API.Tests/*.csproj ./test/Habilitar_API.Tests/
RUN dotnet restore

# copy full solution over
COPY . .
RUN dotnet build

FROM build AS testrunner
WORKDIR /app/test/Habilitar_API.Tests
CMD ["dotnet", "test", "--logger:trx"]

# run the unit tests
FROM build AS test
WORKDIR /app/test/Habilitar_API.Tests
RUN dotnet test --logger:trx

# run the component tests
FROM build AS componenttestrunner
WORKDIR /app/test/Habilitar_API.Tests
CMD ["dotnet", "test", "--logger:trx"]

# publish the API
FROM build AS publish
WORKDIR /app/src/Habilitar_API
RUN dotnet publish -c Release -o out

# run the api
FROM mcr.microsoft.com/dotnet/aspnet AS runtime
WORKDIR /app
COPY --from=publish /app/src/Habilitar_API/out ./
EXPOSE 80
ENTRYPOINT ["dotnet", "Habilitar_API.dll"]