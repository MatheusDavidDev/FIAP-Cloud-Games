using FCG.Core.Repository;

namespace FCG.Core.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChanges();

    IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
}
