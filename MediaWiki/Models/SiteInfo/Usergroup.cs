using System.Runtime.Serialization;

namespace MediaWiki.Models.SiteInfo
{
    [DataContract]
    public class Usergroup
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "rights")]
        public string[] Rights { get; set; }

        [DataMember(Name = "number")]
        public uint UserCount { get; set; }

        [DataMember(Name = "add")]
        public string[] AddGroup { get; set; }

        [DataMember(Name = "remove")]
        public string[] RemoveGroup { get; set; }

        [DataMember(Name = "add-self")]
        public string[] AddGroupSelf { get; set; }

        [DataMember(Name = "remove-self")]
        public string[] RemoveGroupSelf { get; set; }
    }
}