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
    public class UpdatesService : IUpdatesService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IUpdateRepository updateRepository;
        private readonly IRemediationService remediationService;
        private readonly ILogger logger;
        private bool isProcessing;
        public bool NotProcessing => !isProcessing;

        public UpdatesService(IServiceProvider serviceProvider, ILogger<UpdatesService> logger)
        {
            httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
            remediationService = serviceProvider.GetService<IRemediationService>();
            updateRepository = serviceProvider.GetService<IUpdateRepository>();

            this.logger = logger;
        }

        public async Task CheckAndSaveUpdatesAsync()
        {
            try
            {
                isProcessing = true;
                var response = RequestUpdates();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    UpdatesModel updatesModel = JsonConvert.DeserializeObject<UpdatesModel>(json);

                    if (updatesModel != null)
                        await SaveUpdatesAsync(updatesModel);
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Erro em CheckAndSaveUpdatesAsync: {ex}", ex);
            }
            finally
            {
                isProcessing = false;
            }
        }

        private HttpResponseMessage RequestUpdates()
        {
            int apiVersion = DateTime.Now.Year;

            var request = new HttpRequestMessage(HttpMethod.Get, string.Format("updates?api-version={0}", apiVersion));
            var client = httpClientFactory.CreateClient(Globals.HTTP_CLIENT_MICROSOFT_API);

            var response = client.SendAsync(request).Result;

            response.EnsureSuccessStatusCode();

            return response;
        }

        private async Task SaveUpdatesAsync(UpdatesModel updatesModel)
        {
            if (updatesModel.Value.Any())
            {
                foreach (UpdateItemModel item in updatesModel.Value)
                {
                    try
                    {
                        UpdateItemModel updateItemModelTemp = await updateRepository.GetUpdateItemByIdAsync(item.Id);
                        if (updateItemModelTemp == null)
                            await updateRepository.SaveUpdateItemAsync(item);

                        await remediationService.CheckAndSaveRemediation(item);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError("Erro em SaveUpdatesAsync: {ex}", ex);
                    }
                }
            }
        }
    }
}
