using MediatR;

namespace BusLiner.Application.Features.DeparturePlaces.Queries.ListAllDeparturePlaces
{
    public class ListAllDeparturePlacesQuery : IRequest<IEnumerable<ListAllDeparturePlacesDto>>
    {
    }
}
