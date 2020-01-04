using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftSecurityUpdateAPITest.Models
{
    public class UpdateItemModel
    {
        public string Id { get; set; }
        public string Alias { get; set; }
        public string DocumentTitle { get; set; }
        public string Severity { get; set; }
        public DateTime InitialReleaseDate { get; set; }
        public DateTime CurrentReleaseDate { get; set; }
        public string CvrfUrl { get; set; }
    }
}
