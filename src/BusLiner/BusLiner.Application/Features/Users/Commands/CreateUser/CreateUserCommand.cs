using MediatR;

namespace BusLiner.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int EmailConfirmed { get; set; }
        public string Role { get; set; } = string.Empty;
    }
}
