using System.Runtime.Serialization;

namespace MediaWiki.Models.SiteInfo
{
    [DataContract]
    public class SpecialPageAlias
    {
        [DataMember(Name = "realname")]
        public string RealName { get; set; }

        [DataMember(Name = "aliases")]
        public string[] Aliases { get; set; }
    }
}