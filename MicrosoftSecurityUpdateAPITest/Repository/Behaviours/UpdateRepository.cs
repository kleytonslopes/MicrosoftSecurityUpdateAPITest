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
    public class UpdateRepository : IUpdateRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;

        public UpdateRepository(IServiceProvider serviceProvider)
        {
            dbConnectionFactory = serviceProvider.GetService<IDbConnectionFactory>();
        }

        public async Task SaveUpdateItemAsync(UpdateItemModel updateItemModel)
        {
            using (QueryFactory query = new QueryFactory(dbConnectionFactory))
            {
                var parameters = new
                {
                    updite_id = updateItemModel.Id,
                    updite_alias = updateItemModel.Alias,
                    updite_document_title = updateItemModel.DocumentTitle,
                    updite_severity = updateItemModel.Severity,
                    updite_initial_release_date = updateItemModel.InitialReleaseDate,
                    updite_current_release_date = updateItemModel.CurrentReleaseDate,
                    updite_cvrf_url = updateItemModel.CvrfUrl,
                };

                query.SetQuery(UpdateItemScripts.QueryInsert);
                query.AddParameter(parameters);

                await query.ExecuteAsync();
            }
        }

        public async Task<UpdateItemModel> GetUpdateItemByIdAsync(string id)
        {
            using(QueryFactory query = new QueryFactory(dbConnectionFactory))
            {
                var parameters = new
                {
                    updite_id = id
                };

                query.SetQuery(UpdateItemScripts.QuerySelectById);
                query.AddParameter(parameters);

                return await query.SelectFirstOrDefaultAsync<UpdateItemModel>();
            }
        }
    }
}
