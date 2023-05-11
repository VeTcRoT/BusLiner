using AutoMapper;
using BusLiner.Application.Exceptions;
using BusLiner.Domain.Interfaces.Repositories;
using MediatR;

namespace BusLiner.Application.Features.Rides.Queries.GetRideById
{
    public class GetRideByIdQueryHandler : IRequestHandler<GetRideByIdQuery, GetRideByIdDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetRideByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetRideByIdDto> Handle(GetRideByIdQuery request, CancellationToken cancellationToken)
        {
            var ride = await _unitOfWork.RideRepository.GetByIdAsync(request.Id);

            if (ride == null) 
                throw new NotFoundException(nameof(ride), request.Id);

            return _mapper.Map<GetRideByIdDto>(ride);
        }
    }
}
