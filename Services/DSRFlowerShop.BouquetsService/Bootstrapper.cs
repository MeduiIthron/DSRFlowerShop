namespace DSRFlowerShop.BouquetService;

using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddBouquetService(this IServiceCollection services)
    {
        services.AddSingleton<IBouquetService, BouquetService>();

        return services;
    }
}
