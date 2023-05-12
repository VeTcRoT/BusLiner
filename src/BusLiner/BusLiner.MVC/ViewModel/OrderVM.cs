using BusLiner.Application.Features.Orders.Commands.CreateOrder;
using BusLiner.Domain.Entities;

namespace BusLiner.MVC.ViewModel
{
    public class OrderVM
    {
        public Ride Ride { get; set; } = null!;
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
