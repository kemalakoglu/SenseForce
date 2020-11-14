using CodingPuzzleSıgnalR.ApplicationService;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CodingPuzzleSıgnalR.ConsoleApplication
{
    public class Program
    {

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureLogging(logging =>
            {
                logging.AddConsole();
            })
            .ConfigureServices((hostContext, services) =>
            {
                services.AddOptions();
                services.AddLogging();
                services.AddHostedService<Worker>();
                services.AddDbContext<Context.CodingPuzzleContext>(o => o.UseNpgsql("User ID=postgres;Password=User123!!;Host=localhost;Port=5432;Database=Coding.Puzzle;Pooling=true;"));
                services.AddScoped<IApplicationService, ApplicationService.ApplicationService>();
            });
    }
}
