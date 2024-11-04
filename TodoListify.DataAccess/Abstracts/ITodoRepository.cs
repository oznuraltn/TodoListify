
using Core.Repositories;
using TodoListify.Models.Entities;

namespace TodoListify.DataAccess.Abstracts;

public interface ITodoRepository : IRepository<Todo, Guid>
{
}

