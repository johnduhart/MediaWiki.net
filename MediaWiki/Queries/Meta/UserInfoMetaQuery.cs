using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MediaWiki.Models;

namespace MediaWiki.Queries.Meta
{
    [Query("userinfo", "ui")]
    public class UserInfoMetaQuery : MetaQuery<UserInfoMetaQuery, UserInfoMeta>
    {
        [QueryParameter("prop")]
        public UserInfoProperties Properties { get; set; }
    }

    public class UserInfoMeta : UserInfo
    {
        [DataMember(Name = "ratelimits")]
        public Dictionary<string, ActionRateLimit> RateLimits { get; set; }

        [DataMember(Name = "realname")]
        public string RealName { get; set; }

        [DataMember(Name = "acceptlang")]
        public List<AcceptLang> AcceptLang { get; set; }
    }

    public class AcceptLang
    {
        [DataMember(Name = "*")]
        public string Lang { get; set; }

        [DataMember(Name = "q")]
        public double Value { get; set; }
    }

    public class ActionRateLimit
    {
        [DataMember(Name = "anon")]
        public RateLimit Anonymous { get; set; }

        [DataMember(Name = "user")]
        public RateLimit User { get; set; }

        [DataMember(Name = "ip")]
        public RateLimit Ip { get; set; }

        [DataMember(Name = "subnet")]
        public RateLimit Subnet { get; set; }

        [DataMember(Name = "newbie")]
        public RateLimit Newbie { get; set; }
    }

    public class RateLimit
    {
        [DataMember(Name = "hits")]
        public uint Hits { get; set; }

        [DataMember(Name = "seconds")]
        public uint Seconds { get; set; }
    }

    public class UserInfo : User
    {
        [DataMember(Name = "registration")]
        public DateTime Registration { get; set; }

        [DataMember(Name = "groups")]
        public List<string> Groups { get; set; }

        [DataMember(Name = "implicitgroups")]
        public List<string> ImplicitGroups { get; set; }

        [DataMember(Name = "rights")]
        public List<string> Rights { get; set; }

        [DataMember(Name = "editcount")]
        public uint EditCount { get; set; }

        [DataMember(Name = "changeablegroups")]
        public ChangeableGroups ChangeableGroups { get; set; }

        [DataMember(Name = "options")]
        public Dictionary<string, object> Options { get; set; }

        [DataMember(Name = "preferencestoken")]
        public string PreferencesToken { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "emailauthenticated")]
        public DateTime EmailAuthenticated { get; set; }
    }

    public class ChangeableGroups
    {
        [DataMember(Name = "add")]
        public string[] AddGroup { get; set; }

        [DataMember(Name = "remove")]
        public string[] RemoveGroup { get; set; }

        [DataMember(Name = "add-self")]
        public string[] AddGroupSelf { get; set; }

        [DataMember(Name = "remove-self")]
        public string[] RemoveGroupSelf { get; set; }
    }

    [ApiEnum, Flags]
    public enum UserInfoProperties
    {
        BlockInfo = (1 << 0),
        [ApiEnumValue("hasmsg")]
        HasMessage = (1 << 1),
        Groups = (1 << 2),
        ImplicitGroups = (1 << 3),
        Rights = (1 << 4),
        ChangeableGroups = (1 << 5),
        Options = (1 << 6),
        PreferencesToken = (1 << 7),
        EditCount = (1 << 8),
        RateLimits = (1 << 9),
        RealName = (1 << 10),
        Email = (1 << 11),
        AcceptLang = (1 << 12),
        RegistrationDate = (1 << 13),
    }
}