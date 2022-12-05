FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["day3/day3.csproj", "day3/"]
RUN dotnet restore "day3/day3.csproj"
COPY . .
WORKDIR "/src/day3"
RUN dotnet build "day3.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "day3.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "day3.dll"]
