namespace Dasigno.Domain.Interfaces.Persistence;

public interface IUnitOfWork : IDisposable
{
    void Rollback();

    void Save();

    Task SaveAsync(CancellationToken cancellationToken = default);
}