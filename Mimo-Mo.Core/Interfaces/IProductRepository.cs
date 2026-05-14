using Mimo_Mo.Core.Entities;

namespace Mimo_Mo.Core.Interfaces;

public interface IProductRepository 
{
 Task<IEnumerable<Product>> GetAllProductsAsync();
 Task<Product> GetProductByIdAsync(int id); 
 Task<Product> CreateProductAsync(Product product);
 Task<Product>   UpdateProductAsync(int id, Product product);
 Task<Product>   DeleteProductAsync(int id);
}