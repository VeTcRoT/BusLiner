using MediatR;

namespace BusLiner.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest
    {
        public string Id { get; set; } = string.Empty;
    }
}
