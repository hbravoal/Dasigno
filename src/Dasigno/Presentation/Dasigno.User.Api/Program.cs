using Serilog;
using Serilog.Exceptions;
using System.Globalization;
using Dasigno.Infrastructure.Persistence;
using Dasigno.Application;


string AppName = "Dasigno.User";

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddCommandLine(args)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
    .AddEnvironmentVariables()
    .Build();

var logger = new LoggerConfiguration()
    .MinimumLevel.Verbose()
    .Enrich.WithProperty("ApplicationContext", AppName)
    .Enrich.WithProperty("Environment", Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? Environment.GetEnvironmentVariable("ENV") ?? "Develop")
    .Enrich.WithExceptionDetails()
    .Enrich.FromLogContext()
    .WriteTo.Console();

Log.Logger = logger.ReadFrom.Configuration(configuration).CreateLogger();


try
{
    Log.Information("Configuring Web Host ({ApplicationContext})...", AppName);
    CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddPersistence(configuration);

    builder.Services.AddApplicationLayer();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();
    app.MapControllers();

    // app.ExecuteMigration(args);

    app.Run();

    Log.Information("Starting Web Host ({ApplicationContext})...", AppName);
}
catch (Exception e)
{
    Log.Fatal(e, "Program terminated unexpectedly ({ApplicationContext})!", AppName);
}
finally
{
    Log.CloseAndFlush();
}

