using MediatR;

namespace BusLiner.Application.Features.DeparturePlaces.Commands.UpdateDeparturePlace
{
    public class UpdateDeparturePlaceCommand : IRequest
    {
        public int Id { get; set; }
        public string City { get; set; } = string.Empty;
        public string Station { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
    }
}
