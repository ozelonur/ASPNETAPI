using System.Reflection;
using KPSS.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace KPSS.Repository;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductFeature> ProductFeatures { get; set; }

    public override int SaveChanges()
    {
        UpdateChangeTracker();

        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        UpdateChangeTracker();

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature
            {
                Id = 1,
                Color = "Red",
                Height = 100,
                Width = 200,
                ProductId = 1
            },
            new ProductFeature
            {
                Id = 2,
                Color = "Blue",
                Height = 200,
                Width = 500,
                ProductId = 2
            });

        base.OnModelCreating(modelBuilder);
    }

    private void UpdateChangeTracker()
    {
        foreach (EntityEntry item in ChangeTracker.Entries())
        {
            if (item.Entity is BaseEntity entityReference)
            {
                switch (item.State)
                {
                    case EntityState.Added:
                        entityReference.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        Entry(entityReference).Property(x => x.CreatedDate).IsModified = false;
                        entityReference.UpdatedDate = DateTime.Now;
                        break;
                }
            }
        }
    }
}