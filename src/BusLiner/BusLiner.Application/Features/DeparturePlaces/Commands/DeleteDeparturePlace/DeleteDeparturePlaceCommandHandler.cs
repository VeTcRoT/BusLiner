using BusLiner.Application.Exceptions;
using BusLiner.Domain.Entities;
using BusLiner.Domain.Interfaces.Repositories;
using MediatR;

namespace BusLiner.Application.Features.DeparturePlaces.Commands.DeleteDeparturePlace
{
    public class DeleteDeparturePlaceCommandHandler : IRequestHandler<DeleteDeparturePlaceCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDeparturePlaceCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteDeparturePlaceCommand request, CancellationToken cancellationToken)
        {
            var depPlace = await _unitOfWork.DeparturePlaceRepository.GetByIdAsync(request.Id);

            if (depPlace == null)
                throw new NotFoundException(nameof(DeparturePlace), request.Id);

            _unitOfWork.DeparturePlaceRepository.Delete(depPlace);

            await _unitOfWork.SaveAsync();
        }
    }
}
