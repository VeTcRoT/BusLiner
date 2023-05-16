using BusLiner.Domain.Entities;

namespace BusLiner.Domain.Interfaces.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<IEnumerable<Order>?> GetAllUserOrdersAsync(string email);
    }
}
