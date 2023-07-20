using Core.Entities;
using Core.Interfaces;
using Infrastructure.DataStore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{

    public class ProductRepository : IProductRepository
    {
        private readonly ShopContext _shopContext;

        public ProductRepository(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _shopContext.Products.FindAsync(id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsListAsync()
        {
            return await _shopContext.Products?.ToListAsync();
        }
    }
}