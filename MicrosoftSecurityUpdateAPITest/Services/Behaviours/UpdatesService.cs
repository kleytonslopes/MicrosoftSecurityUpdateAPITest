using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MicrosoftSecurityUpdateAPITest.Models;
using Newtonsoft.Json;

namespace MicrosoftSecurityUpdateAPITest.Services.Behaviours
{
    public class UpdatesService : IUpdatesService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public UpdatesService(IServiceProvider serviceProvider)
        {
            httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
        }

        public async Task CheckAndSaveUpdatesAsync()
        {
            var response = RequestUpdates();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();

                UpdatesModel updatesModel = JsonConvert.DeserializeObject<UpdatesModel>(json);

                if (updatesModel != null)
                    SaveUpdates(updatesModel);
            }
        }

        private HttpResponseMessage RequestUpdates()
        {
            int apiVersion = DateTime.Now.Year;

            var request = new HttpRequestMessage(HttpMethod.Get, string.Format("updates?api-version=2020"));
            var client = httpClientFactory.CreateClient(Globals.HTTP_CLIENT_MICROSOFT_API);

            var response = client.SendAsync(request).Result;

            response.EnsureSuccessStatusCode();

            return response;
        }

        private void SaveUpdates(UpdatesModel updatesModel)
        {
            if (updatesModel.Value.Any())
            {
                foreach (UpdateItemModel item in updatesModel.Value)
                {
                    //check update
                }
            }
        }
    }
}
