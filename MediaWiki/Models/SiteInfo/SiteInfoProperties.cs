using System;

namespace MediaWiki.Models.SiteInfo
{
    [ApiEnum, Flags]
    public enum SiteInfoProperties
    {
        General = 1,
        Namespaces = 2,
        NamespaceAliases = 4,
        SpecialPageAliases = 8,
        MagicWords = 16,
        InterWikiMap = 32,
        [ApiEnumValue("dbrepllag")]
        DbReplicationLag = 64,
        Statistics = 128,
        UserGroups = 256,
        Extensions = 512,
        FileExtensions = 1024,
        RightsInfo = 2048,
        Restrictions = 4096,
        Languages = 8192,
        Skins = 16384,
        ExtensionTags = 32768,
        FunctionHooks = 65536,
        ShowHooks = 131072,
        Variables = 262144,
        Protocols = 524288,
        DefaultOptions = 1048576,
    }
}