FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["NetACS.CWMP/NetACS.CWMP.csproj", "NetACS.CWMP/"]
RUN dotnet restore "NetACS.CWMP/NetACS.CWMP.csproj"
COPY . .
WORKDIR "/src/NetACS.CWMP"
RUN dotnet build "NetACS.CWMP.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "NetACS.CWMP.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "NetACS.CWMP.dll"]