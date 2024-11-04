
namespace TodoListify.Models.Dtos.Users.Responses;

public sealed record UserResponseDto
{
    public long Id { get; set; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public string Username { get; init; }
    public DateTime CreatedDate { get; set; }
}
