using MediaWiki.Actions;
using MediaWiki.Models.SiteInfo;
using MediaWiki.Queries.List;
using MediaWiki.Queries.Meta;
using Xunit;

namespace MediaWiki.Tests
{
    public class QueryActionTests
    {
        public class TheBuildParameterListMethod
        {
            [Fact]
            public void HasProperModuleParameters()
            {
                var queryAction = new QueryAction();
                queryAction.AddQuery(new AllPagesListQuery());
                queryAction.AddQuery(new AllUsersListQuery());
                queryAction.AddQuery(new SiteInfoMetaQuery());

                var parameters = queryAction.BuildParameterList();

                Assert.Equal(parameters["list"], "allpages|allusers");
                Assert.Equal(parameters["meta"], "siteinfo");
                Assert.False(parameters.ContainsKey("prop"));
            }

            [Fact]
            public void HandlesFlagEnumQueryParameters()
            {

                var queryAction = new QueryAction();
                queryAction.AddQuery(new SiteInfoMetaQuery
                {
                    Properties = SiteInfoProperties.DbReplicationLag | SiteInfoProperties.Extensions,
                });

                var parameters = queryAction.BuildParameterList();

                Assert.Equal(parameters["siprop"], "dbrepllag|extensions");
            }

            [Fact]
            public void HandlesBoolQueryParameters()
            {

                var queryAction = new QueryAction();
                queryAction.AddQuery(new SiteInfoMetaQuery
                {
                    ShowAllDb = true,
                });

                var parameters = queryAction.BuildParameterList();

                Assert.Equal(parameters["sishowalldb"], "true");
            }

            [Fact]
            public void HandlesStringQueryParameters()
            {

                var queryAction = new QueryAction();
                queryAction.AddQuery(new SiteInfoMetaQuery
                {
                    LanguageCode = "es",
                });

                var parameters = queryAction.BuildParameterList();

                Assert.Equal(parameters["siinlanguagecode"], "es");
            }
        }
    }
}