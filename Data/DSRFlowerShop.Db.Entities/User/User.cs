namespace DSRFlowerShop.Db.Entities;

using Microsoft.AspNetCore.Identity;

public class User: IdentityUser<Guid> 
{
    public string Name { get; set; }
}