using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftSecurityUpdateAPITest.Models
{
    public class PatchModel
    {
        [JsonProperty("@odata.context")]
        public string OdataContext { get; set; }

        public IEnumerable<PatchItemModel> Value {get;set;}
    }
}
