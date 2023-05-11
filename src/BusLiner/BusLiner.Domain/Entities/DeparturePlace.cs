namespace BusLiner.Domain.Entities
{
    public class DeparturePlace
    {
        public int Id { get; set; }
        public string City { get; set; } = string.Empty;
        public string Station { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public ICollection<Ride> Rides { get; set; } = new List<Ride>();
    }
}
