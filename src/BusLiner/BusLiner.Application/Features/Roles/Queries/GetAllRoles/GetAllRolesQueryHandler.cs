using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BusLiner.Application.Features.Roles.Queries.GetAllRoles
{
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, IEnumerable<GetAllRolesDto>>
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public GetAllRolesQueryHandler(RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public Task<IEnumerable<GetAllRolesDto>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = _roleManager.Roles.ToList();

            return Task.FromResult(_mapper.Map<IEnumerable<GetAllRolesDto>>(roles));
        }
    }
}
