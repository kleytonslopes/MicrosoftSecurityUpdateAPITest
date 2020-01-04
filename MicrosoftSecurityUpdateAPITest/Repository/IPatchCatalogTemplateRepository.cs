using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicrosoftSecurityUpdateAPITest.Models.Templates;

namespace MicrosoftSecurityUpdateAPITest.Repository
{
    public interface IPatchCatalogTemplateRepository
    {
        Task<IEnumerable<PatchCatalogTemplate>> GetAllPatchCatalogRemplateAsync();
    }
}
