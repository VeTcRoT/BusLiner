using MediatR;

namespace BusLiner.Application.Features.ArrivalPlaces.Commands.DeleteArrivalPlace
{
    public class DeleteArrivalPlaceCommand : IRequest
    {
        public int Id { get; set; }
    }
}
