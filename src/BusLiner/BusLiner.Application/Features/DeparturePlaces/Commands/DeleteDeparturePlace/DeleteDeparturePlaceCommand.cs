using MediatR;

namespace BusLiner.Application.Features.DeparturePlaces.Commands.DeleteDeparturePlace
{
    public class DeleteDeparturePlaceCommand : IRequest
    {
        public int Id { get; set; }
    }
}
