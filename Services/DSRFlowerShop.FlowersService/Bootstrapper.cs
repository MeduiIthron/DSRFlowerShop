namespace DSRFlowerShop.FlowerService;

using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddFlowerService(this IServiceCollection services)
    {
        services.AddSingleton<IFlowerService, FlowerService>();

        return services;
    }
}
