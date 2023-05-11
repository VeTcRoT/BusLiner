using BusLiner.Application.Exceptions;
using BusLiner.Domain.Entities;
using BusLiner.Domain.Interfaces.Repositories;
using MediatR;

namespace BusLiner.Application.Features.Rides.Queries.GetTopFiveRides
{
    public class GetTopFiveRidesQueryHandler : IRequestHandler<GetTopFiveRidesQuery, IEnumerable<Ride>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTopFiveRidesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Ride>> Handle(GetTopFiveRidesQuery request, CancellationToken cancellationToken)
        {
            var topRides = await _unitOfWork.RideRepository.GetTopFiveRidesAsync();

            if (topRides == null)
                throw new NotFoundException("Rides not found.");

            return topRides;
        }
    }
}
