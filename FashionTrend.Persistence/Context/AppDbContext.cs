using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Supplier>().Ignore(supplier => supplier.Materials);
        modelBuilder.Entity<Supplier>().Ignore(supplier => supplier.SewingMachines);

        modelBuilder.Entity<Service>().Ignore(service => service.SewingMachines);

        modelBuilder.Entity<Product>().Ignore(product => product.Materials);
    }
}
 