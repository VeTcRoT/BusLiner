using MediatR;

namespace BusLiner.Application.Features.CustomTrips.Commands.DeleteCustomTrip
{
    public class DeleteCustomTripCommand : IRequest
    {
        public int Id { get; set; }
    }
}
