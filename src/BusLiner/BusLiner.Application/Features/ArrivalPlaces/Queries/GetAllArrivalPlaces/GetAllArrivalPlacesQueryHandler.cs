using AutoMapper;
using BusLiner.Application.Features.DeparturePlaces.Queries.GetAllDeparturePlaces;
using BusLiner.Domain.Interfaces.Repositories;
using MediatR;

namespace BusLiner.Application.Features.ArrivalPlaces.Queries.GetAllArrivalPlaces
{
    public class GetAllArrivalPlacesQueryHandler : IRequestHandler<GetAllArrivalPlacesQuery, IEnumerable<GetAllArrivalPlacesDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllArrivalPlacesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllArrivalPlacesDto>> Handle(GetAllArrivalPlacesQuery request, CancellationToken cancellationToken)
        {
            var arrivalPlaces = await _unitOfWork.ArrivalPlaceRepository.ListAllAsync();

            return _mapper.Map<IEnumerable<GetAllArrivalPlacesDto>>(arrivalPlaces).DistinctBy(r => new { r.City, r.Street });
        }
    }
}
