using BusLiner.Domain.Entities;
using MediatR;

namespace BusLiner.Application.Features.Orders.Queries.GetUserRidesByEmail
{
    public class GetUserRidesByEmailQuery : IRequest<IEnumerable<GetUserRidesByEmailDto>?>
    {
        public string Email { get; set; } = string.Empty;
    }
}
