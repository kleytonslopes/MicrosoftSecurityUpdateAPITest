using Dapper.FluentMap.Mapping;
using MicrosoftSecurityUpdateAPITest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftSecurityUpdateAPITest.Repository.Mappings
{
    public class PatchItemMapping : EntityMap<PatchItemModel>
    {
        public PatchItemMapping()
        {
            Map(p => p.Id).ToColumn("updite_id");
            Map(p => p.Alias).ToColumn("updite_alias");
            Map(p => p.DocumentTitle).ToColumn("updite_document_title");
            Map(p => p.Severity).ToColumn("updite_severity");
            Map(p => p.InitialReleaseDate).ToColumn("updite_initial_release_date");
            Map(p => p.CurrentReleaseDate).ToColumn("updite_current_release_date");
            Map(p => p.CvrfUrl).ToColumn("updite_severity");
        }
    }
}
