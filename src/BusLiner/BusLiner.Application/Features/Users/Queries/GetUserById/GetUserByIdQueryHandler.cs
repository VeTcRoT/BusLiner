using AutoMapper;
using BusLiner.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BusLiner.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdDto>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<GetUserByIdDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);

            if (user == null)
                throw new NotFoundException(nameof(IdentityUser), request.Id);

            string rolename = (await _userManager.GetRolesAsync(user)).FirstOrDefault();

            var userDto = _mapper.Map<GetUserByIdDto>(user);
            userDto.Role = rolename;

            return userDto;
        }
    }
}
