using Microsoft.EntityFrameworkCore;
using ProductsApi.DbContexts;
using ProductsApi.Models;
using System;

namespace ProductsApi.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _productContext;
        public ProductRepository(ProductContext context)
        {
            _productContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productContext.Products.ToListAsync();
        }

        public async Task AddProductAsync(Product product)
        {
            await _productContext.Products.AddAsync(product);
        }
        public bool Save()
        {
            return (_productContext.SaveChanges() >= 0);
        }

        public async Task<bool> ProductExists(int id)
        {
            return await _productContext.Products.AnyAsync(p => p.Id == id);
        }

        public void DeleteProduct(Product product)
        {
            _productContext.Products.Remove(product);
        }

        public async Task<Product?> GetProductById(int id)
        {
            return await _productContext.Products.
                Where(p => p.Id == id).
                FirstOrDefaultAsync();
        }
    }
}
