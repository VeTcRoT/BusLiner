using BusLiner.Application.Exceptions;
using BusLiner.Domain.Entities;
using BusLiner.Domain.Interfaces.Repositories;
using MediatR;

namespace BusLiner.Application.Features.ArrivalPlaces.Queries.GetArrivalPlaceById
{
    public class GetArrivalPlaceByIdQueryHandler : IRequestHandler<GetArrivalPlaceByIdQuery, ArrivalPlace>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetArrivalPlaceByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ArrivalPlace> Handle(GetArrivalPlaceByIdQuery request, CancellationToken cancellationToken)
        {
            var arrPlace = await _unitOfWork.ArrivalPlaceRepository.GetByIdAsync(request.Id);

            if (arrPlace == null)
                throw new NotFoundException(nameof(arrPlace), request.Id);

            return arrPlace;
        }
    }
}
