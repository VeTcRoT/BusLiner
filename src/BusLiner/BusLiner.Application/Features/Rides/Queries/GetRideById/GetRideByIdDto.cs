using BusLiner.Domain.Entities;

namespace BusLiner.Application.Features.Rides.Queries.GetRideById
{
    public class GetRideByIdDto
    {
        public int TicketsAvailable { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public double Price { get; set; }
        public DeparturePlace DeparturePlace { get; set; } = null!;
        public ArrivalPlace ArrivalPlace { get; set; } = null!;
    }
}
