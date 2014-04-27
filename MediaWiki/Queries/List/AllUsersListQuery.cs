using MediaWiki.Models;

namespace MediaWiki.Queries.List
{
    [Query("allusers", "au")]
    public class AllUsersListQuery : ListQuery<AllUsersListQuery, User>
    {
        [QueryParameter]
        public string From { get; set; }

        [QueryParameter]
        public string To { get; set; }

        [QueryParameter]
        public string Prefix { get; set; }
    }
}