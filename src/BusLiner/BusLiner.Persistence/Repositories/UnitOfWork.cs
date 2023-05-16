using BusLiner.Domain.Entities;
using BusLiner.Domain.Interfaces.Repositories;

namespace BusLiner.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BusLinerDbContext _dbContext;
        public IRideRepository RideRepository { get; }

        public IBaseRepository<DeparturePlace> DeparturePlaceRepository { get; }

        public IBaseRepository<ArrivalPlace> ArrivalPlaceRepository { get; }

        public IOrderRepository OrderRepository { get; set; }

        private bool disposed = false;

        public UnitOfWork(BusLinerDbContext dbContext, IRideRepository rideRepository, 
            IBaseRepository<DeparturePlace> departurePlaceRepository, IBaseRepository<ArrivalPlace> arrivalPlaceRepository,
            IOrderRepository orderRepository)
        {
            _dbContext = dbContext;
            RideRepository = rideRepository;
            DeparturePlaceRepository = departurePlaceRepository;
            ArrivalPlaceRepository = arrivalPlaceRepository;
            OrderRepository = orderRepository;
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }
    }
}
