FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["SupahFast/SupahFast.csproj", "SupahFast/"]
RUN dotnet restore "SupahFast/SupahFast.csproj"
COPY . .
WORKDIR "/src/SupahFast"
RUN dotnet build "SupahFast.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SupahFast.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SupahFast.dll"]
