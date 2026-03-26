using Microsoft.EntityFrameworkCore;
using VirtualSalesWareHouse.Data.Entities;

namespace VirtualSalesWareHouse.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {        
    }

    public DbSet<Country> Countries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasIndex(c => c.Name).IsUnique();
        });
    }
}
