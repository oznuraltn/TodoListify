

namespace TodoListify.Models.Dtos.Users.Requests;

public sealed record UserUpdateRequestDto
    (
    string FirstName,
    string LastName,
    string City,
    string UserName
    );
