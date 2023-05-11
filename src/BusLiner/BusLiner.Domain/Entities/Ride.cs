namespace BusLiner.Domain.Entities
{
    public class Ride
    {
        public int Id { get; set; }
        public int TicketsAvailable { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public double Price { get; set; }
        public DeparturePlace DeparturePlace { get; set; } = null!;
        public ArrivalPlace ArrivalPlace { get; set; } = null!;
    }
}
