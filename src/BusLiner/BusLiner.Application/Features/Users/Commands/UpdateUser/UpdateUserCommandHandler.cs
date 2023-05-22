using BusLiner.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BusLiner.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserStore<IdentityUser> _userStore;
        private IUserEmailStore<IdentityUser> _emailStore;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UpdateUserCommandHandler(UserManager<IdentityUser> userManager, IUserStore<IdentityUser> userStore, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = (IUserEmailStore<IdentityUser>)userStore;
            _roleManager = roleManager;
        }

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);

            if (user == null)
                throw new NotFoundException(nameof(user), request.Id);

            if (user.Email != request.Email)
            {
                await _userStore.SetUserNameAsync(user, request.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, request.Email, CancellationToken.None);
            }

            user.EmailConfirmed = request.EmailConfirmed == 1 ? true : false;

            await _userManager.UpdateAsync(user);

            var userRole = (await _userManager.GetRolesAsync(user)).FirstOrDefault();

            if (userRole != request.Role) 
            {
                var role = _roleManager.FindByNameAsync(request.Role).Result;

                if (role != null)
                {
                    await _userManager.AddToRoleAsync(user, role.Name);
                }
            }
        }
    }
}
