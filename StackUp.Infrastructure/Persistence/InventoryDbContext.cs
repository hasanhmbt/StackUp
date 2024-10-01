using Microsoft.EntityFrameworkCore;
using StackUp.Domain.Entities;
using StackUp.Domain.ValueObjects;

namespace StackUp.Infrastructure.Persistence
{
    public class InventoryDbContext : DbContext
    {
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InventoryDbContext).Assembly);

            modelBuilder.Entity<Supplier>().HasData(new Supplier("Supplier A", new ContactInfo("contactA@example.com", "+1234567890")));
            modelBuilder.Entity<Category>().HasData(new Category("Electronics", "Electronic Items"));
            modelBuilder.Entity<Product>().HasData(new Product("Laptop", 1, 1200.00m, 10, 1));
            modelBuilder.Entity<Inventory>().HasData(new Inventory(1, 100, 10));

            base.OnModelCreating(modelBuilder);
        }
    }
}
