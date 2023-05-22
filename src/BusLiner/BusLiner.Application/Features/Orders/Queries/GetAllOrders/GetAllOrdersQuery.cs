using BusLiner.Domain.Entities;
using MediatR;

namespace BusLiner.Application.Features.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQuery : IRequest<IEnumerable<Order>>
    {
    }
}
