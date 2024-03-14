FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Calculator/AdditionService/AdditionService.csproj", "Calculator/AdditionService/"]
COPY ["Calculator/Monitoring/Monitoring.csproj", "Calculator/Monitoring/"]
RUN dotnet restore "./Calculator/AdditionService/AdditionService.csproj"
COPY . .
WORKDIR "/src/Calculator/AdditionService"
RUN dotnet build "./AdditionService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AdditionService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdditionService.dll"]
