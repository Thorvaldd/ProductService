using DAL.Models;
using Repository.Implementation;
using System;
using System.Collections.Concurrent;

namespace Repository.Interfaces
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        private NorthwindContextBase _context;
        private ConcurrentDictionary<string, object> _repositories;

        public UnitOfWork()
        {
            _context = new NorthwindContextBase();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if(_repositories == null)
                _repositories = new ConcurrentDictionary<string, object>();

                var type = typeof(TEntity).Name;

                if (!_repositories.ContainsKey(type))
                {
                    var repotype = typeof(GenericRepository<>);
                    var repoInstance = Activator.CreateInstance(repotype.MakeGenericType(typeof(TEntity)),
                        _context);

                    _repositories.TryAdd(type, repoInstance);
                }

                return (GenericRepository<TEntity>)_repositories[type];
            
        }



       

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
