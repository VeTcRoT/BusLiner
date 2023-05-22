using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BusLiner.Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<GetAllUsersDto>>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllUsersDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var identityUsers = _userManager.Users.ToList();

            List<GetAllUsersDto> users = _mapper.Map<List<GetAllUsersDto>>(identityUsers);

            foreach (var user in users)
            {
                var identityUser = await _userManager.FindByIdAsync(user.Id);

                var roles = await _userManager.GetRolesAsync(identityUser);

                user.Role = roles.FirstOrDefault();
            }

            return users;
        }

    }
}
