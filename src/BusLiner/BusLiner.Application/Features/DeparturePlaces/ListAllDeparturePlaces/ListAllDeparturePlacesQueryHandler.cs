using AutoMapper;
using BusLiner.Application.Exceptions;
using BusLiner.Domain.Entities;
using BusLiner.Domain.Interfaces.Repositories;
using MediatR;

namespace BusLiner.Application.Features.DeparturePlaces.ListAllDeparturePlaces
{
    public class ListAllDeparturePlacesQueryHandler : IRequestHandler<ListAllDeparturePlacesQuery, IEnumerable<ListAllDeparturePlacesDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ListAllDeparturePlacesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ListAllDeparturePlacesDto>> Handle(ListAllDeparturePlacesQuery request, CancellationToken cancellationToken)
        {
            var departurePlaces = await _unitOfWork.DeparturePlaceRepository.ListAllAsync();

            if (departurePlaces == null)
                throw new NotFoundException(nameof(DeparturePlace), "can't be found.");

            return _mapper.Map<IEnumerable<ListAllDeparturePlacesDto>>(departurePlaces).DistinctBy(d => d.City);
        }
    }
}
