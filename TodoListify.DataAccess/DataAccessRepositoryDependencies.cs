

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System;
using TodoListify.DataAccess.Abstracts;
using TodoListify.DataAccess.Concretes;
using TodoListify.DataAccess.Contexts;

namespace TodoListify.DataAccess;

public static class DataAccessRepositoryDependencies
{
    public static IServiceCollection AddDataAccessDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITodoRepository, EfTodoRepository>();
        services.AddScoped<ICategoryRepository, EfCategoryRepository>();
        services.AddDbContext<BaseDbContext>(opt => {
            opt.UseSqlServer(configuration.GetConnectionString("SqlConnection"), options =>
            {
                options.MigrationsAssembly(Assembly.GetAssembly(typeof(BaseDbContext)).GetName().Name);
            });
        
        
        });
        return services;
    }
}
