FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["day2/day2.csproj", "day2/"]
RUN dotnet restore "day2/day2.csproj"
COPY . .
WORKDIR "/src/day2"
RUN dotnet build "day2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "day2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "day2.dll"]
