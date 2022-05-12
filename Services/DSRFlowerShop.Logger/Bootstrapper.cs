namespace DSRFlowerShop.Logger;

using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddLogger(this IServiceCollection services)
    {
        services.AddSingleton<ILogger, Logger>();
        return services;
    }
}
