using MicrosoftSecurityUpdateAPITest.Core.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MicrosoftSecurityUpdateAPITest.Core;
using MicrosoftSecurityUpdateAPITest.Models;
using MicrosoftSecurityUpdateAPITest.Repository.Scripts;

namespace MicrosoftSecurityUpdateAPITest.Repository.Behaviours
{
    public class RemediationRepository : IRemediationRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;

        public RemediationRepository(IServiceProvider serviceProvider)
        {
            dbConnectionFactory = serviceProvider.GetService<IDbConnectionFactory>();
        }

        public async Task SaveRemediationAsync(RemediationModel remediationModel)
        {
            using (QueryFactory query = new QueryFactory(dbConnectionFactory))
            {
                var parameters = new
                {
                    remedi_id = remediationModel.Id,
                    updite_id = remediationModel.UpdateItemId,
                    remedi_url = remediationModel.URL,
                    remedi_description = remediationModel.Description
                };

                query.SetQuery(RemediationScripts.QueryInsert);
                query.AddParameter(parameters);

                await query.ExecuteAsync();
            }
        }

        public async Task<RemediationModel> GetRemediationByIdAsync(string remediationId, string updateItemid)
        {
            using (QueryFactory query = new QueryFactory(dbConnectionFactory))
            {
                var parameters = new
                {
                    remedi_id = remediationId,
                    updite_id = updateItemid
                };

                query.SetQuery(RemediationScripts.QuerySelectById);
                query.AddParameter(parameters);

                return await query.SelectFirstOrDefaultAsync<RemediationModel>();
            }
        }
    }
}
