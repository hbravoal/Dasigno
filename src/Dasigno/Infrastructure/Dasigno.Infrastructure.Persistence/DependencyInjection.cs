using Dasigno.Domain.Interfaces.Persistence;
using Dasigno.Infrastructure.Persistence.Context;
using Dasigno.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Dasigno.Infrastructure.Persistence;

/// <summary>
/// dependency inyection
/// </summary>
[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
    /// <summary>
    /// Add Domain
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddDbContext<UserContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("SqlServer")),
            contextLifetime: ServiceLifetime.Transient
        );
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        return services;
    }
}