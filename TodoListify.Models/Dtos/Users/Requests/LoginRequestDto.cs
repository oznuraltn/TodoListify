

namespace TodoListify.Models.Dtos.Users.Requests;

public sealed record LoginRequestDto
    (
    string Email,
    string Password
    );

