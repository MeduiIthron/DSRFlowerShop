namespace DSRFlowerShop.Db.Context.Context;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DSRFlowerShop.Db.Entities;

public class MainDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid> 
{
    public DbSet<Flower> Flowers { get; set; }
    public DbSet<Bouquet> Bouquets { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Dealer> Dealers { get; set; }
    
    public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().ToTable("users");
        modelBuilder.Entity<IdentityRole<Guid>>().ToTable("user_roles");
        modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("user_tokens");
        modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("user_role_owners");
        modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("user_role_claims");
        modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("user_logins");
        modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("user_claims");

        modelBuilder.Entity<Dealer>().ToTable("dealers");
        modelBuilder.Entity<Dealer>().Property(x => x.Login).IsRequired();
        modelBuilder.Entity<Dealer>().Property(x => x.Password).IsRequired();

        modelBuilder.Entity<Flower>().ToTable("flowers");
        modelBuilder.Entity<Flower>().Property(x => x.Name).IsRequired();
        modelBuilder.Entity<Flower>().Property(x => x.Name).HasMaxLength(250);
        modelBuilder.Entity<Flower>().HasOne(x => x.Dealer).WithMany(x => x.Flowers).HasForeignKey(x => x.DealerID).OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Bouquet>().ToTable("bouquets");
        modelBuilder.Entity<Bouquet>().HasOne(x => x.Dealer).WithMany(x => x.Bouquets).HasForeignKey(x => x.DealerID).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Bouquet>().HasMany(x => x.Flowers).WithMany(x => x.Bouquets).UsingEntity(t => t.ToTable("flowers_bouquets"));

        modelBuilder.Entity<Category>().ToTable("categories");
        modelBuilder.Entity<Category>().Property(x => x.Name).IsRequired();
        modelBuilder.Entity<Category>().HasMany(x => x.Flowers).WithMany(x => x.Categories).UsingEntity(t => t.ToTable("flowers_categories"));
        modelBuilder.Entity<Category>().HasOne(x => x.Dealer).WithMany(x => x.Categories).HasForeignKey(x => x.DealerID).OnDelete(DeleteBehavior.Restrict);
    }
}