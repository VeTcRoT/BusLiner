using BusLiner.Domain.Entities;
using MediatR;

namespace BusLiner.Application.Features.CustomTrips.Queries.GetAllCustomTrips
{
    public class GetAllCustomTripsQuery : IRequest<IEnumerable<CustomTrip>>
    {
    }
}
