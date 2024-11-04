
using Core.Repositories;
using TodoListify.DataAccess.Abstracts;
using TodoListify.DataAccess.Contexts;
using TodoListify.Models.Entities;

namespace TodoListify.DataAccess.Concretes;

public class EfCategoryRepository : EfRepositoryBase<BaseDbContext, Category, int>, ICategoryRepository
{
    public EfCategoryRepository(BaseDbContext context) : base(context)
    {
    }
}
