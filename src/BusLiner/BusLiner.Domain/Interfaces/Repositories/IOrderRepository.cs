using BusLiner.Domain.Entities;

namespace BusLiner.Domain.Interfaces.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<IEnumerable<Ride>?> GetAllUserRidesAsync(string email);
    }
}
