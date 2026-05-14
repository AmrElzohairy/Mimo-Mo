using Microsoft.EntityFrameworkCore;
using Mimo_Mo.Core.Entities;
using Mimo_Mo.Core.Interfaces;
using Mimo_Mo.Infrastructure.Data;

namespace Mimo_Mo.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _context.Products.AsNoTracking().ToListAsync();
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<Product> CreateProductAsync(Product product)
    {
        var newProduct = await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return newProduct.Entity;
    }

    public async Task<Product> UpdateProductAsync(int id, Product product)
    {
        var oldProduct = await _context.Products.FindAsync(id);
        if (oldProduct == null) return null!; 

        _context.Entry(oldProduct).CurrentValues.SetValues(product);
        await _context.SaveChangesAsync();
        return oldProduct;
    }

    public async Task<Product> DeleteProductAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
        return product!; 
    }
}