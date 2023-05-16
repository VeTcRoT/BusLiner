using BusLiner.Domain.Entities;
using BusLiner.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BusLiner.Persistence.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly BusLinerDbContext _dbContext;
        public OrderRepository(BusLinerDbContext dbContext) : base(dbContext) 
        { 
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Order>?> GetAllUserOrdersAsync(string email)
        {
            var userOrders = await _dbContext.Orders.Where(o => o.Email == email)
                .Include(o => o.Ride)
                .Include(o => o.Ride.DeparturePlace)
                .Include(o => o.Ride.ArrivalPlace).ToListAsync();

            return userOrders;
        }
    }
}
