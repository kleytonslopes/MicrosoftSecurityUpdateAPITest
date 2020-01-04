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

        public async Task<Cvrfdoc> GetCvrfdocFromUrlAsync(string cvrfUrl)
        {
            var response = RequestCvrfdoc(cvrfUrl);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var xml = await response.Content.ReadAsStringAsync();

                var ms = new MemoryStream(Encoding.UTF8.GetBytes(xml));
                XmlSerializer serializer = new XmlSerializer(typeof(Cvrfdoc));
                Cvrfdoc cvrfdoc = ((Cvrfdoc)serializer.Deserialize(ms));

                return cvrfdoc;
            }

            return null;
        }

        private HttpResponseMessage RequestCvrfdoc(string cvrfUrl)
        {
            var client = httpClientFactory.CreateClient(Globals.HTTP_CLIENT_MICROSOFT_API);
            client.BaseAddress = new Uri(cvrfUrl);

            var response = client.GetAsync(cvrfUrl).Result;

            response.EnsureSuccessStatusCode();

            return response;
        }
    }
}
