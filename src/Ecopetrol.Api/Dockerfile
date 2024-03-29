FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["Ecopetrol.Api/Ecopetrol.Api.API/Ecopetrol.Api.API.csproj", "Ecopetrol.Api/Ecopetrol.Api.API/"]
COPY ["Ecopetrol.Api/Ecopetrol.Api.IoC.Configuration/Ecopetrol.Api.IoC.Configuration.csproj", "Ecopetrol.Api/Ecopetrol.Api.IoC.Configuration/"]
COPY ["Ecopetrol.Api/Ecopetrol.Api.Services/Ecopetrol.Api.Services.csproj", "Ecopetrol.Api/Ecopetrol.Api.Services/"]
COPY ["Ecopetrol.Api/Ecopetrol.Api.API.Common/Ecopetrol.Api.API.Common.csproj", "Ecopetrol.Api/Ecopetrol.Api.API.Common/"]
COPY ["Ecopetrol.Api/Ecopetrol.Api.API.DataContracts/Ecopetrol.Api.API.DataContracts.csproj", "Ecopetrol.Api/Ecopetrol.Api.API.DataContracts/"]
RUN dotnet restore "Ecopetrol.Api/Ecopetrol.Api.API/Ecopetrol.Api.API.csproj"
COPY . .
WORKDIR "/src/Ecopetrol.Api/Ecopetrol.Api.API"
RUN dotnet build "Ecopetrol.Api.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Ecopetrol.Api.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Ecopetrol.Api.API.dll"]