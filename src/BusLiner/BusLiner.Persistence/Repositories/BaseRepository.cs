using BusLiner.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BusLiner.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbSet<T> _entitySet;
        public BaseRepository(BusLinerDbContext dbContext)
        {
            _entitySet = dbContext.Set<T>();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _entitySet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> ListAllAsync()
        {
            return await _entitySet.ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _entitySet.AddAsync(entity);
            return entity;
        }

        public void Update(T entity)
        {
            _entitySet.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _entitySet.Remove(entity);
        }
    }
}
