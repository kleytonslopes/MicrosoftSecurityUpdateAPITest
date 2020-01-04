using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MicrosoftSecurityUpdateAPITest.Models;
using MicrosoftSecurityUpdateAPITest.Services;
using Microsoft.Extensions.DependencyInjection;
using MicrosoftSecurityUpdateAPITest.Models.Templates;

namespace MicrosoftSecurityUpdateAPITest.Controllers
{
    [Route("api/patch")]
    [ApiController]
    public class PatchController : ControllerBase
    {
        private readonly IPatchCatalogService catalogService;

        public PatchController(IServiceProvider serviceProvider)
        {
            catalogService = serviceProvider.GetService<IPatchCatalogService>();
        }

        [HttpGet()]
        public async Task<IActionResult> GetPatches()
        {
            try
            {
                IEnumerable<PatchCatalogTemplate> patchCatalogTemplates = await catalogService.GetPatchesCatalogTemplateAsync();
                
                if (patchCatalogTemplates == null || !patchCatalogTemplates.Any())
                    return NoContent();

                return Ok(patchCatalogTemplates);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}