namespace DSRFlowerShop.API.Configuration;

using DSRFlowerShop.API.Middlewares;

public static class MiddlewaresConfiguration
{
    public static IApplicationBuilder UseAppMiddlewares(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ExceptionsMiddleware>();
    }
}
