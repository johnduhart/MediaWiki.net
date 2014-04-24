using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MediaWiki.Models
{
    [DataContract]
    public class User
    {
        [DataMember(Name = "userid")]
        public uint Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "anon")]
        public bool Anonymous { get; set; }
    }
}
