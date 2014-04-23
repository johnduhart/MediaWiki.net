using System.Runtime.Serialization;

namespace MediaWiki.Models.SiteInfo
{
    [DataContract]
    public class Extension
    {
        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "descriptionmsg")]
        public string DescriptionMessage { get; set; }

        [DataMember(Name = "author")]
        public string Author { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "version")]
        public string Version { get; set; }

        // TODO: SVN REV?

        [DataMember(Name = "license-name")]
        public string LicenseName { get; set; }

        [DataMember(Name = "license")]
        public string LicensePath { get; set; }
    }
}