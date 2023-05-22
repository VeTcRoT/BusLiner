using BusLiner.Domain.Entities;
using MediatR;

namespace BusLiner.Application.Features.ArrivalPlaces.Queries.GetArrivalPlaceById
{
    public class GetArrivalPlaceByIdQuery : IRequest<ArrivalPlace>
    {
        public int Id { get; set; }
    }
}
