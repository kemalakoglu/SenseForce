using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPuzzleSıgnalR.IntegrationTest
{
    public class DependencyFixture
    {
        public DependencyFixture()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<ApplicationService.IApplicationService, ApplicationService.ApplicationService>();
            serviceCollection.AddDbContext<Context.CodingPuzzleContext>(o => o.UseNpgsql("User ID=postgres;Password=User123!!;Host=localhost;Port=5432;Database=Coding.Puzzle;Pooling=true;"));

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public ServiceProvider ServiceProvider { get; private set; }
    }
}
