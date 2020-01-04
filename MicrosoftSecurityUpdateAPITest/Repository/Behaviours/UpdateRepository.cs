using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicrosoftSecurityUpdateAPITest.Core;
using MicrosoftSecurityUpdateAPITest.Core.Connection;
using MicrosoftSecurityUpdateAPITest.Models;
using MicrosoftSecurityUpdateAPITest.Repository.Scripts;
using Microsoft.Extensions.DependencyInjection;

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
                query.SetQuery(UpdateItemScripts.QueryInsert);
            }
        }
    }
}
