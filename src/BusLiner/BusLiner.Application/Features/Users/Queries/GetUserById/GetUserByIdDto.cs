namespace BusLiner.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdDto
    {
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool EmailConfirmed { get; set; }
        public string? Role { get; set; }
        public string? Password { get; set; }
    }
}
