#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GeodataManager/GeodataManager.csproj", "GeodataManager/"]
RUN dotnet restore "GeodataManager/GeodataManager.csproj"
COPY . .
WORKDIR "/src/GeodataManager"
RUN dotnet build "GeodataManager.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GeodataManager.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GeodataManager.dll"]