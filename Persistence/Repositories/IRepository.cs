using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RestApi.Persistence.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        // Get
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includes);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        
        // Add/Modify
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        // Delete
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        void SaveChanges();
    }
}