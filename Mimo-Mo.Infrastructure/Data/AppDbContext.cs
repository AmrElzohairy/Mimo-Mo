using Microsoft.EntityFrameworkCore;
using Mimo_Mo.Core.Entities;
using Mimo_Mo.Infrastructure.Data.Configrations;

namespace Mimo_Mo.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    
    public DbSet<User> Users { get; set; }
    
    public DbSet<Review> Reviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfigrations).Assembly);
    }
}