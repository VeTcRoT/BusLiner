using MediatR;

namespace BusLiner.Application.Features.Rides.Commands.DeleteRide
{
    public class DeleteRideCommand : IRequest
    {
        public int RideId { get; set; }
    }
}
