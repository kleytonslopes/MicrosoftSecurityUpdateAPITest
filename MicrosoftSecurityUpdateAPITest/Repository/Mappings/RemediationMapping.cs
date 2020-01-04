using Dapper.FluentMap.Mapping;
using MicrosoftSecurityUpdateAPITest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftSecurityUpdateAPITest.Repository.Mappings
{
    public class RemediationMapping : EntityMap<RemediationModel>
    {
        public RemediationMapping()
        {
            Map(p => p.Id).ToColumn("remedi_id");
            Map(p => p.UpdateItemId).ToColumn("updite_id");
            Map(p => p.URL).ToColumn("remedi_url");
            Map(p => p.Description).ToColumn("remedi_description");
        }
    }
}
