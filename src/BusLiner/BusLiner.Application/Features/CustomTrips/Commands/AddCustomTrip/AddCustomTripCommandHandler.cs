using AutoMapper;
using BusLiner.Application.Exceptions;
using BusLiner.Domain.Interfaces.Repositories;
using MediatR;
using BusLiner.Domain.Entities;

namespace BusLiner.Application.Features.CustomTrips.Commands.AddCustomTrip
{
    public class AddCustomTripCommandHandler : IRequestHandler<AddCustomTripCommand>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AddCustomTripCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(AddCustomTripCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddCustomTripCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            await _unitOfWork.CustomTripRepository.AddAsync(_mapper.Map<CustomTrip>(request));

            await _unitOfWork.SaveAsync();
        }
    }
}
