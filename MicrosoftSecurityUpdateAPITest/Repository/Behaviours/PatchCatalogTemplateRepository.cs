using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicrosoftSecurityUpdateAPITest.Core.Connection;
using MicrosoftSecurityUpdateAPITest.Models.Templates;
using Microsoft.Extensions.DependencyInjection;
using MicrosoftSecurityUpdateAPITest.Core;
using MicrosoftSecurityUpdateAPITest.Repository.Scripts;

namespace MicrosoftSecurityUpdateAPITest.Repository.Behaviours
{
    public class PatchCatalogTemplateRepository : IPatchCatalogTemplateRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;

        public PatchCatalogTemplateRepository(IServiceProvider serviceProvider)
        {
            dbConnectionFactory = serviceProvider.GetService<IDbConnectionFactory>();
        }

        public async Task<IEnumerable<PatchCatalogTemplate>> GetAllPatchCatalogRemplateAsync()
        {
            using (QueryFactory query = new QueryFactory(dbConnectionFactory))
            {
                query.SetQuery(PatchCatalogScripts.QuerySelectAll);

                return await query.SelectListAsync<PatchCatalogTemplate>();
            }
        }
    }
}
