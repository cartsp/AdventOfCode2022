FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["day7/day7.csproj", "day7/"]
RUN dotnet restore "day7/day7.csproj"
COPY . .
WORKDIR "/src/day7"
RUN dotnet build "day7.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "day7.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "day7.dll"]
