using AutoMapper;
using BusLiner.Application.Exceptions;
using BusLiner.Domain.Entities;
using BusLiner.Domain.Interfaces.Repositories;
using MediatR;

namespace BusLiner.Application.Features.Rides.Commands.UpdateRide
{
    public class UpdateRideCommandHandler : IRequestHandler<UpdateRideCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateRideCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(UpdateRideCommand request, CancellationToken cancellationToken)
        {
            var ride = await _unitOfWork.RideRepository.GetByIdAsync(request.Id);

            if (ride == null) 
                throw new NotFoundException(nameof(Ride), request.Id);

            _mapper.Map(request, ride, typeof(UpdateRideCommand), typeof(Ride));

            await _unitOfWork.SaveAsync();
        }
    }
}
