using System.Runtime.Serialization;

namespace MediaWiki.Models.SiteInfo
{
    [DataContract]
    public class Hook
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "subscribers")]
        public string[] Subscribers { get; set; }
    }
}