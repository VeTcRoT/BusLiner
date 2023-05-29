using MediatR;

namespace BusLiner.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest
    {
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int EmailConfirmed { get; set; }
        public string Role { get; set; } = string.Empty;
        public string? Password { get; set; }
    }
}
