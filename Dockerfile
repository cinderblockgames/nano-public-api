FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-env

WORKDIR /app
COPY ./ ./

WORKDIR /app/NanoPublicApi
RUN dotnet restore

WORKDIR /app/NanoPublicApi/NanoPublicApi
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/aspnet:6.0

WORKDIR /app/api
COPY --from=build-env /app/NanoPublicApi/NanoPublicApi/out .

RUN apt-get update && apt-get install -y curl

ENV ASPNETCORE_URLS=http://+:2022
ENV NODE=http://node:7076
ENV DISABLE_CORS=true
ENV EXPANDED_LIST=false

CMD [ "dotnet", "NanoPublicApi.dll" ]
