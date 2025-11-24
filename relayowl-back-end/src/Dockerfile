FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY Relayowl.Api/Relayowl.Api.csproj Relayowl.Api/
COPY Relayowl.Infrastructure/Relayowl.Infrastructure.csproj Relayowl.Infrastructure/
COPY Relayowl.Core/Relayowl.Core.csproj Relayowl.Core/

RUN dotnet restore Relayowl.Api/Relayowl.Api.csproj

COPY Relayowl.Api/ Relayowl.Api/
COPY Relayowl.Infrastructure/ Relayowl.Infrastructure/
COPY Relayowl.Core/ Relayowl.Core/

RUN dotnet publish Relayowl.Api/Relayowl.Api.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 80
ENV DOTNET_ENVIRONMENT=Production
ENTRYPOINT ["dotnet", "Relayowl.Api.dll"]