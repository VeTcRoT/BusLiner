using MediatR;

namespace BusLiner.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<GetUserByIdDto>
    {
        public string Id { get; set; } = string.Empty;
    }
}
