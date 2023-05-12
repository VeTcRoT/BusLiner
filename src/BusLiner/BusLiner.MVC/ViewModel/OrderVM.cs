using BusLiner.Application.Features.Orders.Commands.CreateOrder;
using BusLiner.Domain.Entities;

namespace BusLiner.MVC.ViewModel
{
    public class OrderVM
    {
        public Ride Ride { get; set; } = null!;
        public CreateOrderQuery Order { get; set; } = null!;
    }
}
