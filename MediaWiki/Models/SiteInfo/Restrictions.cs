using System.Runtime.Serialization;

namespace MediaWiki.Models.SiteInfo
{
    [DataContract]
    public class Restrictions
    {
        [DataMember(Name = "types")]
        public string[] Types { get; set; }

        [DataMember(Name = "levels")]
        public string[] Levels { get; set; }

        [DataMember(Name = "cascadinglevels")]
        public string[] CascadingLevels { get; set; }

        [DataMember(Name = "semiprotectedlevels")]
        public string[] SemiProtectedLevels { get; set; }
    }
}