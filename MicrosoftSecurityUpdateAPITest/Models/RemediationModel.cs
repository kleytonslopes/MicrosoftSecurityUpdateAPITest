using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftSecurityUpdateAPITest.Models
{
    public class RemediationModel
    {
        public string Id { get; set; }
        public string UpdateItemId { get; internal set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public bool HasCatalogUrl
        {
            get
            {
                if (URL.Contains($"q={Description}"))
                    return true;
                return false;
            }
        }
    }
}
