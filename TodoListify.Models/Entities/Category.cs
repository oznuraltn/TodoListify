
using Core.Entities;

namespace TodoListify.Models.Entities;

public sealed class Category : Entity<int>
{
    public string Name { get; set; }
    public List<Todo> Todos { get; set; }
}
