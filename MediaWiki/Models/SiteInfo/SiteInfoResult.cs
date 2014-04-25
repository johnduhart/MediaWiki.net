using System.Collections.Generic;
using MediaWiki.Queries.Meta;

namespace MediaWiki.Models.SiteInfo
{
    public class SiteInfoResult
    {
        public SiteInfoGeneral General { get; set; }

        public Dictionary<int, Namespace> Namespaces { get; set; }

        public List<NamespaceAlias> NamespaceAliases { get; set; }

        public List<SpecialPageAlias> SpecialPageAliases { get; set; }

        public List<MagicWord> MagicWords { get; set; }

        public List<Interwiki> InterwikiMap { get; set; }

        [ApiEnumMapping("dbrepllag")]
        public List<SiteInfoDbReplicationLag> DbReplicationLag { get; set; }

        public Statistics Statistics { get; set; }

        public List<Usergroup> UserGroups { get; set; }

        public List<Extension> Extensions { get; set; }

        public List<FileExtension> FileExtensions { get; set; }

        public RightsInfo RightsInfo { get; set; }

        public Restrictions Restrictions { get; set; }

        public List<Language> Languages { get; set; }

        public List<Skin> Skins { get; set; }

        public string[] ExtensionTags { get; set; }

        public string[] FunctionHooks { get; set; }

        public List<Hook> ShowHooks { get; set; }

        public string[] Variables { get; set; }

        public string[] Protocols { get; set; }

        public Dictionary<string, string> DefaultOptions { get; set; }
    }
}