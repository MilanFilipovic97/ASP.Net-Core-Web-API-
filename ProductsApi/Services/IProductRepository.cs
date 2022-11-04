using Microsoft.EntityFrameworkCore.Query.Internal;
using ProductsApi.Models;

namespace ProductsApi.Services
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task AddProductAsync(Product product);
        bool Save();
        Task<bool> ProductExists(int id);
        void DeleteProduct(Product p);
        Task<Product?> GetProductById(int id);
    }
}
