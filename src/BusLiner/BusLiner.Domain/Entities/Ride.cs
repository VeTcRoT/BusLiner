namespace BusLiner.Domain.Entities
{
    public class Ride
    {
        public int Id { get; set; }
        public int TicketsAvailable { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public double Price { get; set; }
        public int DeparturePlaceId { get; set; }
        public DeparturePlace DeparturePlace { get; set; } = null!; 
        public int ArrivalPlaceId { get; set; }
        public ArrivalPlace ArrivalPlace { get; set; } = null!;
    }
}
