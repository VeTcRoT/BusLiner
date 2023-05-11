using BusLiner.Domain.Entities;

namespace BusLiner.MVC.ViewModel
{
    public class TicketsVM
    {
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public DateTime DepartureDate { get; set; }
        public IEnumerable<Ride> Rides { get; set; } = null!;
    }
}
