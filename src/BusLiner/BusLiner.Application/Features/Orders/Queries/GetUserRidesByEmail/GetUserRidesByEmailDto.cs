using BusLiner.Domain.Entities;

namespace BusLiner.Application.Features.Orders.Queries.GetUserRidesByEmail
{
    public class GetUserRidesByEmailDto
    {
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int TicketsOrdered { get; set; }
        public double Total { get; set; }
        public DeparturePlace DeparturePlace { get; set; } = null!;
        public ArrivalPlace ArrivalPlace { get; set; } = null!;
    }
}
