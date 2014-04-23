using System.Runtime.Serialization;

namespace MediaWiki.Models.SiteInfo
{
    [DataContract]
    public class Statistics
    {
        [DataMember(Name = "pages")]
        public uint Pages { get; set; }

        [DataMember(Name = "articles")]
        public uint Articles { get; set; }

        [DataMember(Name = "edits")]
        public uint Edits { get; set; }

        [DataMember(Name = "images")]
        public uint Images { get; set; }

        [DataMember(Name = "users")]
        public uint Users { get; set; }

        [DataMember(Name = "activeusers")]
        public uint ActiveUsers { get; set; }

        [DataMember(Name = "admins")]
        public uint Admins { get; set; }

        [DataMember(Name = "jobs")]
        public uint Jobs { get; set; }
    }
}