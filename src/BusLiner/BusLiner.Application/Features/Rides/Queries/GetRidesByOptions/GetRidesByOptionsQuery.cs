using BusLiner.Application.Features.Rides.Queries.GetRideById;
using MediatR;

namespace BusLiner.Application.Features.Rides.Queries.GetRidesByOptions
{
    public class GetRidesByOptionsQuery : IRequest<IEnumerable<GetRideByIdDto>>
    {
        public string From { get; set; }
        public string To { get; set; }
        public DateOnly DepartureDate { get; set; }
    }
}
