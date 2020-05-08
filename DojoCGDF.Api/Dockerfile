FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

COPY . .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet DojoCGDF.Api.dll