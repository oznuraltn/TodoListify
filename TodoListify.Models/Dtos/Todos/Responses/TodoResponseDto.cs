
namespace TodoListify.Models.Dtos.Todos.Responses;

public sealed record TodoResponseDto
{
    public string Title { get; init; }
    public string Description { get; init; }
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public DateTime CreatedDate { get; init; }
    public int Category { get; init; }
    public string UserName { get; init; }
    public bool Completed { get; init; }

}
