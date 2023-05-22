using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BusLiner.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserStore<IdentityUser> _userStore;
        private IUserEmailStore<IdentityUser> _emailStore;
        private readonly RoleManager<IdentityRole> _roleManager;
        public CreateUserCommandHandler(UserManager<IdentityUser> userManager, IUserStore<IdentityUser> userStore, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = (IUserEmailStore<IdentityUser>)userStore;
            _roleManager = roleManager;
        }

        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        { 
            var user = new IdentityUser();

            await _userStore.SetUserNameAsync(user, request.Email, CancellationToken.None);
            await _emailStore.SetEmailAsync(user, request.Email, CancellationToken.None);
            
            user.EmailConfirmed = request.EmailConfirmed == 1 ? true : false;
            
            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                var role = _roleManager.FindByNameAsync(request.Role).Result;

                if (role != null)
                {
                    await _userManager.AddToRoleAsync(user, role.Name);
                }
            }
            else
                throw new Exception("Cannot create a user.");
        }
    }
}
