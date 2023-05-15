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
        public async Task<IEnumerable<Ride>?> GetAllUserRidesAsync(string email)
        {
            var userRides = await _dbContext.Orders.Where(o => o.Email == email).ToListAsync();
            return (IEnumerable<Ride>)userRides;
        }
    }
}
