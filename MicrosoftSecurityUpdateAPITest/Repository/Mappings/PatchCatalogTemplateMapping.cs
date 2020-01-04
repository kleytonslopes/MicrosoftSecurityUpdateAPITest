using Dapper.FluentMap.Mapping;
using MicrosoftSecurityUpdateAPITest.Models.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftSecurityUpdateAPITest.Repository.Mappings
{
    public class PatchCatalogTemplateMapping : EntityMap<PatchCatalogTemplate>
    {
        public PatchCatalogTemplateMapping()
        {
            Map(p => p.PatchAlias).ToColumn("updite_alias");
            Map(p => p.PatchCurrentReleaseDate).ToColumn("updite_current_release_date");
            Map(p => p.PatchInitialReleaseDate).ToColumn("updite_initial_release_date");
            Map(p => p.RemediationDescription).ToColumn("remedi_description");
            Map(p => p.RemediationUrl).ToColumn("remedi_url");
        }
    }
}
