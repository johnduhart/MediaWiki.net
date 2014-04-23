using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MediaWiki.Models.SiteInfo
{
    [DataContract]
    public class SiteInfoGeneral
    {
        [DataMember(Name = "mainpage")]
        public string MainPage { get; set; }

        [DataMember(Name = "base")]
        public string Base { get; set; }

        [DataMember(Name = "sitename")]
        public string SiteName { get; set; }

        [DataMember(Name = "logo")]
        public string Logo { get; set; }

        [DataMember(Name = "generator")]
        public string Generator { get; set; }

        [DataMember(Name = "phpversion")]
        public string PhpVersion { get; set; }

        [DataMember(Name = "phpsapi")]
        public string PhpSapi { get; set; }

        [DataMember(Name = "dbtype")]
        public string DbType { get; set; }

        [DataMember(Name = "dbversion")]
        public string DbVersion { get; set; }

        [DataMember(Name = "imagewhitelistenabled")]
        public bool ImageWhitelistEnabled { get; set; }

        [DataMember(Name = "externalimages")]
        public List<string> ExternalImages { get; set; }

        [DataMember(Name = "langconversion")]
        public bool LanguageConversion { get; set; }

        [DataMember(Name = "titleconversion")]
        public bool TitleConversion { get; set; }

        [DataMember(Name = "linkprefixcharset")]
        public bool LinkPrefixCharset { get; set; }

        [DataMember(Name = "linkprefix")]
        public bool LinkPrefix { get; set; }

        [DataMember(Name = "linktrail")]
        public bool LinkTrail { get; set; }

        [DataMember(Name = "git-hash")]
        public string GitHash { get; set; }

        [DataMember(Name = "rev")]
        public string SvnRevision { get; set; }

        [DataMember(Name = "case")]
        public string Case { get; set; }

        [DataMember(Name = "lang")]
        public string Language { get; set; }
        
        [DataMember(Name = "lang")]
        public string[] FallbackLanguages { get; set; }

        [DataMember(Name = "rtl")]
        public bool RightToLeft { get; set; }

        [DataMember(Name = "fallback8bitencoding")]
        public string Fallback8BitEncoding { get; set; }

        [DataMember(Name = "readonly")]
        public bool ReadOnly { get; set; }

        [DataMember(Name = "readonlyreason")]
        public string ReadOnlyReason { get; set; }

        [DataMember(Name = "writeapi")]
        public bool WriteApiEnabled { get; set; }

        [DataMember(Name = "timezone")]
        public string Timezone { get; set; }

        [DataMember(Name = "timeoffset")]
        public short TimezoneOffset { get; set; }

        [DataMember(Name = "articlepath")]
        public string ArticlePath { get; set; }

        [DataMember(Name = "scriptpath")]
        public string ScriptPath { get; set; }

        [DataMember(Name = "script")]
        public string Script { get; set; }

        [DataMember(Name = "variantarticlepath")]
        public bool VariantArticlePath { get; set; }

        [DataMember(Name = "server")]
        public string Server { get; set; }

        [DataMember(Name = "wikiid")]
        public string WikiId { get; set; }

        [DataMember(Name = "time")]
        public DateTime Time { get; set; }

        [DataMember(Name = "misermode")]
        public bool MiserMode { get; set; }

        [DataMember(Name = "maxuploadsize")]
        public ulong MaxUploadSize { get; set; }

        [DataMember(Name = "thumblimits")]
        public ushort[] ThumbLimits { get; set; }

        [DataMember(Name = "imagelimits")]
        public ImageSize[] ImageLimits { get; set; }

        [DataMember(Name = "favicon")]
        public string FavIcon { get; set; }
    }
}