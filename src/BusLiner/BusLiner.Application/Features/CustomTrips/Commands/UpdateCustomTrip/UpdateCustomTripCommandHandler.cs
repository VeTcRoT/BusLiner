using AutoMapper;
using BusLiner.Application.Exceptions;
using BusLiner.Domain.Entities;
using BusLiner.Domain.Interfaces.Repositories;
using MediatR;

namespace BusLiner.Application.Features.CustomTrips.Commands.UpdateCustomTrip
{
    public class UpdateCustomTripCommandHandler : IRequestHandler<UpdateCustomTripCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCustomTripCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(UpdateCustomTripCommand request, CancellationToken cancellationToken)
        {
            var customTrip = await _unitOfWork.CustomTripRepository.GetByIdAsync(request.Id);

            if (customTrip == null)
                throw new NotFoundException(nameof(CustomTrip), request.Id);

            _mapper.Map(request, customTrip, typeof(UpdateCustomTripCommand), typeof(CustomTrip));

            await _unitOfWork.SaveAsync();
        }
    }
}
