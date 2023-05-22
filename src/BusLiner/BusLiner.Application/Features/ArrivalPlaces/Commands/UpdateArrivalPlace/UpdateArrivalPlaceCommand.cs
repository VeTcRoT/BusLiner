using MediatR;

namespace BusLiner.Application.Features.ArrivalPlaces.Commands.UpdateArrivalPlace
{
    public class UpdateArrivalPlaceCommand : IRequest
    {
        public int Id { get; set; }
        public string City { get; set; } = string.Empty;
        public string Station { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
    }
}
