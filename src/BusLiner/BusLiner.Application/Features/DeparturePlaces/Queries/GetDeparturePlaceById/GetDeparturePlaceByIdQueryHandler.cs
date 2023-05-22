using BusLiner.Application.Exceptions;
using BusLiner.Domain.Entities;
using BusLiner.Domain.Interfaces.Repositories;
using MediatR;

namespace BusLiner.Application.Features.DeparturePlaces.Queries.GetDeparturePlaceById
{
    public class GetDeparturePlaceByIdQueryHandler : IRequestHandler<GetDeparturePlaceByIdQuery, DeparturePlace>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDeparturePlaceByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DeparturePlace> Handle(GetDeparturePlaceByIdQuery request, CancellationToken cancellationToken)
        {
            var depPlace = await _unitOfWork.DeparturePlaceRepository.GetByIdAsync(request.Id);

            if (depPlace == null) 
                throw new NotFoundException(nameof(depPlace), request.Id);

            return depPlace;
        }
    }
}
