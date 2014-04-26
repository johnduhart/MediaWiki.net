using MediaWiki.Models;

namespace MediaWiki.Queries.List
{
    [Query("allpages", "ap")]
    public class AllPagesListQuery : ListQuery<AllPagesListQuery, Page>
    {
        [QueryParameter("from")]
        public string From { get; set; }

        [QueryParameter("continue")]
        public string Continue { get; set; }

        [QueryParameter("to")]
        public string To { get; set; }

        [QueryParameter("prefix")]
        public string Prefix { get; set; }

        [QueryParameter("namespace")]
        public uint Namespace { get; set; }

        [QueryParameter("filterredir")]
        public FilterReadircts FilterRedirects { get; set; }
    }

    [ApiEnum]
    public enum FilterReadircts
    {
        All,
        Redirects,
        NonRedirects,
    }
}