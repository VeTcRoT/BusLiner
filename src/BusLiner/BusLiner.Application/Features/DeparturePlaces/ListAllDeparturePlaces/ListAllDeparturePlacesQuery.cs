using MediatR;

namespace BusLiner.Application.Features.DeparturePlaces.ListAllDeparturePlaces
{
    public class ListAllDeparturePlacesQuery : IRequest<IEnumerable<ListAllDeparturePlacesDto>>
    {
    }
}
