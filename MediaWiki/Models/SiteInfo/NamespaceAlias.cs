using System.Runtime.Serialization;

namespace MediaWiki.Models.SiteInfo
{
    [DataContract]
    public class NamespaceAlias
    {
        [DataMember(Name = "id")]
        public uint Id { get; set; }

        [DataMember(Name = "*")]
        public string Alias { get; set; }
    }
}