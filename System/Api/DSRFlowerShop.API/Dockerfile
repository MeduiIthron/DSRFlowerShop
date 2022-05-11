#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["System/Api/DSRFlowerShop.API.csproj", "System/Api/"]
COPY ["Services/DSRFlowerShop.FlowersService/DSRFlowerShop.FlowerService.csproj", "Services/DSRFlowerShop.FlowersService/"]
COPY ["Data/DSRFlowerShop.Db.Context/DSRFlowerShop.Db.Context.csproj", "Data/DSRFlowerShop.Db.Context/"]
COPY ["Data/DSRFlowerShop.Db.Entities/DSRFlowerShop.Db.Entities.csproj", "Data/DSRFlowerShop.Db.Entities/"]
COPY ["Shared/DSRFlowerShop.Common/DSRFlowerShop.Common.csproj", "Shared/DSRFlowerShop.Common/"]
COPY ["Services/DSRFlowerShop.Logger/DSRFlowerShop.Logger.csproj", "Services/DSRFlowerShop.Logger/"]
COPY ["Services/DSRFlowerShop.DealersService/DSRFlowerShop.DealersService.csproj", "Services/DSRFlowerShop.DealersService/"]
COPY ["Services/DSRFlowerShop.Settings/DSRFlowerShop.Settings.csproj", "Services/DSRFlowerShop.Settings/"]
RUN dotnet restore "System/Api/DSRFlowerShop.API.csproj"
COPY . .
WORKDIR "/src/System/Api"
RUN dotnet build "DSRFlowerShop.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DSRFlowerShop.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DSRFlowerShop.API.dll"]