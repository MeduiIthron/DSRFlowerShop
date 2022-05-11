namespace DSRFlowerShop.Identity;

using Duende.IdentityServer.Test;

public static class AppApiTestUsers
{
    public static List<TestUser> ApiUsers =>
        new List<TestUser>
        {
            new TestUser
            {
                SubjectId = "1",
                Username = "admin@tst.com",
                Password = "password"
            }
        };
}