using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftSecurityUpdateAPITest.Repository.Scripts
{
    public static class RemediationScripts
    {
        public static string QueryInsert => $@"
        INSERT INTO t_remediation (
              remedi_id
            , updite_id
            , remedi_url
            , remedi_description
        ) VALUES (
              @remedi_id
            , @updite_id
            , @remedi_url
            , @remedi_description
        );
        ";

        public static string QuerySelectById => $@"
        SELECT 
              remedi_id
            , updite_id
            , remedi_url
            , remedi_description
        FROM 
            t_remediation
        WHERE 
            remedi_id = @remedi_id AND
            updite_id = @updite_id;
        ";
    }
}
