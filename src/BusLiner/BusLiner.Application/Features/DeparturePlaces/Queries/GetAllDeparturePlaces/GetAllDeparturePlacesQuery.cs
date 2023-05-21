using MediatR;

namespace BusLiner.Application.Features.DeparturePlaces.Queries.GetAllDeparturePlaces
{
    public class GetAllDeparturePlacesQuery : IRequest<IEnumerable<GetAllDeparturePlacesDto>>
    {
    }
}
