FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MoviesNsi.Api/MoviesNsi.Api.csproj", "MoviesNsi.Api/"]
COPY ["MoviesNsi.Application/MoviesNsi.Application.csproj", "MoviesNsi.Application/"]
COPY ["MoviesNsi.Domain/MoviesNsi.Domain.csproj", "MoviesNsi.Domain/"]
COPY ["MoviesNsi.Infrastructure/MoviesNsi.Infrastructure.csproj", "MoviesNsi.Infrastructure/"]
RUN dotnet restore "MoviesNsi.Api/MoviesNsi.Api.csproj"
COPY . .
WORKDIR "/src/MoviesNsi.Api"
RUN dotnet build "MoviesNsi.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MoviesNsi.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MoviesNsi.Api.dll"]
