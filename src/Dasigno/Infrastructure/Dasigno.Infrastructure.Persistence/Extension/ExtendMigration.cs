using Dasigno.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.CodeAnalysis;

namespace Dasigno.Infrastructure.Persistence.Extension;

/// <summary>
/// Extension execute migration
/// </summary>
/// <remarks>Exclude to coverage because memory database not use migration</remarks>
[ExcludeFromCodeCoverage]
public static class ExtendMigration
{
    /// <summary>
    /// Execute Migration
    /// </summary>
    /// <param name="host">host instance</param>
    /// <example>host.ExecuteMigration(args);</example>
    /// <remarks>remember use attribute --run-migration when execute your application</remarks>
    public static IHost ExecuteMigration(this IHost host)
    {
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<UserContext>();
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                // Aquí puedes manejar el error según sea necesario
                Console.WriteLine($"Error migrating database: {ex.Message}");
                throw; // Puedes lanzar la excepción si deseas que detenga la aplicación
            }
        }

        return host;
    }
}