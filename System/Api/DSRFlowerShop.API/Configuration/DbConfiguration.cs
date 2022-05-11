namespace DSRFlowerShop.API.Configuration;

using DSRFlowerShop.Db.Context.Context;
using DSRFlowerShop.Db.Context.Factories;
using DSRFlowerShop.Db.Context.Setup;
using DSRFlowerShop.Settings;
using Microsoft.Extensions.DependencyInjection;

public static class DbConfiguration
{
    public static IServiceCollection AddAppDbContext(this IServiceCollection services, IApiSettings settings)
    {
        var dbOptionsDelegate = DbContextOptionFactory.Configure(settings.Db.ConnectionString);

        services.AddDbContextFactory<MainDbContext>(dbOptionsDelegate, ServiceLifetime.Singleton);

        return services;
    }

    public static IApplicationBuilder UseAppDbContext(this IApplicationBuilder app)
    {
        DbInit.Execute(app.ApplicationServices);

        DbSeed.Execute(app.ApplicationServices);

        return app;
    }
}
