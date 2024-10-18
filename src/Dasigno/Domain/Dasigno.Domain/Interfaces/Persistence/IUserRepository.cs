using Dasigno.Domain.Entities;
using Dasigno.Domain.Interfaces.Persistence.Common;

namespace Dasigno.Domain.Interfaces.Persistence;

public interface IUserRepository : IGenericRepository<User, int>{}