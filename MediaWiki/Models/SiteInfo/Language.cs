using System.Runtime.Serialization;

namespace MediaWiki.Models.SiteInfo
{
    [DataContract]
    public class Language
    {
        [DataMember(Name = "code")]
        public string Code { get; set; }

        [DataMember(Name = "*")]
        public string Name { get; set; }
    }
}