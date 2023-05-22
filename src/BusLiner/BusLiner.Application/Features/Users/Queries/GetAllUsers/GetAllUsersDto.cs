namespace BusLiner.Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersDto
    {
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool EmailConfirmed { get; set; }
        public string? Role { get; set; }
    }
}
