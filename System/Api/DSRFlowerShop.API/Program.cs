using Serilog;
using DSRFlowerShop.Settings;
using DSRFlowerShop.API;
using DSRFlowerShop.API.Configuration;

// Configure application
var builder = WebApplication.CreateBuilder(args);

// Logger
builder.Host.UseSerilog((hostBuilderContext, loggerConfiguration) =>
{
    loggerConfiguration
        .Enrich.WithCorrelationId()
        .ReadFrom.Configuration(hostBuilderContext.Configuration);
});

var settings = new ApiSettings(new SettingsSource());
var services = builder.Services;

services.AddHttpContextAccessor();
services.AddAppHealthCheck();
services.AddAppVersions();
services.AddAppCors();
services.AddSettings();
services.AddAppServices();
services.AddAppAuth(settings);
services.AddAppSwagger(settings);
services.AddControllers().AddValidator();
services.AddRazorPages();
services.AddAppDbContext(settings);
services.AddAutoMappers();

var app = builder.Build();

Log.Information("Stating up");
app.UseAppMiddlewares();
app.UseStaticFiles();
app.UseAppHealthCheck();
app.UseApiVersioning();
app.UseAppCors();
app.UseAppSwagger();
app.UseSerilogRequestLogging();
app.UseRouting();
app.UseAppAuth();
app.MapRazorPages();
app.MapControllers();
app.UseAppDbContext();

app.Run();