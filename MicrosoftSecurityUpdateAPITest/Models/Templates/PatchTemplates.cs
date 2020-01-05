using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MicrosoftSecurityUpdateAPITest.Models.Templates
{
    public class ID
    {
        public string Value { get; set; }
    }

    public class Alias
    {
        public string Value { get; set; }
    }

    public class Identification
    {
        public ID ID { get; set; }
        public Alias Alias { get; set; }
    }

    public class DocumentTracking
    {
        public Identification Identification { get; set; }
        public int Status { get; set; }
        public string Version { get; set; }
        public DateTime InitialReleaseDate { get; set; }
        public DateTime CurrentReleaseDate { get; set; }
    }

    public class Description
    {
        public string Value { get; set; }
    }

    public class Remediation
    {
        
        public Description Description { get; set; }
        public string URL { get; set; }
        public string Supercedence { get; set; }
        public List<string> ProductID { get; set; }
        public int Type { get; set; }
        public bool DateSpecified { get; set; }
        public List<object> AffectedFiles { get; set; }
        public string SubType { get; set; }

        public bool NotIsSecurityUpdate => SubType != "Security Update";

        public bool NotHasCatalogUrl
        {
            get
            {
                if (!URL.Contains($"q=KB{Description.Value}"))
                    return true;
                return false;
            }
        }
    }

    public class Vulnerability
    {
        public bool DiscoveryDateSpecified { get; set; }
        public bool ReleaseDateSpecified { get; set; }
        public string CVE { get; set; }
        public List<object> CVSSScoreSets { get; set; }
        public List<Remediation> Remediations { get; set; }
        public List<object> Acknowledgments { get; set; }
        public string Ordinal { get; set; }
    }

    public class Cvrfdoc
    {
        public List<Vulnerability> Vulnerability { get; set; }
    }

  
}
