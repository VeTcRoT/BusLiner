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

        public async Task<IEnumerable<Ride>?> GetRidesByQuery(string from, string to, DateOnly departureDate)
        {
            var rides = await (_dbContext.Rides.Where(r => DateOnly.Parse(r.DepartureTime.ToString("dd/MM/yyyy")) == departureDate
                && r.DeparturePlace.City == from && r.ArrivalPlace.City == to)).ToListAsync();

            return rides;
        }
    }
}
