using Dapr.Workflow.Starter.API.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Dapr.Workflow.Starter.API.DataAccess
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PaymentDetails> PaymentDetails { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {
                //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, ProductName = "Mark O Pen", ProductDescription = "Pen that marks", UnitCost = 10.99 },
                new Product { Id = 2, ProductName = "Mark O Gel", ProductDescription = "Gel that marks", UnitCost = 10.99 },
                new Product { Id = 3, ProductName = "Mark O Copy", ProductDescription = "Copy that marks", UnitCost = 10.99 }
                );
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Email = "aps1@aps.com", Name = "Arkaprava Sinha1" },
                new User { Id = 2, Email = "aps2@aps.com", Name = "Arkaprava Sinha2" },
                new User { Id = 3, Email = "aps3@aps.com", Name = "Arkaprava Sinha3" }
                );
            modelBuilder.Entity<Inventory>().HasData(
                new Inventory { Id = 1, ProductId = 1, stock = 10, CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now },
                new Inventory { Id = 2, ProductId = 2, stock = 10, CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now },
                new Inventory { Id = 3, ProductId = 3, stock = 10, CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now }

                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
