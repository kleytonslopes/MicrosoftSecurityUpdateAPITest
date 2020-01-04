using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftSecurityUpdateAPITest.Models.Templates
{
    /// <summary>
    /// Classe controle. Não persistir em banco
    /// </summary>
    public class PatchCatalogTemplate
    {
        public string PatchAlias { get; set; }
        public string PatchInitialReleaseDate { get; set; }
        public string PatchCurrentReleaseDate { get; set; }
        public string RemediationDescription { get; set; }
        public string RemediationUrl { get; set; }
    }
}
