using Dasigno.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Dasigno.Infrastructure.Persistence.EntityConfigurations;

namespace Dasigno.Infrastructure.Persistence.Context;

/// <summary>
/// Realty Context
/// </summary>
public class UserContext : DbContext
{
    public const string DEFAULT_SCHEMA = "Dasigno";

    /// <summary>
    /// Constructor
    /// </summary>
    public UserContext()
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="options">Options Connections</param>
    public UserContext(DbContextOptions<UserContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }

    /// <summary>
    /// Transaction
    /// </summary>
    public DbSet<User> User{ get; set; }

}