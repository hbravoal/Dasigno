using System.Diagnostics.CodeAnalysis;
using Dasigno.Application;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace Dasigno.Test.Common;

/// <summary>
/// WebHost for tests with Dependency Injection
/// </summary>
[ExcludeFromCodeCoverage]
public static class FakeWebHost
{
    private static TestServer? _testServer;

    public static TestServer TestServer =>
        _testServer ??=
        new BasicWebApplicationFactory().Server;

    public static IServiceScope ServiceScope => TestServer.Services.GetService<IServiceScopeFactory>().CreateScope();

    public class BasicWebApplicationFactory : WebApplicationFactory<ProgramApi>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Create a new service provider.
                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();
 
               // services.AddTransient(sp => UserContextExtend.UnitOfWork);
                services.AddApplicationLayer();
            });
        }
    }
}