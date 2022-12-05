FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["day4/day4.csproj", "day4/"]
RUN dotnet restore "day4/day4.csproj"
COPY . .
WORKDIR "/src/day4"
RUN dotnet build "day4.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "day4.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "day4.dll"]
