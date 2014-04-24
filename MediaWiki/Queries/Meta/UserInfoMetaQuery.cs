using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MediaWiki.Models;

namespace MediaWiki.Queries.Meta
{
    [Query("userinfo", "ui")]
    public class UserInfoMetaQuery : MetaQuery<UserInfoMetaQuery, User>
    {
        [QueryParameter("prop")]
        public UserInfoProperties Properties { get; set; }
    }

    public class UserInfo : User
    {
        [DataMember(Name = "registration")]
        public DateTime Registration { get; set; }

        [DataMember(Name = "groups")]
        public List<string> Groups { get; set; }

        [DataMember(Name = "implictgroups")]
        public List<string> ImplictGroups { get; set; }

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
        ImplictGroups = (1 << 3),
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