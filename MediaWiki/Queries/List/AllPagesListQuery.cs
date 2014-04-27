using MediaWiki.Models;

namespace MediaWiki.Queries.List
{
    [Query("allpages", "ap")]
    public class AllPagesListQuery : ListQuery<AllPagesListQuery, Page>
    {
        [QueryParameter]
        public string From { get; set; }

        [QueryParameter]
        public string Continue { get; set; }

        [QueryParameter]
        public string To { get; set; }

        [QueryParameter]
        public string Prefix { get; set; }

        [QueryParameter]
        public uint Namespace { get; set; }

        [QueryParameter("filterredir")]
        public FilterReadirects FilterRedirects { get; set; }
    }

    [ApiEnum]
    public enum FilterReadirects
    {
        All,
        Redirects,
        NonRedirects,
    }
}