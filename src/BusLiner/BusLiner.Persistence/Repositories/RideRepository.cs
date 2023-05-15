using BusLiner.Domain.Entities;
using BusLiner.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BusLiner.Persistence.Repositories
{
    public class RideRepository : BaseRepository<Ride>, IRideRepository
    {
        private readonly BusLinerDbContext _dbContext;

        public RideRepository(BusLinerDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Ride>?> GetAllUserRidesAsync(string email)
        {
            var userRides = await _dbContext.Orders.Where(o => o.Email == email).ToListAsync();
            return (IEnumerable<Ride>)userRides;
        }

        public async Task<Ride> GetRideByIdAsync(int id)
        {
            return await _dbContext.Rides.Include(r => r.DeparturePlace)
                .Include(r => r.ArrivalPlace).FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Ride>?> GetRidesByQueryAsync(string from, string to, DateTime departureDate)
        {

            var rides = await (_dbContext.Rides.Include(r => r.DeparturePlace).Include(r => r.ArrivalPlace)
                .Where(r => r.DepartureTime.Date == departureDate.Date
                && r.DeparturePlace.City == from && r.ArrivalPlace.City == to)).ToListAsync();

            return rides;
        }

        public async Task<IEnumerable<Ride>> GetTopFiveRidesAsync()
        {
            var rides = await (_dbContext.Rides.OrderBy(r => r.TicketsAvailable)
                .Include(r => r.DeparturePlace).Include(r => r.ArrivalPlace)
                .Where(r => r.DepartureTime >= DateTime.Now).Take(5)).ToListAsync();

            return rides;
        }
    }
}
