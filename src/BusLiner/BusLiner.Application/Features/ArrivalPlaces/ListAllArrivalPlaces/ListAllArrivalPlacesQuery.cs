using MediatR;

namespace BusLiner.Application.Features.ArrivalPlaces.ListAllArrivalPlaces
{
    public class ListAllArrivalPlacesQuery : IRequest<IEnumerable<ListAllArrivalPlacesDto>>
    {
    }
}
