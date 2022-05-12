#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["System/Api/DSRFlowerShop.Api/DSRFlowerShop.Api.csproj", "System/Api/DSRFlowerShop.Api/"]
COPY ["Services/DSRFlowerShop.BouquetService/DSRFlowerShop.BouquetService.csproj", "Services/DSRFlowerShop.BouquetService/"]
COPY ["Services/DSRFlowerShop.FlowerService/DSRFlowerShop.FlowerService.csproj", "Services/DSRFlowerShop.FlowerService/"]
COPY ["Services/DSRFlowerShop.Logger/DSRFlowerShop.Logger.csproj", "Services/DSRFlowerShop.Logger/"]
COPY ["Services/DSRFlowerShop.Settings/DSRFlowerShop.Settings.csproj", "Services/DSRFlowerShop.Settings/"]
COPY ["Data/DSRFlowerShop.Db.Context/DSRFlowerShop.Db.Context.csproj", "Data/DSRFlowerShop.Db.Context/"]
COPY ["Data/DSRFlowerShop.Db.Entities/DSRFlowerShop.Db.Entities.csproj", "Data/DSRFlowerShop.Db.Entities/"]
COPY ["Services/DSRFlowerShop.FlowerListService/DSRFlowerShop.FlowerListService.csproj", "Services/DSRFlowerShop.FlowerListService/"]
COPY ["Services/DSRFlowerShop.DealerService/DSRFlowerShop.DealerService.csproj", "Services/DSRFlowerShop.DealerService/"]
COPY ["Shared/DSRFlowerShop.Common/DSRFlowerShop.Common.csproj", "Shared/DSRFlowerShop.Common/"]
RUN dotnet restore "System/Api/DSRFlowerShop.Api/DSRFlowerShop.Api.csproj"
COPY . .
WORKDIR "/src/System/Api/DSRFlowerShop.Api"
RUN dotnet build "DSRFlowerShop.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DSRFlowerShop.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DSRFlowerShop.Api.dll"]
