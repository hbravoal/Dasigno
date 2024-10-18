using Dasigno.Domain.Interfaces.Entities;

namespace Dasigno.Domain.Interfaces.Persistence.Common;

public interface IGenericRepository<TEntity, TId> : IRepositoryBase<TEntity, TId>
    where TEntity : class, IEntity<TId>
    where TId : struct
{
}