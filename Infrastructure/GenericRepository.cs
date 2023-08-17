using Core.Interfaces;
using Core.Entities;
using Infrastructure.DataStore;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ShopContext _shopContext;
        public GenericRepository(ShopContext shopContext)
        {
            _shopContext = shopContext;

        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _shopContext.Set<T>().FindAsync();

        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _shopContext.Set<T>().ToListAsync();

        }
    }
}