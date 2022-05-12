using Microsoft.Extensions.DependencyInjection;

namespace DSRFlowerShop.BouquetService;

public static class Bootstrapper
{
    public static IServiceCollection AddBouquetService(this IServiceCollection services)
    {
        services.AddSingleton<IBouquetService, BouquetService>();

        return services;
    }
}