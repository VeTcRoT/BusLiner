using BusLiner.Domain.Entities;
using MediatR;

namespace BusLiner.Application.Features.Rides.Queries.GetAllRides
{
    public class GetAllRidesQuery : IRequest<IEnumerable<Ride>>
    {
    }
}
