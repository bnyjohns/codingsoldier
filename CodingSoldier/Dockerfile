#aspnet core build image
FROM microsoft/aspnetcore-build:2.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out


#aspnet core runtime image
FROM microsoft/aspnetcore:2.0
WORKDIR /app

EXPOSE 2350

#copying output of "build-env" from "/app/out" to "."
COPY --from=build-env /app/out .
CMD ["dotnet", "/app/CodingSoldier.dll"]