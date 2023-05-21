namespace BusLiner.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
