using System.Runtime.Serialization;

namespace MediaWiki.Models.SiteInfo
{
    [DataContract]
    public class Skin
    {
        [DataMember(Name = "*")]
        public string Name { get; set; }

        [DataMember(Name = "code")]
        public string Code { get; set; }

        [DataMember(Name = "default")]
        public bool Default { get; set; }

        [DataMember(Name = "unusable")]
        public bool Unusable { get; set; }
    }
}