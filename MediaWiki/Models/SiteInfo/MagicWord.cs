using System.Runtime.Serialization;

namespace MediaWiki.Models.SiteInfo
{
    [DataContract]
    public class MagicWord
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "aliases")]
        public string[] Aliases { get; set; }

        [DataMember(Name = "case-sensitive")]
        public bool CaseSensitive { get; set; }
    }
}