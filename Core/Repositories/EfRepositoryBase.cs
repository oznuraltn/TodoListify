﻿
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories;

public class EfRepositoryBase<TContext, TEntity, TId> : IRepository<TEntity, TId>
    where TEntity : Entity<TId>, new()
    where TContext : DbContext
{
    protected TContext Context { get; }
    public EfRepositoryBase(TContext context)
    {
        Context = context;
    }

    public TEntity Add(TEntity entity)
    {
        if (entity is BaseEntityWithDates<TId> entityWithDates)
        {
            entityWithDates.CreatedDate = DateTime.Now;
        }

        Context.Set<TEntity>().Add(entity);
        Context.SaveChanges();
        return entity;
    }

    public List<TEntity> GetAll()
    {
        throw new NotImplementedException();
    }

    public TEntity? GetById(TId id)
    {
        return Context.Set<TEntity>().Find(id);
    }

    public TEntity Remove(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
        Context.SaveChanges();
        return entity;
    }

    public TEntity Update(TEntity entity)
    {
        if (entity is BaseEntityWithDates<Guid> baseEntityWithDates)
        {
            baseEntityWithDates.UpdatedDate = DateTime.Now;
        }

        Context.Set<TEntity>().Update(entity);
        Context.SaveChanges();
        return entity;
    }
}