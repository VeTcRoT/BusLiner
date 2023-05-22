using BusLiner.Domain.Entities;
using MediatR;

namespace BusLiner.Application.Features.DeparturePlaces.Queries.GetDeparturePlaceById
{
    public class GetDeparturePlaceByIdQuery : IRequest<DeparturePlace>
    {
        public int Id { get; set; }
    }
}
