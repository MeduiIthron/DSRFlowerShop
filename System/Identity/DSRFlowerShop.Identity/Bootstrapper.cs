namespace DSRFlowerShop.Identity;

using DSRFlowerShop.Settings;

public static class Bootstrapper
{
    public static void AddAppServices(this IServiceCollection services)
    {
        services
            .AddSettings()
            ;
    }
}