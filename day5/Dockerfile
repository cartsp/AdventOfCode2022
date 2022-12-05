FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["day5/day5.csproj", "day5/"]
RUN dotnet restore "day5/day5.csproj"
COPY . .
WORKDIR "/src/day5"
RUN dotnet build "day5.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "day5.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "day5.dll"]
