FROM microsoft/dotnet:3.1-sdk AS build
WORKDIR /app

COPY . .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet DojoCGDF.Api.dll