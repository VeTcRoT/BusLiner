using MediatR;

namespace BusLiner.Application.Features.ArrivalPlaces.Commands.CreateArrivalPlace
{
    public class CreateArrivalPlaceCommand : IRequest
    {
        public string City { get; set; } = string.Empty;
        public string Station { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
    }
}
