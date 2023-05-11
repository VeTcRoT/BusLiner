using BusLiner.Domain.Entities;

namespace BusLiner.Domain.Interfaces.Repositories
{
    public interface IRideRepository : IBaseRepository<Ride>
    {
        Task<IEnumerable<Ride>> GetRidesByQuery(string from, string to, DateOnly departureDate);
    }
}
