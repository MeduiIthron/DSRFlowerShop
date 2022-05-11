namespace DSRFlowerShop.Db.Context.Factories;

using Microsoft.EntityFrameworkCore;
using DSRFlowerShop.Db.Context.Context;

public class MainDbContextFactory
{
    private readonly DbContextOptions<MainDbContext> options;

    public MainDbContextFactory(DbContextOptions<MainDbContext> options)
    {
        this.options = options;
    }

    public MainDbContext Create()
    {
        return new MainDbContext(options);
    }
}
