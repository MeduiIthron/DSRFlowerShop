#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["System/Identity/DSRFlowerShop.Identity/DSRFlowerShop.Identity.csproj", "System/Identity/DSRFlowerShop.Identity/"]
COPY ["Services/DSRFlowerShop.Settings/DSRFlowerShop.Settings.csproj", "Services/DSRFlowerShop.Settings/"]
COPY ["Data/DSRFlowerShop.Db.Context/DSRFlowerShop.Db.Context.csproj", "Data/DSRFlowerShop.Db.Context/"]
COPY ["Data/DSRFlowerShop.Db.Entities/DSRFlowerShop.Db.Entities.csproj", "Data/DSRFlowerShop.Db.Entities/"]
COPY ["Shared/DSRFlowerShop.Common/DSRFlowerShop.Common.csproj", "Shared/DSRFlowerShop.Common/"]
RUN dotnet restore "System/Identity/DSRFlowerShop.Identity/DSRFlowerShop.Identity.csproj"
COPY . .
WORKDIR "/src/System/Identity/DSRFlowerShop.Identity"
RUN dotnet build "DSRFlowerShop.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DSRFlowerShop.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DSRFlowerShop.Identity.dll"]