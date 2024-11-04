

using Core.Repositories;
using TodoListify.DataAccess.Abstracts;
using TodoListify.DataAccess.Contexts;
using TodoListify.Models.Entities;

namespace TodoListify.DataAccess.Concretes;

public class EfTodoRepository : EfRepositoryBase<BaseDbContext, Todo, Guid>, ITodoRepository
{
    public EfTodoRepository(BaseDbContext context) : base(context)
    {
    }
}

