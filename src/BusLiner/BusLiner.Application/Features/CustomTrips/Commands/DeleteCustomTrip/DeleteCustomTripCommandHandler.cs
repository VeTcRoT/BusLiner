using BusLiner.Application.Exceptions;
using BusLiner.Domain.Entities;
using BusLiner.Domain.Interfaces.Repositories;
using MediatR;

namespace BusLiner.Application.Features.CustomTrips.Commands.DeleteCustomTrip
{
    public class DeleteCustomTripCommandHandler : IRequestHandler<DeleteCustomTripCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCustomTripCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteCustomTripCommand request, CancellationToken cancellationToken)
        {
            var customtrip = await _unitOfWork.CustomTripRepository.GetByIdAsync(request.Id);

            if (customtrip == null)
                throw new NotFoundException(nameof(CustomTrip), request.Id);

            _unitOfWork.CustomTripRepository.Delete(customtrip);

            await _unitOfWork.SaveAsync();
        }
    }
}
