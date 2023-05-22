using AutoMapper;
using BusLiner.Domain.Entities;
using BusLiner.Domain.Interfaces.Repositories;
using MediatR;

namespace BusLiner.Application.Features.ArrivalPlaces.Commands.CreateArrivalPlace
{
    public class CreateArrivalPlaceCommandHandler :IRequestHandler<CreateArrivalPlaceCommand>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateArrivalPlaceCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateArrivalPlaceCommand request, CancellationToken cancellationToken)
        {
            var arrPlace = _mapper.Map<ArrivalPlace>(request);

            await _unitOfWork.ArrivalPlaceRepository.AddAsync(arrPlace);

            await _unitOfWork.SaveAsync();
        }
    }
}
