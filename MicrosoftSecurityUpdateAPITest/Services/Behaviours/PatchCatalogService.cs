using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicrosoftSecurityUpdateAPITest.Models.Templates;
using Microsoft.Extensions.DependencyInjection;
using MicrosoftSecurityUpdateAPITest.Models;
using MicrosoftSecurityUpdateAPITest.Repository;

namespace MicrosoftSecurityUpdateAPITest.Services.Behaviours
{
    public class PatchCatalogService : IPatchCatalogService
    {
        private readonly IPatchCatalogTemplateRepository patchCatalogTemplateRepository;

        public PatchCatalogService(IServiceProvider serviceProvider)
        {
            patchCatalogTemplateRepository = serviceProvider.GetService<IPatchCatalogTemplateRepository>();
        }

        public async Task<IEnumerable<PatchCatalogTemplate>> GetPatchesCatalogTemplateAsync()
        {
            IEnumerable<PatchCatalogTemplate> patchCatalogTemplate = await patchCatalogTemplateRepository.GetAllPatchCatalogRemplateAsync();

            return patchCatalogTemplate;
        }
    }
}
