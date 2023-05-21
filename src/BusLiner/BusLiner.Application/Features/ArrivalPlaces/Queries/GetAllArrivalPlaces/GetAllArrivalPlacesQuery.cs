using MediatR;

namespace BusLiner.Application.Features.ArrivalPlaces.Queries.GetAllArrivalPlaces
{
    public class GetAllArrivalPlacesQuery : IRequest<IEnumerable<GetAllArrivalPlacesDto>>
    {
    }
}
