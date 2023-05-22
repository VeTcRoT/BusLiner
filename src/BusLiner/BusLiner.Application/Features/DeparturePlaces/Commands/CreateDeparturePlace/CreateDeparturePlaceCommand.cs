using MediatR;

namespace BusLiner.Application.Features.DeparturePlaces.Commands.CreateDeparturePlace
{
    public class CreateDeparturePlaceCommand : IRequest
    {
        public string City { get; set; } = string.Empty;
        public string Station { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
    }
}
