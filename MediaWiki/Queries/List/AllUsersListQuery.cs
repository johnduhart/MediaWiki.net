using MediaWiki.Models;

namespace MediaWiki.Queries.List
{
    [Query("allusers", "au")]
    public class AllUsersListQuery : ListQuery<AllUsersListQuery, User>
    {
        [QueryParameter("from")]
        public string From { get; set; }

        [QueryParameter("to")]
        public string To { get; set; }

        [QueryParameter("prefix")]
        public string Prefix { get; set; }
    }
}