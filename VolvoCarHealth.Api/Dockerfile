FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["VolvoCarHealth.Api/VolvoCarHealth.Api.csproj", "VolvoCarHealth.Api/"]
COPY ["VolvoCarHealth.Domain/VolvoCarHealth.Domain.csproj", "VolvoCarHealth.Domain/"]
COPY ["VolvoCarHealth.Infrastructure/VolvoCarHealth.Infrastructure.csproj", "VolvoCarHealth.Infrastructure/"]

RUN dotnet restore "VolvoCarHealth.Api/VolvoCarHealth.Api.csproj"
COPY . .
WORKDIR "/src/VolvoCarHealth.Api"
RUN dotnet build "VolvoCarHealth.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VolvoCarHealth.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VolvoCarHealth.Api.dll"]
