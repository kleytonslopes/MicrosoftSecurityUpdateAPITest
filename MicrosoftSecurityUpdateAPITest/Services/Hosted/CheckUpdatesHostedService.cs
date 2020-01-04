using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace MicrosoftSecurityUpdateAPITest.Services.Hosted
{
    public class CheckUpdatesHostedService : IHostedService
    {
        private readonly IUpdatesService updatesService;
        public CheckUpdatesHostedService(IServiceProvider serviceProvider)
        {
            updatesService = serviceProvider.GetService<IUpdatesService>();
        }

        private bool isChecking;
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Factory.StartNew(() => 
            {
                StartCheckUpdates();
            });

            return Task.CompletedTask;
        }

        private void StartCheckUpdates()
        {
            isChecking = true;

            while (isChecking)
            {
                updatesService.CheckAndSaveUpdatesAsync().Wait();

                Thread.Sleep(Globals.Minutes);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            isChecking = false;

            return Task.CompletedTask;
        }
    }
}
