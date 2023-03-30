FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:80;

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /dist
COPY ["src/Upd8.Api/Upd8.Api.csproj", "Upd8.Api/"]
COPY ["src/Upd8.Infra/Upd8.Infra.csproj", "Upd8.Infra/"]
COPY ["src/Upd8.Domain/Upd8.Domain.csproj", "Upd8.Domain/"]
COPY ["src/Upd8.Application/Upd8.Application.csproj", "Upd8.Application/"]
RUN dotnet restore "Upd8.Api/Upd8.Api.csproj"
COPY . .
WORKDIR "/dist/src/Upd8.Api"
RUN dotnet build "Upd8.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Upd8.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Upd8.Api.dll"]