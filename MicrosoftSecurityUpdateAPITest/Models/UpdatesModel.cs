using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftSecurityUpdateAPITest.Models
{
    public class UpdatesModel
    {
        [JsonProperty("@odata.context")]
        public string OdataContext { get; set; }

        public IEnumerable<UpdateItemModel> Value {get;set;}
    }
}
