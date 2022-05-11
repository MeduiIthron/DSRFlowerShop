namespace DSRFlowerShop.Settings;

using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddSettings(this IServiceCollection services)
    {
        services.AddSingleton<ISettingsSource, SettingsSource>();
        services.AddSingleton<IIdentityServerConnectSettings, IdentityServerConnectSettings>();
        services.AddSingleton<IGeneralSettings, GeneralSettings>();
        services.AddSingleton<IDbSettings, DbSettings>();
        services.AddSingleton<IApiSettings, ApiSettings>();
        services.AddSingleton<IIS4Settings, IS4Settings>();

        return services;
    }
}
