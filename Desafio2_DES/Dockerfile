FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:10.0-alpine AS build

COPY . /source

WORKDIR /source

ARG TARGETARCH

RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages \
    dotnet publish Desafio2_DES/Desafio2_DES.csproj -a ${TARGETARCH/amd64/x64} --use-current-runtime --self-contained false -o /app

FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine AS final

RUN apk add --no-cache icu-libs

WORKDIR /app

ENV ASPNETCORE_HTTP_PORTS=8080
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

COPY --from=build /app .

USER $APP_UID

ENTRYPOINT ["dotnet", "Desafio2_DES.dll"]
