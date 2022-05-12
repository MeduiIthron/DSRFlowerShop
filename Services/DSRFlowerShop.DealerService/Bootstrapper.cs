namespace DSRFlowerShop.DealerService;

using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddDealerService(this IServiceCollection services)
    {
        services.AddSingleton<IDealerService, DealerService>();

        return services;
    }
}