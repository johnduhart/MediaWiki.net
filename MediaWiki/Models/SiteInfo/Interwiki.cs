using System.Runtime.Serialization;

namespace MediaWiki.Models.SiteInfo
{
    [DataContract]
    public class InterWiki
    {
        [DataMember(Name = "prefix")]
        public string Prefix { get; set; }

        [DataMember(Name = "local")]
        public bool Local { get; set; }

        [DataMember(Name = "trans")]
        public bool Transcluding { get; set; }

        [DataMember(Name = "language")]
        public string Language { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }
    }
}