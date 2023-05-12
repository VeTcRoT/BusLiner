using AutoMapper;
using BusLiner.Application.Exceptions;
using BusLiner.Domain.Entities;
using BusLiner.Domain.Interfaces.Repositories;
using MediatR;

namespace BusLiner.Application.Features.ArrivalPlaces.ListAllArrivalPlaces
{
    internal class ListAllArrivalPlacesQueryHandler : IRequestHandler<ListAllArrivalPlacesQuery, IEnumerable<ListAllArrivalPlacesDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ListAllArrivalPlacesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ListAllArrivalPlacesDto>> Handle(ListAllArrivalPlacesQuery request, CancellationToken cancellationToken)
        {
            var arrivalPlaces = await _unitOfWork.ArrivalPlaceRepository.ListAllAsync();

            if (arrivalPlaces == null)
                throw new NotFoundException(nameof(ArrivalPlace), "can't be found.");

            return _mapper.Map<IEnumerable<ListAllArrivalPlacesDto>>(arrivalPlaces).DistinctBy(a => a.City);
        }
    }
}
