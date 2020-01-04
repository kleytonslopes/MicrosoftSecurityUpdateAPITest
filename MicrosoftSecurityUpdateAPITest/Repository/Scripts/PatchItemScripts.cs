using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftSecurityUpdateAPITest.Repository.Scripts
{
    public static class PatchItemScripts
    {
        public static string QueryInsert => $@"
        INSERT INTO t_update_item (
              updite_id
            , updite_alias
            , updite_document_title
            , updite_severity
            , updite_initial_release_date
            , updite_current_release_date
            , updite_cvrf_url
        ) VALUES (
              @updite_id
            , @updite_alias
            , @updite_document_title
            , @updite_severity
            , @updite_initial_release_date
            , @updite_current_release_date
            , @updite_cvrf_url
        );
        ";

        public static string QuerySelectById => $@"
        SELECT 
              updite_id
            , updite_alias
            , updite_document_title
            , updite_severity
            , updite_initial_release_date
            , updite_current_release_date
            , updite_cvrf_url 
        FROM 
            t_update_item
        WHERE 
            updite_id = @updite_id;
        ";
    }
}
