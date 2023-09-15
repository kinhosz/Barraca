using barraca.Models;
using Microsoft.EntityFrameworkCore;

public class BarracaContext : DbContext {
    public BarracaContext(DbContextOptions<BarracaContext> options) : base(options) {}

    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Replenishment> Replenishments { get; set; } = null!;
    public DbSet<Shop> Shops { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        if(!Database.GetPendingMigrations().Any()) {
            modelBuilder.Entity<Customer>().ToTable("Customers");
        }
        
        base.OnModelCreating(modelBuilder);
    }
}
