using AutoMapper;
using BusLiner.Application.Exceptions;
using BusLiner.Domain.Entities;
using BusLiner.Domain.Interfaces.Repositories;
using MediatR;

namespace BusLiner.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderQueryHandler : IRequestHandler<CreateOrderQuery>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOrderQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(CreateOrderQuery request, CancellationToken cancellationToken)
        {
            var validator = new CreateOrderQueryValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            var mappedRequest = _mapper.Map<Order>(request);

            await _unitOfWork.OrderRepository.AddAsync(mappedRequest);

            await _unitOfWork.SaveAsync();
        }
    }
}
