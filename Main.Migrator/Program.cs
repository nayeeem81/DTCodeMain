
// File: Main.Migrator/Program.cs

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Main.Infrastructure;       
using Data; 

namespace Main.Migrator;

class Program
{
    static async Task Main ( string[] args )
    {
        Console.WriteLine ( "=== Starting Database Migration Engine ===" );

        
        using IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) =>
            {
                
                var webAppPath = Path.Combine(AppContext.BaseDirectory, "../../../../Main.WebAppCore");

                config.SetBasePath(Directory.Exists(webAppPath) ? webAppPath : AppContext.BaseDirectory)
                      .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                      .AddEnvironmentVariables();
            })
            .ConfigureServices((context, services) =>
            {
                // 2. Register Infrastructure services (DbContext, Identity, Seeding tools)
                // The Web application project knows nothing about this call
                services.AddInfrastructureServices(context.Configuration);
                
                // Explicitly add Logging to observe the migration output cleanly
                services.AddLogging(logging => logging.AddConsole());
            })
            .Build();

        //  Create a isolated execution scope to resolve DbInitializer safely
        using ( var scope = host.Services.CreateScope ( ) )
        {
            var serviceProvider = scope.ServiceProvider;
            var logger = serviceProvider.GetRequiredService<ILogger<Program>>();

            try
            {
                logger.LogInformation ( "Resolving the database initialization pipeline..." );
                var initializer = serviceProvider.GetRequiredService<DbInitializer>();

                // Execute migration, schema updates, and seed functions sequentially
                await initializer.InitializeAsync ( );

                logger.LogInformation ( "=== Database Processing Completed Successfully ===" );
            }
            catch ( Exception ex )
            {
                logger.LogCritical ( ex,"A fatal exception halted the migration processing engine." );
                Environment.ExitCode = 1; // Mark the execution process as failed
            }
        }
    }
}
