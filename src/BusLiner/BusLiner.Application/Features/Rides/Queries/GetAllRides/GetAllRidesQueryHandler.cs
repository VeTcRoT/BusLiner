using BusLiner.Domain.Entities;
using BusLiner.Domain.Interfaces.Repositories;
using MediatR;

namespace BusLiner.Application.Features.Rides.Queries.GetAllRides
{
    public class GetAllRidesQueryHandler : IRequestHandler<GetAllRidesQuery, IEnumerable<Ride>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllRidesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Ride>> Handle(GetAllRidesQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.RideRepository.GetAllRidesAsync();
        }
    }
}
