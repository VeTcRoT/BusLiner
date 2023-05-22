using AutoMapper;
using BusLiner.Application.Exceptions;
using BusLiner.Domain.Entities;
using BusLiner.Domain.Interfaces.Repositories;
using MediatR;

namespace BusLiner.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var rideToChange = await _unitOfWork.RideRepository.GetRideByIdAsync(request.RideId);

            if (rideToChange == null)
                throw new NotFoundException(nameof(Ride), request.RideId);

            var order = await _unitOfWork.OrderRepository.GetByIdAsync(request.Id);

            if(order == null) 
                throw new NotFoundException(nameof(Order), request.Id);

            var ticketsToRemove = request.TicketsOrdered - order.TicketsOrdered;

            rideToChange.TicketsAvailable -= ticketsToRemove;

            _mapper.Map(request, order, typeof(UpdateOrderCommand), typeof(Order));

            await _unitOfWork.SaveAsync();
        }
    }
}
