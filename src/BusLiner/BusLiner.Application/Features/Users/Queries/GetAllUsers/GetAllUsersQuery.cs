using MediatR;

namespace BusLiner.Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<IEnumerable<GetAllUsersDto>>
    {
    }
}
