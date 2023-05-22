using BusLiner.Application.Exceptions;
using BusLiner.Domain.Entities;
using BusLiner.Domain.Interfaces.Repositories;
using MediatR;

namespace BusLiner.Application.Features.CustomTrips.Queries.GetCustomTripById
{
    public class GetCustomTripByIdQueryHandler : IRequestHandler<GetCustomTripByIdQuery, CustomTrip>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCustomTripByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomTrip> Handle(GetCustomTripByIdQuery request, CancellationToken cancellationToken)
        {
            var customTrip = await _unitOfWork.CustomTripRepository.GetByIdAsync(request.Id);

            if (customTrip == null)
                throw new NotFoundException(nameof(CustomTrip), request.Id);

            return customTrip;
        }
    }
}
