using DAL.Models;
using Microsoft.Data.Entity;
using Repository.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repository.Implementation
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal NorthwindContextBase context;
        internal DbSet<TEntity> _dbSet;

        public GenericRepository(NorthwindContextBase context)
        {
            this.context = context;
            this._dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] tables)
        {
            IQueryable<TEntity> query = _dbSet;

            if(filter != null)
            {
                query = query.Where(filter);
            }

            if(tables != null)
            {
                foreach(var table in tables)
                {
                    query.Include(table);
                }
            }

            if(orderBy != null)
            {
                return orderBy(query).ToList();
            }

            return query.ToList();
        }

        public virtual TEntity GetById(Expression<Func<TEntity, bool>> byIdFilter)
        {
            return _dbSet.FirstOrDefault(byIdFilter);
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> deleteFilter)
        {
            TEntity entityToDelete = _dbSet.FirstOrDefault(deleteFilter);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if(context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }

            _dbSet.Remove(entityToDelete);
        }

        public virtual void Delete(List<TEntity> entitesToDelete)
        {
            foreach(var ent in entitesToDelete)
            {
                if(context.Entry(ent).State == EntityState.Deleted)
                _dbSet.Attach(ent);
            }
            _dbSet.RemoveRange(entitesToDelete);
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
