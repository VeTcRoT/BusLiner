using BusLiner.Domain.Entities;

namespace BusLiner.Domain.Interfaces.Repositories
{
    public interface IRideRepository : IBaseRepository<Ride>
    {
        Task<IEnumerable<Ride>?> GetRidesByQueryAsync(string from, string to, DateOnly departureDate);
        Task<IEnumerable<Ride>> GetTopFiveRidesAsync();
    }
}
