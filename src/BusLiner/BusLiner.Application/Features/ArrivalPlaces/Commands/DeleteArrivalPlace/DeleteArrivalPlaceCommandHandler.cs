using BusLiner.Application.Exceptions;
using BusLiner.Domain.Entities;
using BusLiner.Domain.Interfaces.Repositories;
using MediatR;

namespace BusLiner.Application.Features.ArrivalPlaces.Commands.DeleteArrivalPlace
{
    public class DeleteArrivalPlaceCommandHandler : IRequestHandler<DeleteArrivalPlaceCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteArrivalPlaceCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteArrivalPlaceCommand request, CancellationToken cancellationToken)
        {
            var arrPlace = await _unitOfWork.ArrivalPlaceRepository.GetByIdAsync(request.Id);

            if (arrPlace == null)
                throw new NotFoundException(nameof(ArrivalPlace), request.Id);

            _unitOfWork.ArrivalPlaceRepository.Delete(arrPlace);

            await _unitOfWork.SaveAsync();
        }
    }
}
