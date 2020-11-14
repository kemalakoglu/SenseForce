using CodingPuzzleSıgnalR.ApplicationService;
using CodingPuzzleSıgnalR.ApplicationService.DTO;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodingPuzzleSıgnalR.ConsoleApplication
{
    public class Worker : IHostedService
    {
        private HubConnection hubConnection;
        private readonly ILogger<Worker> logger;
        private IConfiguration configuration;
        private IApplicationService applicationService;

        public Worker(IConfiguration configuration, ILogger<Worker> logger, IApplicationService applicationService)
        {
            this.configuration = configuration;
            this.logger = logger;
            this.applicationService = applicationService;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await SetupSignalRHubAsync();

            while (System.Console.ReadKey(false).Key != ConsoleKey.Escape);

            await hubConnection.DisposeAsync();
        }

        private async Task SetupSignalRHubAsync()
        {
            hubConnection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5001/")
                .ConfigureLogging(factory =>
                {
                    factory.AddConsole();
                    factory.AddFilter("Console", level => level >= LogLevel.Trace);
                }).Build();

            await hubConnection.StartAsync();

            logger.LogInformation("Connected to Hub");
            logger.LogInformation("Press ESC to stop");

            hubConnection.HandshakeTimeout = TimeSpan.FromSeconds(3);

            hubConnection.Closed += (args) =>
            {
                logger.LogInformation($"Connection close {args?.Message}");
                return Task.CompletedTask;
            };

            hubConnection.On<MessageDTO>("ReceiveMessage", (message) =>
            {
                if (message != null)
                {
                    this.applicationService.ConsumeMessage(message);
                    logger.LogInformation($"Received Message -> {message}");
                }
            });
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation($"Stop Service..");
            await hubConnection.DisposeAsync();
        }
    }
}
