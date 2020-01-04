using MicrosoftSecurityUpdateAPITest.Models.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftSecurityUpdateAPITest.Services
{
    public interface IPatchCatalogService
    {
        Task<IEnumerable<PatchCatalogTemplate>> GetPatchesCatalogTemplateAsync();
    }
}
