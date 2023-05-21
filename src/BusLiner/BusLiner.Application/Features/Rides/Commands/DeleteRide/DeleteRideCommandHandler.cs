using BusLiner.Application.Exceptions;
using BusLiner.Domain.Entities;
using BusLiner.Domain.Interfaces.Repositories;
using MediatR;

namespace BusLiner.Application.Features.Rides.Commands.DeleteRide
{
    public class DeleteRideCommandHandler : IRequestHandler<DeleteRideCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRideCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteRideCommand request, CancellationToken cancellationToken)
        {
            var rideToDelete = await _unitOfWork.RideRepository.GetByIdAsync(request.RideId);

            if (rideToDelete == null) 
                throw new NotFoundException(nameof(Ride), request.RideId);

            _unitOfWork.RideRepository.Delete(rideToDelete);

            await _unitOfWork.SaveAsync();
        }
    }
}
