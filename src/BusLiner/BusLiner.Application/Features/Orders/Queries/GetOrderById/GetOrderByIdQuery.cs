using BusLiner.Domain.Entities;
using MediatR;

namespace BusLiner.Application.Features.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<Order>
    {
        public int Id { get; set; }
    }
}
