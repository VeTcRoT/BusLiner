using MediatR;

namespace BusLiner.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderQuery : IRequest
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int TicketsOrdered { get; set; }
        public int AdditionalBaggage { get; set; }
        public double Total { get; set; }
        public int RideId { get; set; }
    }
}
