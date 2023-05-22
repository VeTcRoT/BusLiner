using AutoMapper;
using BusLiner.Application.Exceptions;
using BusLiner.Domain.Entities;
using BusLiner.Domain.Interfaces.Repositories;
using MediatR;

namespace BusLiner.Application.Features.DeparturePlaces.Commands.UpdateDeparturePlace
{
    public class UpdateDeparturePlaceCommandHandler : IRequestHandler<UpdateDeparturePlaceCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDeparturePlaceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(UpdateDeparturePlaceCommand request, CancellationToken cancellationToken)
        {
            var depPlace = await _unitOfWork.DeparturePlaceRepository.GetByIdAsync(request.Id);

            if (depPlace == null)
                throw new NotFoundException(nameof(DeparturePlace), request.Id);

            _mapper.Map(request, depPlace, typeof(UpdateDeparturePlaceCommand), typeof(DeparturePlace));

            await _unitOfWork.SaveAsync();
        }
    }
}
