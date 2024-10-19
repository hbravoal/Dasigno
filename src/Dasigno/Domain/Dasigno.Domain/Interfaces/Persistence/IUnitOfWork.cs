namespace Dasigno.Domain.Interfaces.Persistence;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }

    void Rollback();

    void Save();

    Task SaveAsync(CancellationToken cancellationToken = default);
}