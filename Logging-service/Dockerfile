#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Logging-service/Logging-service.csproj", "Logging-service/"]
RUN dotnet restore "Logging-service/Logging-service.csproj"
COPY . .
WORKDIR "/src/Logging-service"
RUN dotnet build "Logging-service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Logging-service.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Logging-service.dll"]