namespace DSRFlowerShop.API.Configuration;

using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Reflection;

public class ApiHealthCheck: IHealthCheck
{
    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default(CancellationToken))
    {
        var assembly = Assembly.Load("DSRFlowerShop.API");
        var versionNumber = assembly.GetName().Version;

        return HealthCheckResult.Healthy(description: $"Build {versionNumber}");
    }    
}