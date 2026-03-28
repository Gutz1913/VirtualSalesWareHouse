using Microsoft.EntityFrameworkCore;
using VirtualSalesWareHouse.Data.Entities;

namespace VirtualSalesWareHouse.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {        
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }    
    public DbSet<State> States { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasIndex(c => c.Name).IsUnique();
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasIndex(c => c.Name).IsUnique();
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasIndex("Name", "CountryId").IsUnique();
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasIndex("Name", "StateId").IsUnique();
        });
    }
}
