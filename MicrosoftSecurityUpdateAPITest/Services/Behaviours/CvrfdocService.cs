using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MicrosoftSecurityUpdateAPITest.Models.Templates;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace MicrosoftSecurityUpdateAPITest.Services.Behaviours
{
    public class CvrfdocService : ICvrfdocService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger logger;

        public CvrfdocService(IServiceProvider serviceProvider, ILogger<CvrfdocService> logger)
        {
            httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();

            this.logger = logger;
        }

        public async Task<Cvrfdoc> GetCvrfdocFromUrlAsync(string cvrfId)
        {
            var response = RequestCvrfdoc(cvrfId);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                
                Cvrfdoc cvrfdoc = JsonConvert.DeserializeObject<Cvrfdoc>(json);

                return cvrfdoc;
            }

            return null;
        }

        private HttpResponseMessage RequestCvrfdoc(string cvrfIdDocument)
        {
            int apiVersion = DateTime.Now.Year;

            var request = new HttpRequestMessage(HttpMethod.Get, string.Format("cvrf/{0}?api-version={1}", cvrfIdDocument, apiVersion));
            var client = httpClientFactory.CreateClient(Globals.HTTP_CLIENT_MICROSOFT_API);

            var response = client.SendAsync(request).Result;

            response.EnsureSuccessStatusCode();

            return response;
        }
    }
}
