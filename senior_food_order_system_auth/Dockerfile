#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["senior_food_order_system_auth/senior_food_order_system_auth.csproj", "senior_food_order_system_auth/"]
RUN dotnet restore "senior_food_order_system_auth/senior_food_order_system_auth.csproj"
COPY . .
WORKDIR "/src/senior_food_order_system_auth"
RUN dotnet build "senior_food_order_system_auth.csproj" -c Release -o /app/build

# run tests on docker build
FROM build AS test
RUN dotnet test --no-build --verbosity normal "UnitTest/UnitTest.csproj"

FROM build AS publish
RUN dotnet publish "senior_food_order_system_auth.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "senior_food_order_system_auth.dll"]
