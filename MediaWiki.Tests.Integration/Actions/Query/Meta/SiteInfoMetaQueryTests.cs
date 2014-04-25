using System.Linq;
using MediaWiki.Models.SiteInfo;
using MediaWiki.Queries.Meta;
using Xunit;

namespace MediaWiki.Tests.Integration.Actions.Query.Meta
{
    public class SiteInfoMetaQueryTests
    {
        private WikiClient _client;

        public SiteInfoMetaQueryTests()
        {
            _client = new WikiClient("https://www.mediawiki.org/w/api.php");
        }

        private SiteInfoResult ExecuteWithProperty(SiteInfoProperties properties)
        {
            var query = new SiteInfoMetaQuery { Properties = properties };

            var result = _client.Query(query);
            return SiteInfoMetaQuery.ExtractResults(result);
        }

        [IntegrationTest]
        public void General()
        {
            var general = ExecuteWithProperty(SiteInfoProperties.General).General;

            Assert.Equal("MediaWiki", general.MainPage);
            Assert.Equal("MediaWiki", general.SiteName);
            Assert.NotNull(general.Language);
            Assert.NotNull(general.ImageLimits);
            Assert.NotEmpty(general.ImageLimits);
        }

        [IntegrationTest]
        public void Namespaces()
        {
            var namespaces = ExecuteWithProperty(SiteInfoProperties.Namespaces).Namespaces;

            Assert.NotNull(namespaces);
            Assert.NotEmpty(namespaces);
            Assert.Contains(0, namespaces.Keys);
            Assert.Equal("Talk", namespaces[1].Name);
        }

        [IntegrationTest]
        public void NamespaceAliases()
        {
            var namespaceAliases = ExecuteWithProperty(SiteInfoProperties.NamespaceAliases).NamespaceAliases;

            Assert.NotNull(namespaceAliases);
            Assert.NotEmpty(namespaceAliases);
            Assert.True(namespaceAliases.Any(a => a.Alias == "Image"));
        }

        [IntegrationTest]
        public void SpecialPageAliases()
        {
            var specialPageAliases = ExecuteWithProperty(SiteInfoProperties.SpecialPageAliases).SpecialPageAliases;

            Assert.NotNull(specialPageAliases);
            Assert.NotEmpty(specialPageAliases);
            Assert.NotEmpty(specialPageAliases[0].Aliases);
        }

        [IntegrationTest]
        public void MagicWords()
        {
            var magicWords = ExecuteWithProperty(SiteInfoProperties.MagicWords).MagicWords;

            Assert.NotNull(magicWords);
            Assert.NotEmpty(magicWords);
            Assert.NotEmpty(magicWords[0].Aliases);
            Assert.True(magicWords.Any(m => m.Name == "notoc"));
        }

        [IntegrationTest]
        public void Statistics()
        {
            var statistics = ExecuteWithProperty(SiteInfoProperties.Statistics).Statistics;

            Assert.NotNull(statistics);
            Assert.True(statistics.Pages > 1);
        }

        [IntegrationTest]
        public void UserGroups()
        {
            var query = new SiteInfoMetaQuery { Properties = SiteInfoProperties.UserGroups, NumberInGroup = true };
            var result = _client.Query(query);

            var userGroups = SiteInfoMetaQuery.ExtractResults(result).UserGroups;

            Assert.NotNull(userGroups);
            Assert.NotEmpty(userGroups);
            Assert.NotEmpty(userGroups[0].Rights);
            Assert.True(userGroups.First(ug => ug.Name == "user").UserCount > 1);
        }

        [IntegrationTest]
        public void Extensions()
        {
            var extensions = ExecuteWithProperty(SiteInfoProperties.Extensions).Extensions;

            Assert.NotNull(extensions);
            Assert.NotEmpty(extensions);
            Assert.NotNull(extensions[0].Name);
        }

        [IntegrationTest]
        public void FileExtensions()
        {
            var fileExtensions = ExecuteWithProperty(SiteInfoProperties.FileExtensions).FileExtensions;

            Assert.NotNull(fileExtensions);
            Assert.NotEmpty(fileExtensions);
            Assert.NotNull(fileExtensions[0].Extension);
        }

        [IntegrationTest]
        public void RightsInfo()
        {
            var rightsInfo = ExecuteWithProperty(SiteInfoProperties.RightsInfo).RightsInfo;

            Assert.NotNull(rightsInfo);
            Assert.NotNull(rightsInfo.Text);
        }

        [IntegrationTest]
        public void Restrictions()
        {
            var restrictions = ExecuteWithProperty(SiteInfoProperties.Restrictions).Restrictions;

            Assert.NotNull(restrictions);
            Assert.NotNull(restrictions.Types);
            Assert.NotEmpty(restrictions.Types);
            Assert.Contains("create", restrictions.Types);
        }

        [IntegrationTest]
        public void Languages()
        {
            var languages = ExecuteWithProperty(SiteInfoProperties.Languages).Languages;

            Assert.NotNull(languages);
            Assert.NotEmpty(languages);
            Assert.True(languages.Any(l => l.Code == "en"));
        }

        [IntegrationTest]
        public void Skins()
        {
            var skins = ExecuteWithProperty(SiteInfoProperties.Skins).Skins;

            Assert.NotNull(skins);
            Assert.NotEmpty(skins);
            Assert.True(skins.Any(s => s.Code == "vector"));
            Assert.DoesNotThrow(() => skins.Single(s => s.Default));
        }

        [IntegrationTest]
        public void ExtensionTags()
        {
            var extensionTags = ExecuteWithProperty(SiteInfoProperties.ExtensionTags).ExtensionTags;

            Assert.NotNull(extensionTags);
            Assert.NotEmpty(extensionTags);
            Assert.Contains("<pre>", extensionTags);
        }

        [IntegrationTest]
        public void FunctionHooks()
        {
            var functionHooks = ExecuteWithProperty(SiteInfoProperties.FunctionHooks).FunctionHooks;

            Assert.NotNull(functionHooks);
            Assert.NotEmpty(functionHooks);
            Assert.Contains("ns", functionHooks);
        }

        [IntegrationTest]
        public void ShowHooks()
        {
            var showHooks = ExecuteWithProperty(SiteInfoProperties.ShowHooks).ShowHooks;

            Assert.NotNull(showHooks);
            Assert.NotEmpty(showHooks);
            Assert.NotEmpty(showHooks[0].Subscribers);
        }

        [IntegrationTest]
        public void Variables()
        {
            var variables = ExecuteWithProperty(SiteInfoProperties.Variables).Variables;

            Assert.NotNull(variables);
            Assert.NotEmpty(variables);
            Assert.Contains("currentmonth", variables);
        }

        [IntegrationTest]
        public void Protocols()
        {
            var protocols = ExecuteWithProperty(SiteInfoProperties.Protocols).Protocols;

            Assert.NotNull(protocols);
            Assert.NotEmpty(protocols);
            Assert.Contains("http://", protocols);
        }

        [IntegrationTest]
        public void DefaultOptions()
        {
            var defaultOptions = ExecuteWithProperty(SiteInfoProperties.DefaultOptions).DefaultOptions;

            Assert.NotNull(defaultOptions);
            Assert.NotEmpty(defaultOptions);
            Assert.Contains("gender", defaultOptions.Keys);
        }
    }
}