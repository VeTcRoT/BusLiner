using AutoMapper;
using BusLiner.Domain.Entities;
using BusLiner.Domain.Interfaces.Repositories;
using MediatR;

namespace BusLiner.Application.Features.DeparturePlaces.Commands.CreateDeparturePlace
{
    public class CreateDeparturePlaceCommandHandler : IRequestHandler<CreateDeparturePlaceCommand>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateDeparturePlaceCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateDeparturePlaceCommand request, CancellationToken cancellationToken)
        {
            var depPalce = _mapper.Map<DeparturePlace>(request);

            await _unitOfWork.DeparturePlaceRepository.AddAsync(depPalce);

            await _unitOfWork.SaveAsync();
        }
    }
}
