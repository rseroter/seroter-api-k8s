FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY seroter-api-k8s/seroter-api-k8s.csproj seroter-api-k8s/
RUN dotnet restore seroter-api-k8s/seroter-api-k8s.csproj
COPY . .
WORKDIR /src/seroter-api-k8s
RUN dotnet build seroter-api-k8s.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish seroter-api-k8s.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "seroter-api-k8s.dll"]
