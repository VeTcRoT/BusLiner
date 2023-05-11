using BusLiner.Domain.Entities;
using MediatR;

namespace BusLiner.Application.Features.Rides.Queries.GetTopFiveRides
{
    public class GetTopFiveRidesQuery : IRequest<IEnumerable<Ride>>
    {
    }
}
