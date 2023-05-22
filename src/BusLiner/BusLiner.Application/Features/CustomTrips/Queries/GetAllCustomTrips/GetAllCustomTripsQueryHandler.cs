using BusLiner.Domain.Entities;
using BusLiner.Domain.Interfaces.Repositories;
using MediatR;

namespace BusLiner.Application.Features.CustomTrips.Queries.GetAllCustomTrips
{
    public class GetAllCustomTripsQueryHandler : IRequestHandler<GetAllCustomTripsQuery, IEnumerable<CustomTrip>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCustomTripsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CustomTrip>> Handle(GetAllCustomTripsQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.CustomTripRepository.ListAllAsync();
        }
    }
}
