using BusLiner.Application.Features.Rides.Queries.GetRideById;
using MediatR;

namespace BusLiner.Application.Features.Rides.Queries.GetRidesByOptions
{
    public class GetRidesByOptionsQuery : IRequest<IEnumerable<GetRideByIdDto>>
    {
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public DateOnly DepartureDate { get; set; }
    }
}
