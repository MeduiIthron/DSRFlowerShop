using DSRFlowerShop.BouquetService;
using DSRFlowerShop.DealerService;
using DSRFlowerShop.FlowerService;
using DSRFlowerShop.Logger;
using DSRFlowerShop.Settings;

namespace DSRFlowerShop.Api;

public static class Bootstrapper
{
    public static void AddAppServices(this IServiceCollection services)
    {
        services
            .AddSettings()
            .AddLogger()
            .AddDealerService()
            .AddBouquetService()
            .AddFlowerService();
    }
}