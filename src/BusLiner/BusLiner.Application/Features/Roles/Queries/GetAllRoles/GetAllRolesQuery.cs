using MediatR;
using System.Collections;

namespace BusLiner.Application.Features.Roles.Queries.GetAllRoles
{
    public class GetAllRolesQuery : IRequest<IEnumerable<GetAllRolesDto>>
    {
    }
}
