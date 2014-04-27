using System.Linq;
using MediaWiki.Queries.List;
using Xunit;
using PageList = System.Collections.Generic.List<MediaWiki.Models.Page>;

namespace MediaWiki.Tests.Integration.Actions.Query.List
{
    public class AllPagesListQueryTests
    {
        private WikiClient _client;

        public AllPagesListQueryTests()
        {
            _client = new WikiClient("https://www.mediawiki.org/w/api.php");
        }

        private PageList ExecuteQuery(AllPagesListQuery query)
        {
            var result = _client.Query(query);
            return AllPagesListQuery.ExtractResults(result);
        }

        [IntegrationTest]
        public void DefaultParameters()
        {
            var allPages = ExecuteQuery(new AllPagesListQuery());

            Assert.NotNull(allPages);
            Assert.NotEmpty(allPages);
            Assert.True(allPages[0].Id > 0);
        }

        [IntegrationTest]
        public void FromParameter()
        {
            var allPages = ExecuteQuery(new AllPagesListQuery {From = "MediaWiki"});

            Assert.NotNull(allPages);
            Assert.NotEmpty(allPages);
            Assert.Equal<uint>(1, allPages[0].Id);
            Assert.Equal<uint>(0, allPages[0].Namespace);
            Assert.Equal("MediaWiki", allPages[0].Title);
        }

        [IntegrationTest]
        public void ContinueParameter()
        {
            var allPages = ExecuteQuery(new AllPagesListQuery { Continue = "MediaWiki" });

            Assert.NotNull(allPages);
            Assert.NotEmpty(allPages);
            Assert.Equal<uint>(1, allPages[0].Id);
            Assert.Equal<uint>(0, allPages[0].Namespace);
            Assert.Equal("MediaWiki", allPages[0].Title);
        }

        [IntegrationTest]
        public void ToParameter()
        {
            const string pageTitle = "$1";
            var allPages = ExecuteQuery(new AllPagesListQuery {To = pageTitle});

            Assert.NotNull(allPages);
            Assert.NotEmpty(allPages);
            var lastPage = allPages.Last();
            Assert.Equal<uint>(120598, lastPage.Id);
            Assert.Equal<uint>(0, lastPage.Namespace);
            Assert.Equal(pageTitle, lastPage.Title);
        }

        [IntegrationTest]
        public void PrefixParameter()
        {
            const string prefix = "$wg";
            var allPages = ExecuteQuery(new AllPagesListQuery {Prefix = prefix});

            Assert.NotNull(allPages);
            Assert.NotEmpty(allPages);
            Assert.True(allPages.All(p => p.Title.StartsWith(prefix)));
        }

        [IntegrationTest]
        public void NamespaceParameter()
        {
            const uint ns = 5;
            var allPages = ExecuteQuery(new AllPagesListQuery {Namespace = ns});

            Assert.NotNull(allPages);
            Assert.NotEmpty(allPages);
            Assert.True(allPages.All(p => p.Namespace == ns));
        }

        [IntegrationTest]
        public void FilterRedirectsParameter()
        {
            const string redirectPage = "$1";
            var allPages = ExecuteQuery(new AllPagesListQuery { FilterRedirects = FilterReadirects.Redirects });

            Assert.NotNull(allPages);
            Assert.NotEmpty(allPages);
            Assert.True(allPages.Any(p => p.Title == redirectPage));
        }

        [IntegrationTest]
        public void FilterNonRedirectsParameter()
        {
            const string redirectPage = "$1";
            var allPages = ExecuteQuery(new AllPagesListQuery { FilterRedirects = FilterReadirects.NonRedirects });

            Assert.NotNull(allPages);
            Assert.NotEmpty(allPages);
            Assert.False(allPages.Any(p => p.Title == redirectPage));
        }
    }
}