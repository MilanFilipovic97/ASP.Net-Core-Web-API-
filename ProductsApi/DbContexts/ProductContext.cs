using Microsoft.EntityFrameworkCore;
using ProductsApi.Models;

namespace ProductsApi.DbContexts
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().
                HasData(
                new Product("123", "Biscuit")
                {
                    Id = 1,
                    Vat = "20",
                    Description = "Very nice biscuit",
                    OnStock = "On stock",
                    Manufacturer = "Amazon"
                }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
