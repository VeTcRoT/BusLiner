using AutoMapper;
using BusLiner.Domain.Interfaces.Repositories;
using MediatR;

namespace BusLiner.Application.Features.DeparturePlaces.Queries.GetAllDeparturePlaces
{
    public class GetAllDeparturePlacesQueryHandler : IRequestHandler<GetAllDeparturePlacesQuery, IEnumerable<GetAllDeparturePlacesDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllDeparturePlacesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllDeparturePlacesDto>> Handle(GetAllDeparturePlacesQuery request, CancellationToken cancellationToken)
        {
            var departurePlaces = await _unitOfWork.DeparturePlaceRepository.ListAllAsync();

            return _mapper.Map<IEnumerable<GetAllDeparturePlacesDto>>(departurePlaces).DistinctBy(r => new { r.City, r.Street });
        }
    }
}
