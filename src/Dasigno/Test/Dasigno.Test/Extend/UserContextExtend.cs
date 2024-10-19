using System.Diagnostics.CodeAnalysis;
using Dasigno.Domain.Interfaces.Persistence;
using Dasigno.Infrastructure.Persistence.Context;
using Dasigno.Infrastructure.Persistence.Repository;
using Dasigno.Test.Common;

namespace Dasigno.Test.Extend;

[ExcludeFromCodeCoverage]
public static class UserContextExtend
{
    //private static RealtyContext? _context;

    public static UserContext Context =>
        new(DbContextMemory.CreateContextOptions<UserContext>("Dasigno"));

    public static IUnitOfWork UnitOfWork =>
        new UnitOfWork(Context);
}