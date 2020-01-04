using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MicrosoftSecurityUpdateAPITest.Models;
using MicrosoftSecurityUpdateAPITest.Models.Templates;
using MicrosoftSecurityUpdateAPITest.Repository;
using Newtonsoft.Json;

namespace MicrosoftSecurityUpdateAPITest.Services.Behaviours
{
    public class PatchService : IPatchService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IPatchRepository patchRepository;
        private readonly IRemediationService remediationService;
        private readonly ILogger logger;
        private bool isProcessing;
        public bool NotProcessing => !isProcessing;

        public PatchService(IServiceProvider serviceProvider, ILogger<PatchService> logger)
        {
            httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
            remediationService = serviceProvider.GetService<IRemediationService>();
            patchRepository = serviceProvider.GetService<IPatchRepository>();

            this.logger = logger;
        }

        public async Task CheckAndSavePatchesAsync()
        {
            try
            {
                isProcessing = true;
                var response = RequestPatches();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    PatchModel patchModel = JsonConvert.DeserializeObject<PatchModel>(json);

                    if (patchModel != null)
                        await SavePatchesAsync(patchModel);
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Erro em CheckAndSavePatchAsync: {ex}", ex);
            }
            finally
            {
                isProcessing = false;
            }
        }

        private HttpResponseMessage RequestPatches()
        {
            int apiVersion = DateTime.Now.Year;

            var request = new HttpRequestMessage(HttpMethod.Get, string.Format("updates?api-version={0}", apiVersion));
            var client = httpClientFactory.CreateClient(Globals.HTTP_CLIENT_MICROSOFT_API);

            var response = client.SendAsync(request).Result;

            response.EnsureSuccessStatusCode();

            return response;
        }

        private async Task SavePatchesAsync(PatchModel patchModel)
        {
            if (patchModel.Value.Any())
            {
                foreach (PatchItemModel patchItem in patchModel.Value)
                {
                    try
                    {
                        PatchItemModel patchItemModelTemp = await patchRepository.GetPatchItemByIdAsync(patchItem.Id);
                        if (patchItemModelTemp == null)
                            await patchRepository.SavePatchItemAsync(patchItem);

                        await remediationService.CheckAndSaveRemediation(patchItem);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError("Erro em SavePatchesAsync: {ex}", ex);
                    }
                }
            }
        }
    }
}
