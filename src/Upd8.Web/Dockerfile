FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:80;

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /dist
COPY ["src/Upd8.Web/Upd8.Web.csproj", "Upd8.Web/"]
RUN dotnet restore "Upd8.Web/Upd8.Web.csproj"
COPY . .
WORKDIR "/dist/src/Upd8.Web"
RUN dotnet build "Upd8.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Upd8.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Upd8.Web.dll"]