using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repository.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includeProperties);
        TEntity GetById(Expression<Func<TEntity, bool>> byIdFilter);
        void Insert(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> deleteFilter);
        void Delete(TEntity entityToDelete);
        void Delete(List<TEntity> entitesToDelete);
        void Update(TEntity entity);
    }
}
