namespace DSRFlowerShop.API;

using DSRFlowerShop.DealerService;
using DSRFlowerShop.FlowerService;
using DSRFlowerShop.Settings;

public static class Bootstrapper
{
    public static void AddAppServices(this IServiceCollection services)
    {
        services
            .AddSettings()
            .AddFlowerService()
            .AddDealerService();
    }
}