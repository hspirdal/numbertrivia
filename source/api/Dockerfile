FROM microsoft/aspnetcore-build:2.0 AS build-env

WORKDIR /src
COPY api api

WORKDIR /src/api
RUN dotnet publish -c Release -o /app/out

# Build runtime image
FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY --from=build-env /app/out .

ENV ASPNETCORE_URLS http://+:8081
EXPOSE 8081

ENTRYPOINT ["dotnet", "api.dll"]