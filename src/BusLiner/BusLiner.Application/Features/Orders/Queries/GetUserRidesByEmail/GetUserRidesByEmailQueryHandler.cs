using BusLiner.Domain.Entities;
using BusLiner.Domain.Interfaces.Repositories;
using MediatR;

namespace BusLiner.Application.Features.Orders.Queries.GetUserRidesByEmail
{
    public class GetUserRidesByEmailQueryHandler : IRequestHandler<GetUserRidesByEmailQuery, IEnumerable<Ride>?>
    {
        private readonly IOrderRepository _orderRepository;

        public GetUserRidesByEmailQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Ride>?> Handle(GetUserRidesByEmailQuery request, CancellationToken cancellationToken)
        {
            var userRides = await _orderRepository.GetAllUserRidesAsync(request.Email);

            return userRides;
        }
    }
}
