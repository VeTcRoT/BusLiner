using MediatR;

namespace BusLiner.Application.Features.ArrivalPlaces.Queries.ListAllArrivalPlaces
{
    public class ListAllArrivalPlacesQuery : IRequest<IEnumerable<ListAllArrivalPlacesDto>>
    {
    }
}
