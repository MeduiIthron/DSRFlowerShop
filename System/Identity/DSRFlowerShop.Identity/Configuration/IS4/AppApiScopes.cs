namespace DSRFlowerShop.Identity;

using DSRFlowerShop.Common.Security;
using Duende.IdentityServer.Models;

public static class AppApiScopes
{
    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope(AppScopes.FlowersRead, "Access to flowers API - Read data"),
            new ApiScope(AppScopes.FlowersWrite, "Access to flowers API - Write data")
        };
}