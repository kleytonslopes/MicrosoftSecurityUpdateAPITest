using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace MicrosoftSecurityUpdateAPITest.Services.Hosted
{
    public class CheckPatchHostedService : IHostedService
    {
        private readonly IPatchService patchService;
        public CheckPatchHostedService(IServiceProvider serviceProvider)
        {
            patchService = serviceProvider.GetService<IPatchService>();
        }

        private bool isChecking;
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Factory.StartNew(() => 
            {
                StartCheckPatch();
            });

            return Task.CompletedTask;
        }

        private void StartCheckPatch()
        {
            isChecking = true;


            while (isChecking)
            {
                //if(patchService.NotProcessing)
                //    patchService.CheckAndSavePatchesAsync();

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
