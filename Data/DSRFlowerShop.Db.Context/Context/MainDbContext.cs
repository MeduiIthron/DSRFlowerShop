namespace DSRFlowerShop.Db.Context.Context;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DSRFlowerShop.Db.Entities;
using DSRFlowerShop.Db.Entities.Common;

public class MainDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid> 
{
    public DbSet<Flower> Flowers { get; set; }
    public DbSet<Bouquet> Bouquets { get; set; }
    public DbSet<FlowerList> FlowerLists { get; set; }
    public DbSet<Dealer> Dealers { get; set; }
    public DbSet<FlowerCounter> Counters { get; set; }
    
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
        
        modelBuilder.Entity<FlowerCounter>().ToTable("flower_counters");
        modelBuilder.Entity<FlowerCounter>().Property(x => x.FlowerID).IsRequired();
        modelBuilder.Entity<FlowerCounter>().Property(x => x.BouquetID).IsRequired();
        modelBuilder.Entity<FlowerCounter>().HasOne(x => x.Bouquet).WithMany(x => x.Counters).HasForeignKey(x => x.BouquetID).OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Bouquet>().ToTable("bouquets");
        modelBuilder.Entity<Bouquet>().HasOne(x => x.Dealer).WithMany(x => x.Bouquets).HasForeignKey(x => x.DealerID).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Bouquet>().HasMany(x => x.Flowers).WithMany(x => x.Bouquets).UsingEntity(t => t.ToTable("flowers_bouquets"));

        modelBuilder.Entity<FlowerList>().ToTable("categories");
        modelBuilder.Entity<FlowerList>().Property(x => x.Name).IsRequired();
        modelBuilder.Entity<FlowerList>().HasMany(x => x.Flowers).WithMany(x => x.FlowerLists).UsingEntity(t => t.ToTable("flowers_categories"));
        modelBuilder.Entity<FlowerList>().HasOne(x => x.Dealer).WithMany(x => x.FlowerLists).HasForeignKey(x => x.DealerID).OnDelete(DeleteBehavior.Restrict);
    }
}