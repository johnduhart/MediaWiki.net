using System.Runtime.Serialization;

namespace MediaWiki.Models.SiteInfo
{
    [DataContract]
    public class ImageSize
    {
        [DataMember(Name = "width")]
        public ushort Width { get; set; }

        [DataMember(Name = "height")]
        public ushort Height { get; set; }
    }
}