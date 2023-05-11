using BusLiner.Domain.Entities;

namespace BusLiner.Domain.Interfaces.Repositories
{
    public interface IRideRepository : IBaseRepository<Ride>
    {
        Task<IEnumerable<Ride>?> GetRidesByQueryAsync(string from, string to, DateTime departureDate);
        Task<IEnumerable<Ride>> GetTopFiveRidesAsync();
    }
}
