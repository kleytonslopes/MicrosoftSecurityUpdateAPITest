using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace MicrosoftSecurityUpdateAPITest.Models.Templates
{
    [XmlRoot(ElementName = "DocumentPublisher", Namespace = "http://www.icasi.org/CVRF/schema/cvrf/1.1")]
    public class DocumentPublisher
    {
        [XmlElement(ElementName = "ContactDetails", Namespace = "http://www.icasi.org/CVRF/schema/cvrf/1.1")]
        public string ContactDetails { get; set; }
        [XmlElement(ElementName = "IssuingAuthority", Namespace = "http://www.icasi.org/CVRF/schema/cvrf/1.1")]
        public string IssuingAuthority { get; set; }
        [XmlAttribute(AttributeName = "Type")]
        public string Type { get; set; }
    }

    [XmlRoot(ElementName = "Identification", Namespace = "http://www.icasi.org/CVRF/schema/cvrf/1.1")]
    public class Identification
    {
        [XmlElement(ElementName = "ID", Namespace = "http://www.icasi.org/CVRF/schema/cvrf/1.1")]
        public string ID { get; set; }
        [XmlElement(ElementName = "Alias", Namespace = "http://www.icasi.org/CVRF/schema/cvrf/1.1")]
        public string Alias { get; set; }
    }

    [XmlRoot(ElementName = "Revision", Namespace = "http://www.icasi.org/CVRF/schema/cvrf/1.1")]
    public class Revision
    {
        [XmlElement(ElementName = "Number", Namespace = "http://www.icasi.org/CVRF/schema/cvrf/1.1")]
        public string Number { get; set; }
        [XmlElement(ElementName = "Date", Namespace = "http://www.icasi.org/CVRF/schema/cvrf/1.1")]
        public string Date { get; set; }
        [XmlElement(ElementName = "Description", Namespace = "http://www.icasi.org/CVRF/schema/cvrf/1.1")]
        public string Description { get; set; }
    }

    [XmlRoot(ElementName = "RevisionHistory", Namespace = "http://www.icasi.org/CVRF/schema/cvrf/1.1")]
    public class RevisionHistory
    {
        [XmlElement(ElementName = "Revision", Namespace = "http://www.icasi.org/CVRF/schema/cvrf/1.1")]
        public Revision Revision { get; set; }
    }

    [XmlRoot(ElementName = "DocumentTracking", Namespace = "http://www.icasi.org/CVRF/schema/cvrf/1.1")]
    public class DocumentTracking
    {
        [XmlElement(ElementName = "Identification", Namespace = "http://www.icasi.org/CVRF/schema/cvrf/1.1")]
        public Identification Identification { get; set; }
        [XmlElement(ElementName = "Status", Namespace = "http://www.icasi.org/CVRF/schema/cvrf/1.1")]
        public string Status { get; set; }
        [XmlElement(ElementName = "Version", Namespace = "http://www.icasi.org/CVRF/schema/cvrf/1.1")]
        public string Version { get; set; }
        [XmlElement(ElementName = "RevisionHistory", Namespace = "http://www.icasi.org/CVRF/schema/cvrf/1.1")]
        public RevisionHistory RevisionHistory { get; set; }
        [XmlElement(ElementName = "InitialReleaseDate", Namespace = "http://www.icasi.org/CVRF/schema/cvrf/1.1")]
        public string InitialReleaseDate { get; set; }
        [XmlElement(ElementName = "CurrentReleaseDate", Namespace = "http://www.icasi.org/CVRF/schema/cvrf/1.1")]
        public string CurrentReleaseDate { get; set; }
    }

    [XmlRoot(ElementName = "Note", Namespace = "http://www.icasi.org/CVRF/schema/cvrf/1.1")]
    public class Note
    {
        [XmlAttribute(AttributeName = "Title")]
        public string Title { get; set; }
        [XmlAttribute(AttributeName = "Audience")]
        public string Audience { get; set; }
        [XmlAttribute(AttributeName = "Type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "Ordinal")]
        public string Ordinal { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "DocumentNotes", Namespace = "http://www.icasi.org/CVRF/schema/cvrf/1.1")]
    public class DocumentNotes
    {
        [XmlElement(ElementName = "Note", Namespace = "http://www.icasi.org/CVRF/schema/cvrf/1.1")]
        public List<Note> Note { get; set; }
    }

    [XmlRoot(ElementName = "FullProductName", Namespace = "http://www.icasi.org/CVRF/schema/prod/1.1")]
    public class FullProductName
    {
        [XmlAttribute(AttributeName = "ProductID")]
        public string ProductID { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Branch", Namespace = "http://www.icasi.org/CVRF/schema/prod/1.1")]
    public class Branch
    {
        [XmlElement(ElementName = "FullProductName", Namespace = "http://www.icasi.org/CVRF/schema/prod/1.1")]
        public List<FullProductName> FullProductName { get; set; }
        [XmlAttribute(AttributeName = "Type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "ProductTree", Namespace = "http://www.icasi.org/CVRF/schema/prod/1.1")]
    public class ProductTree
    {
        [XmlElement(ElementName = "Branch", Namespace = "http://www.icasi.org/CVRF/schema/prod/1.1")]
        public Branch Branch { get; set; }
        [XmlElement(ElementName = "FullProductName", Namespace = "http://www.icasi.org/CVRF/schema/prod/1.1")]
        public List<FullProductName> FullProductName { get; set; }
    }

    [XmlRoot(ElementName = "Note", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
    public class Note2
    {
        [XmlAttribute(AttributeName = "Title")]
        public string Title { get; set; }
        [XmlAttribute(AttributeName = "Type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "Ordinal")]
        public string Ordinal { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Notes", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
    public class Notes
    {
        [XmlElement(ElementName = "Note", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
        public List<Note2> Note2 { get; set; }
    }

    [XmlRoot(ElementName = "Status", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
    public class Status
    {
        [XmlElement(ElementName = "ProductID", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
        public List<string> ProductID { get; set; }
        [XmlAttribute(AttributeName = "Type")]
        public string Type { get; set; }
    }

    [XmlRoot(ElementName = "ProductStatuses", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
    public class ProductStatuses
    {
        [XmlElement(ElementName = "Status", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
        public Status Status { get; set; }
    }

    [XmlRoot(ElementName = "Threat", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
    public class Threat
    {
        [XmlElement(ElementName = "Description", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
        public string Description { get; set; }
        [XmlElement(ElementName = "ProductID", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
        public string ProductID { get; set; }
        [XmlAttribute(AttributeName = "Type")]
        public string Type { get; set; }
    }

    [XmlRoot(ElementName = "Threats", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
    public class Threats
    {
        [XmlElement(ElementName = "Threat", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
        public List<Threat> Threat { get; set; }
    }

    [XmlRoot(ElementName = "Remediation", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
    public class Remediation
    {
        [XmlElement(ElementName = "Description", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
        public string Description { get; set; }
        [XmlElement(ElementName = "URL", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
        public string URL { get; set; }
        [XmlElement(ElementName = "Supercedence", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
        public string Supercedence { get; set; }
        [XmlElement(ElementName = "ProductID", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
        public List<string> ProductID { get; set; }
        [XmlElement(ElementName = "AffectedFiles", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
        public string AffectedFiles { get; set; }
        [XmlElement(ElementName = "RestartRequired", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
        public string RestartRequired { get; set; }
        [XmlElement(ElementName = "SubType", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
        public string SubType { get; set; }
        [XmlAttribute(AttributeName = "Type")]
        public string Type { get; set; }

        public bool NotIsSecurityUpdate => SubType != "Security Update";

        public bool NotHasCatalogUrl
        {
            get
            {
                if (!URL.Contains($"q=KB{Description}"))
                    return true;
                return false;
            }
        }
    }

    [XmlRoot(ElementName = "Remediations", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
    public class Remediations
    {
        [XmlElement(ElementName = "Remediation", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
        public List<Remediation> Remediation { get; set; }
    }

    [XmlRoot(ElementName = "Acknowledgment", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
    public class Acknowledgment
    {
        [XmlElement(ElementName = "Name", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
        public string Name { get; set; }
        [XmlElement(ElementName = "URL", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
        public string URL { get; set; }
    }

    [XmlRoot(ElementName = "Acknowledgments", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
    public class Acknowledgments
    {
        [XmlElement(ElementName = "Acknowledgment", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
        public List<Acknowledgment> Acknowledgment { get; set; }
    }

    [XmlRoot(ElementName = "Revision", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
    public class Revision2
    {
        [XmlElement(ElementName = "Number", Namespace = "http://www.icasi.org/CVRF/schema/cvrf/1.1")]
        public string Number { get; set; }
        [XmlElement(ElementName = "Date", Namespace = "http://www.icasi.org/CVRF/schema/cvrf/1.1")]
        public string Date { get; set; }
        [XmlElement(ElementName = "Description", Namespace = "http://www.icasi.org/CVRF/schema/cvrf/1.1")]
        public string Description { get; set; }
    }

    [XmlRoot(ElementName = "RevisionHistory", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
    public class RevisionHistory2
    {
        [XmlElement(ElementName = "Revision", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
        public List<Revision2> Revision2 { get; set; }
    }

    [XmlRoot(ElementName = "Vulnerability", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
    public class Vulnerability
    {
        [XmlElement(ElementName = "Title", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
        public string Title { get; set; }
        [XmlElement(ElementName = "Notes", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
        public Notes Notes { get; set; }
        [XmlElement(ElementName = "CVE", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
        public string CVE { get; set; }
        [XmlElement(ElementName = "ProductStatuses", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
        public ProductStatuses ProductStatuses { get; set; }
        [XmlElement(ElementName = "Threats", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
        public Threats Threats { get; set; }
        [XmlElement(ElementName = "Remediations", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
        public Remediations Remediations { get; set; }
        [XmlElement(ElementName = "Acknowledgments", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
        public Acknowledgments Acknowledgments { get; set; }
        [XmlElement(ElementName = "RevisionHistory", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
        public RevisionHistory2 RevisionHistory2 { get; set; }
        [XmlAttribute(AttributeName = "Ordinal")]
        public string Ordinal { get; set; }
        [XmlElement(ElementName = "CVSSScoreSets", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
        public CVSSScoreSets CVSSScoreSets { get; set; }
    }

    [XmlRoot(ElementName = "ScoreSet", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
    public class ScoreSet
    {
        [XmlElement(ElementName = "BaseScore", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
        public string BaseScore { get; set; }
        [XmlElement(ElementName = "TemporalScore", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
        public string TemporalScore { get; set; }
        [XmlElement(ElementName = "Vector", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
        public string Vector { get; set; }
        [XmlElement(ElementName = "ProductID", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
        public string ProductID { get; set; }
    }

    [XmlRoot(ElementName = "CVSSScoreSets", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
    public class CVSSScoreSets
    {
        [XmlElement(ElementName = "ScoreSet", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
        public List<ScoreSet> ScoreSet { get; set; }
    }

    [XmlRoot(ElementName = "cvrfdoc", Namespace = "http://www.icasi.org/CVRF/schema/cvrf/1.1")]
    public class Cvrfdoc
    {
        [XmlElement(ElementName = "DocumentTitle", Namespace = "http://www.icasi.org/CVRF/schema/cvrf/1.1")]
        public string DocumentTitle { get; set; }
        [XmlElement(ElementName = "DocumentType", Namespace = "http://www.icasi.org/CVRF/schema/cvrf/1.1")]
        public string DocumentType { get; set; }
        [XmlElement(ElementName = "DocumentPublisher", Namespace = "http://www.icasi.org/CVRF/schema/cvrf/1.1")]
        public DocumentPublisher DocumentPublisher { get; set; }
        [XmlElement(ElementName = "DocumentTracking", Namespace = "http://www.icasi.org/CVRF/schema/cvrf/1.1")]
        public DocumentTracking DocumentTracking { get; set; }
        [XmlElement(ElementName = "DocumentNotes", Namespace = "http://www.icasi.org/CVRF/schema/cvrf/1.1")]
        public DocumentNotes DocumentNotes { get; set; }
        [XmlElement(ElementName = "ProductTree", Namespace = "http://www.icasi.org/CVRF/schema/prod/1.1")]
        public ProductTree ProductTree { get; set; }
        [XmlElement(ElementName = "Vulnerability", Namespace = "http://www.icasi.org/CVRF/schema/vuln/1.1")]
        public List<Vulnerability> Vulnerability { get; set; }
        [XmlAttribute(AttributeName = "cpe-lang", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Cpelang { get; set; }
        [XmlAttribute(AttributeName = "scap-core", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Scapcore { get; set; }
        [XmlAttribute(AttributeName = "cvrf-common", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Cvrfcommon { get; set; }
        [XmlAttribute(AttributeName = "dc", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Dc { get; set; }
        [XmlAttribute(AttributeName = "prod", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Prod { get; set; }
        [XmlAttribute(AttributeName = "cvssv2", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Cvssv2 { get; set; }
        [XmlAttribute(AttributeName = "vuln", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Vuln { get; set; }
        [XmlAttribute(AttributeName = "sch", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Sch { get; set; }
        [XmlAttribute(AttributeName = "cvrf", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Cvrf { get; set; }
    }
}
