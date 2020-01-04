using Microsoft.Extensions.Logging;
using MicrosoftSecurityUpdateAPITest.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MicrosoftSecurityUpdateAPITest.Models;
using System.IO;
using System.Xml.Serialization;
using System.Text;
using MicrosoftSecurityUpdateAPITest.Models.Templates;

namespace MicrosoftSecurityUpdateAPITest.Services.Behaviours
{
    public class RemediationService : IRemediationService
    {
        private readonly ICvrfdocService cvrfdocService;
        private readonly IRemediationRepository remediationRepository;
        private readonly ILogger logger;

        public RemediationService(IServiceProvider serviceProvider, ILogger<RemediationService> logger)
        {
            cvrfdocService = serviceProvider.GetService<ICvrfdocService>();
            remediationRepository = serviceProvider.GetService<IRemediationRepository>();

            this.logger = logger;
        }

        public async Task CheckAndSaveRemediation(UpdateItemModel updateItemModel)
        {
            if (updateItemModel == null)
            {
                logger.LogInformation("O objeto UpdateItemModel foi nulo em CheckAndSaveRemediation");
                return;
            }

            Cvrfdoc cvrfdoc = await cvrfdocService.GetCvrfdocFromUrlAsync(updateItemModel.CvrfUrl);

            if (cvrfdoc != null)
            {
                List<Vulnerability> vulnerabilities = cvrfdoc.Vulnerability;
                await VerifyAndSaveRemediationsFromVulnerabilitiesAsync(vulnerabilities, updateItemModel);
            }
        }
        private async Task VerifyAndSaveRemediationsFromVulnerabilitiesAsync(List<Vulnerability> vulnerabilities, UpdateItemModel updateItemModel)
        {
            if (vulnerabilities != null && vulnerabilities.Any())
            {
                foreach (Vulnerability vulnerability in vulnerabilities)
                {
                    await ProcessVulnerabilityAsync(vulnerability, updateItemModel);
                }
            }
        }
        private async Task ProcessVulnerabilityAsync(Vulnerability vulnerability, UpdateItemModel updateItemModel)
        {
            List<Remediation> remediations = vulnerability.Remediations.Remediation;

            foreach (Remediation remediation in remediations)
            {
                await CheckAndSaveRemediationAsync(remediation, updateItemModel);
            }
        }
        private async Task CheckAndSaveRemediationAsync(Remediation remediation, UpdateItemModel updateItemModel)
        {
            if (remediation.NotIsSecurityUpdate)
                return;

            string updateItemId = updateItemModel.Id;
            string remediationId = remediation.Description;

            RemediationModel remediationModel = await remediationRepository.GetRemediationByIdAsync(remediationId, updateItemId);

            if (remediationModel != null)
                return;

            remediationModel = new RemediationModel();
            remediationModel.Id = remediationId;
            remediationModel.UpdateItemId = updateItemId;
            remediationModel.Description = $"KB{remediationId}";
            remediationModel.URL = remediation.URL;

            if (remediationModel.HasCatalogUrl)
                await remediationRepository.SaveRemediationAsync(remediationModel);
        }
    }
}
