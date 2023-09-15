using barraca.Models;
using Microsoft.EntityFrameworkCore;

public class BarracaContext : DbContext {
    public BarracaContext(DbContextOptions<BarracaContext> options) : base(options) {}

    public DbSet<Customer> customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Replenishment> Replenishments { get; set; }
    public DbSet<Shop> Shops { get; set; }
}
