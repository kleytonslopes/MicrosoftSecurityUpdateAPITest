using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftSecurityUpdateAPITest.Repository.Scripts
{
    public static class PatchCatalogScripts
    {

        public static string QuerySelectAll => $@"
        SELECT 
        	  IT.updite_alias	
            , IT.updite_initial_release_date
            , IT.updite_current_release_date
            , RE.remedi_description
            , RE.remedi_url
        FROM 
        	t_update_item IT 
        INNER JOIN 
        	t_remediation RE ON IT. updite_id = RE.updite_id
        ";
    }
}
