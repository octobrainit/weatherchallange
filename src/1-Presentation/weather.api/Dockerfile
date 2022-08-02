
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/1-Presentation/weather.api/weather.api.csproj", "src/1-Presentation/weather.api/"]
RUN dotnet restore "src/1-Presentation/weather.api/weather.api.csproj"
COPY . .
WORKDIR "/src/src/1-Presentation/weather.api"
RUN dotnet build "weather.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "weather.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "weather.api.dll"]