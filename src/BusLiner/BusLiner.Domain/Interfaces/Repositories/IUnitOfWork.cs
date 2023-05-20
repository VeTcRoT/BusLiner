using BusLiner.Domain.Entities;

namespace BusLiner.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRideRepository RideRepository { get; }
        IBaseRepository<DeparturePlace> DeparturePlaceRepository { get; }
        IBaseRepository<ArrivalPlace> ArrivalPlaceRepository { get; }
        IOrderRepository OrderRepository { get; }
        IBaseRepository<CustomTrip> CustomTripRepository { get; }
        Task SaveAsync();
    }
}
