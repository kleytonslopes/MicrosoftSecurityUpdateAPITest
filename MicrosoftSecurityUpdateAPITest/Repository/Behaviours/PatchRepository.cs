using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicrosoftSecurityUpdateAPITest.Core;
using MicrosoftSecurityUpdateAPITest.Core.Connection;
using MicrosoftSecurityUpdateAPITest.Models;
using MicrosoftSecurityUpdateAPITest.Repository.Scripts;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;

namespace MicrosoftSecurityUpdateAPITest.Repository.Behaviours
{
    public class PatchRepository : IPatchRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;

        public PatchRepository(IServiceProvider serviceProvider)
        {
            dbConnectionFactory = serviceProvider.GetService<IDbConnectionFactory>();
        }

        public async Task SavePatchItemAsync(PatchItemModel patchItemModel)
        {
            using (QueryFactory query = new QueryFactory(dbConnectionFactory))
            {
                var parameters = new
                {
                    updite_id = patchItemModel.Id,
                    updite_alias = patchItemModel.Alias,
                    updite_document_title = patchItemModel.DocumentTitle,
                    updite_severity = patchItemModel.Severity,
                    updite_initial_release_date = patchItemModel.InitialReleaseDate,
                    updite_current_release_date = patchItemModel.CurrentReleaseDate,
                    updite_cvrf_url = patchItemModel.CvrfUrl,
                };

                query.SetQuery(PatchItemScripts.QueryInsert);
                query.AddParameter(parameters);

                await query.ExecuteAsync();
            }
        }

        public async Task<PatchItemModel> GetPatchItemByIdAsync(string id)
        {
            using(QueryFactory query = new QueryFactory(dbConnectionFactory))
            {
                var parameters = new
                {
                    updite_id = id
                };

                query.SetQuery(PatchItemScripts.QuerySelectById);
                query.AddParameter(parameters);

                return await query.SelectFirstOrDefaultAsync<PatchItemModel>();
            }
        }
    }
}
