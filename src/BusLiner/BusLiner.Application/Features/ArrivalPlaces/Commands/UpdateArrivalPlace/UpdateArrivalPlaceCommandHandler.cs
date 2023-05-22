using AutoMapper;
using BusLiner.Application.Exceptions;
using BusLiner.Domain.Entities;
using BusLiner.Domain.Interfaces.Repositories;
using MediatR;

namespace BusLiner.Application.Features.ArrivalPlaces.Commands.UpdateArrivalPlace
{
    public class UpdateArrivalPlaceCommandHandler : IRequestHandler<UpdateArrivalPlaceCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateArrivalPlaceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(UpdateArrivalPlaceCommand request, CancellationToken cancellationToken)
        {
            var arrPlace = await _unitOfWork.ArrivalPlaceRepository.GetByIdAsync(request.Id);

            if (arrPlace == null)
                throw new NotFoundException(nameof(ArrivalPlace), request.Id);

            _mapper.Map(request, arrPlace, typeof(UpdateArrivalPlaceCommand), typeof(ArrivalPlace));

            await _unitOfWork.SaveAsync();
        }
    }
}
