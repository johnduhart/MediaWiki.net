using System.Runtime.Serialization;

namespace MediaWiki.Models
{
    [DataContract]
    public class Page
    {
        [DataMember(Name = "pageid")]
        public uint Id { get; set; }

        [DataMember(Name = "ns")]
        public uint Namespace { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }
    }
}
