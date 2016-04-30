using System;

namespace Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();

        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
    }
}
