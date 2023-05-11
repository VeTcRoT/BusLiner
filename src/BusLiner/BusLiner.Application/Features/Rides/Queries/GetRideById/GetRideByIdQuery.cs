using BusLiner.Domain.Entities;
using MediatR;

namespace BusLiner.Application.Features.Rides.Queries.GetRideById
{
    public class GetRideByIdQuery : IRequest<GetRideByIdDto>
    {
        public int Id { get; set; }
    }
}
