using AutoMapper;
using BusLiner.Domain.Entities;
using BusLiner.Domain.Interfaces.Repositories;
using MediatR;

namespace BusLiner.Application.Features.Rides.Commands.CreateRide
{
    public class CreateRideCommandHandler : IRequestHandler<CreateRideCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateRideCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(CreateRideCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.RideRepository.AddAsync(_mapper.Map<Ride>(request));

            await _unitOfWork.SaveAsync();
        }
    }
}
