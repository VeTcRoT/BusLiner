using AutoMapper;
using BusLiner.Application.Exceptions;
using BusLiner.Domain.Entities;
using BusLiner.Domain.Interfaces.Repositories;
using MediatR;

namespace BusLiner.Application.Features.Rides.Queries.GetRidesByOptions
{
    public class GetRidesByOptionsQueryHandler : IRequestHandler<GetRidesByOptionsQuery, IEnumerable<Ride>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetRidesByOptionsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Ride>> Handle(GetRidesByOptionsQuery request, CancellationToken cancellationToken)
        {
            var rides = await _unitOfWork.RideRepository.GetRidesByQueryAsync(request.From, request.To, request.DepartureDate);

            if (rides == null)
                throw new NotFoundException(nameof(Ride), new { From = request.From, To = request.To, DepartureDate = request.DepartureDate });

            return rides;
        }
    }
}
