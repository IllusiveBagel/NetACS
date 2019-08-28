FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["NetACS.API/NetACS.API.csproj", "NetACS.API/"]
RUN dotnet restore "NetACS.API/NetACS.API.csproj"
COPY . .
WORKDIR "/src/NetACS.API"
RUN dotnet build "NetACS.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "NetACS.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "NetACS.API.dll"]