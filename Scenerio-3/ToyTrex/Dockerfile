FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["ToyTrex.csproj", "ToyTrex/"]

RUN dotnet restore "ToyTrex.csproj"
COPY . .
WORKDIR "/src/ToyTrex"
RUN dotnet build "ToyTrex.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ToyTrex.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToyTrex.dll"]