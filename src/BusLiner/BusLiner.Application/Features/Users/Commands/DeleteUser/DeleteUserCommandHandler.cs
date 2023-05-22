using BusLiner.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BusLiner.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public DeleteUserCommandHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);

            if (user == null)
                throw new NotFoundException(nameof(user), request.Id);

            await _userManager.DeleteAsync(user);
        }
    }
}
