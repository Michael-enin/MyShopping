using Core.Entities;
using Core.Interfaces;
using Infrastructure.DataStore;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Infrastructure.Repositories
{

    public class ProductRepository : IProductRepository
    {
        private readonly ShopContext _shopContext;

        public ProductRepository(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _shopContext.Products
            .Include(pro => pro.ProductTypeId)
            .Include(pro => pro.ProductBrandId)
            .FirstOrDefaultAsync(pro => pro.Id == id);

        }

        public async Task<IReadOnlyList<Product>> GetProductsListAsync()
        {
            return await _shopContext.Products?
             .Include(p => p.ProductTypeId)
             .Include(p => p.ProductBrandId)
             .ToListAsync();
        }

        public Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            throw new NotImplementedException();
        }
    }
}