using BusLiner.Application.Features.Rides.Queries.GetRideById;
using BusLiner.Domain.Entities;
using MediatR;

namespace BusLiner.Application.Features.Rides.Queries.GetRidesByOptions
{
    public class GetRidesByOptionsQuery : IRequest<IEnumerable<Ride>>
    {
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public DateOnly DepartureDate { get; set; }
    }
}
