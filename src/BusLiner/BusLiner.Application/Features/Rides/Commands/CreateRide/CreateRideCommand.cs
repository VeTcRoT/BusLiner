using BusLiner.Domain.Entities;
using MediatR;

namespace BusLiner.Application.Features.Rides.Commands.CreateRide
{
    public class CreateRideCommand : IRequest
    {
        public int TicketsAvailable { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public double Price { get; set; }
        public int DeparturePlaceId { get; set; }
        public int ArrivalPlaceId { get; set; }
    }
}
