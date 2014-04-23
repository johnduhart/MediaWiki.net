using System.Runtime.Serialization;

namespace MediaWiki.Models.SiteInfo
{
    [DataContract]
    public class FileExtension
    {
        [DataMember(Name = "ext")]
        public string Extension { get; set; }
    }
}