namespace DSRFlowerShop.Api.Configuration;

using DSRFlowerShop.Api.Middlewares;

public static class MiddlewaresConfiguration
{
    public static IApplicationBuilder UseAppMiddlewares(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ExceptionsMiddleware>();
    }
}
