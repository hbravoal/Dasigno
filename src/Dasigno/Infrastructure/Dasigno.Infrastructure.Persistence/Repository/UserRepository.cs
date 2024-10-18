using Dasigno.Domain.Interfaces.Persistence;
using Dasigno.Infrastructure.Persistence.Context;
using Dasigno.Infrastructure.Persistence.Repository.Common;


namespace Dasigno.Infrastructure.Persistence.Repository;

/// <summary>
/// Broker repository
/// </summary>
public class UserRepository : GenericRepository<Domain.Entities.User, int>, IUserRepository
{
    public UserRepository(UserContext context) : base(context)
    {
    }
}