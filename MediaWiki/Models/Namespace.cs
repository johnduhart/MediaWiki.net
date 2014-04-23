using System.Runtime.Serialization;

namespace MediaWiki.Models
{
    [DataContract]
    public class Namespace
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "case")]
        public string Case { get; set; }

        [DataMember(Name = "*")]
        public string Name { get; set; }

        [DataMember(Name = "subpages")]
        public bool SubPages { get; set; }

        [DataMember(Name = "content")]
        public bool Content { get; set; }

        [DataMember(Name = "canonical")]
        public string Canonical { get; set; }

        [DataMember(Name = "nonincludable")]
        public bool NonIncludeable { get; set; }
    }
}