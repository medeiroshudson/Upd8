#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Upd8.Presentation/Upd8.Api/Upd8.Api.csproj", "Upd8.Presentation/Upd8.Api/"]
COPY ["Upd8.Infra/Upd8.Infra.csproj", "Upd8.Infra/"]
COPY ["Upd8.Domain/Upd8.Domain.csproj", "Upd8.Domain/"]
COPY ["Upd8.Application/Upd8.Application.csproj", "Upd8.Application/"]
RUN dotnet restore "Upd8.Presentation/Upd8.Api/Upd8.Api.csproj"
COPY . .
WORKDIR "/src/Upd8.Presentation/Upd8.Api"
RUN dotnet build "Upd8.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Upd8.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Upd8.Api.dll"]