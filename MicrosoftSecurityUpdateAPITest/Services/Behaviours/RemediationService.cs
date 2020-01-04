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

        public async Task CheckAndSaveRemediation(PatchItemModel patchItemModel)
        {
            if (patchItemModel == null)
            {
                logger.LogInformation("O objeto UpdateItemModel foi nulo em CheckAndSaveRemediation");
                return;
            }

            Cvrfdoc cvrfdoc = await cvrfdocService.GetCvrfdocFromUrlAsync(patchItemModel.CvrfUrl);

            if (cvrfdoc != null)
            {
                List<Vulnerability> vulnerabilities = cvrfdoc.Vulnerability;
                await VerifyAndSaveRemediationsFromVulnerabilitiesAsync(vulnerabilities, patchItemModel);
            }
        }
        private async Task VerifyAndSaveRemediationsFromVulnerabilitiesAsync(List<Vulnerability> vulnerabilities, PatchItemModel patchItemModel)
        {
            if (vulnerabilities != null && vulnerabilities.Any())
            {
                foreach (Vulnerability vulnerability in vulnerabilities)
                {
                    await ProcessVulnerabilityAsync(vulnerability, patchItemModel);
                }
            }
        }
        private async Task ProcessVulnerabilityAsync(Vulnerability vulnerability, PatchItemModel patchItemModel)
        {
            List<Remediation> remediations = vulnerability.Remediations.Remediation;

            foreach (Remediation remediation in remediations)
            {
                await CheckAndSaveRemediationAsync(remediation, patchItemModel);
            }
        }
        private async Task CheckAndSaveRemediationAsync(Remediation remediation, PatchItemModel patchItemModel)
        {
            if (remediation.NotIsSecurityUpdate)
                return;

            string patchItemId = patchItemModel.Id;
            string remediationId = remediation.Description;

            if (remediation.NotHasCatalogUrl)
                return;

            RemediationModel remediationModel = await remediationRepository.GetRemediationByIdAsync(remediationId, patchItemId);

            if (remediationModel != null)
                return;

            remediationModel = new RemediationModel();
            remediationModel.Id = remediationId;
            remediationModel.UpdateItemId = patchItemId;
            remediationModel.Description = $"KB{remediationId}";
            remediationModel.URL = remediation.URL;

            if (remediationModel.HasCatalogUrl)
                await remediationRepository.SaveRemediationAsync(remediationModel);
        }
    }
}
