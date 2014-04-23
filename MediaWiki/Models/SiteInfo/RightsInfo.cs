using System.Runtime.Serialization;

namespace MediaWiki.Models.SiteInfo
{
    [DataContract]
    public class RightsInfo
    {
        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "text")]
        public string Text { get; set; }
    }
}