using MediaWiki.Actions;
using MediaWiki.Models.SiteInfo;
using MediaWiki.Queries.List;
using MediaWiki.Queries.Meta;
using NUnit.Framework;

namespace MediaWiki.Tests
{
    public class QueryActionTests
    {
        public class TheBuildParameterListMethod
        {
            [Test]
            public void HasProperModuleParameters()
            {
                var queryAction = new QueryAction();
                queryAction.AddQuery(new AllPagesListQuery());
                queryAction.AddQuery(new AllUsersListQuery());
                queryAction.AddQuery(new SiteInfoMetaQuery());

                var parameters = queryAction.BuildParameterList();

                Assert.That(parameters["list"], Is.EqualTo("allpages|allusers"));
                Assert.That(parameters["meta"], Is.EqualTo("siteinfo"));
                Assert.IsFalse(parameters.ContainsKey("prop"));
            }

            [Test]
            public void HandlesFlagEnumQueryParameters()
            {

                var queryAction = new QueryAction();
                queryAction.AddQuery(new SiteInfoMetaQuery
                {
                    Properties = SiteInfoProperties.DbReplicationLag | SiteInfoProperties.Extensions,
                });

                var parameters = queryAction.BuildParameterList();

                Assert.That(parameters["siprop"], Is.EqualTo("dbrepllag|extensions"));
            }

            [Test]
            public void HandlesBoolQueryParameters()
            {

                var queryAction = new QueryAction();
                queryAction.AddQuery(new SiteInfoMetaQuery
                {
                    ShowAllDb = true,
                });

                var parameters = queryAction.BuildParameterList();

                Assert.That(parameters["sishowalldb"], Is.EqualTo("true"));
            }

            [Test]
            public void HandlesStringQueryParameters()
            {

                var queryAction = new QueryAction();
                queryAction.AddQuery(new SiteInfoMetaQuery
                {
                    LanguageCode = "es",
                });

                var parameters = queryAction.BuildParameterList();

                Assert.That(parameters["siinlanguagecode"], Is.EqualTo("es"));
            }
        }
    }
}