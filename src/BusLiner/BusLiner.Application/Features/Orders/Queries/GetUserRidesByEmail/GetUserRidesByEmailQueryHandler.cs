using AutoMapper;
using BusLiner.Domain.Entities;
using BusLiner.Domain.Interfaces.Repositories;
using MediatR;

namespace BusLiner.Application.Features.Orders.Queries.GetUserRidesByEmail
{
    public class GetUserRidesByEmailQueryHandler : IRequestHandler<GetUserRidesByEmailQuery, IEnumerable<GetUserRidesByEmailDto>?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUserRidesByEmailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetUserRidesByEmailDto>?> Handle(GetUserRidesByEmailQuery request, CancellationToken cancellationToken)
        {
            var userOrders = await _unitOfWork.OrderRepository.GetAllUserOrdersAsync(request.Email);

            var userRides = new List<GetUserRidesByEmailDto>();

            if (userOrders != null)
            {
                foreach (var order in userOrders)
                {
                    userRides.Add(_mapper.Map<GetUserRidesByEmailDto>(order.Ride));
                    userRides.Last().Total = order.Total;
                    userRides.Last().TicketsOrdered = order.TicketsOrdered;
                }
            }

            return userRides;
        }
    }
}
