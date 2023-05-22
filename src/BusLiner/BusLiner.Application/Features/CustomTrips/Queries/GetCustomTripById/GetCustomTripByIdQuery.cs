using BusLiner.Domain.Entities;
using MediatR;

namespace BusLiner.Application.Features.CustomTrips.Queries.GetCustomTripById
{
    public class GetCustomTripByIdQuery : IRequest<CustomTrip>
    {
        public int Id { get; set; }
    }
}
