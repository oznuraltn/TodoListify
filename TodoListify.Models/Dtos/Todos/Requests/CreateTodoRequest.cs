
namespace TodoListify.Models.Dtos.Todos.Requests;

public sealed record CreateTodoRequest
    (
    string Title,
    string Description,
    int CategoryId,
    string UserId, //silmeli miyim?
    DateTime StartDate,
    DateTime EndDate
    );


