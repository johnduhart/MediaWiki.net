using System.Runtime.Serialization;

namespace MediaWiki.Models.SiteInfo
{
    [DataContract]
    public class SiteInfoDbReplicationLag
    {
        [DataMember(Name = "host")]
        public string Host { get; set; }

        [DataMember(Name = "lag")]
        public int Lag { get; set; }
    }
}