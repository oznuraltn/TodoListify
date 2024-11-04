
namespace TodoListify.Models.Dtos.Todos.Requests;

public sealed record UpdateTodoRequest
    (
    Guid Id,
    string Title,
    string Description,
    int CategoryId,
    DateTime StartDate,
    DateTime EndDate
    );


