using System.Linq;
using MediaWiki.Queries.List;
using Xunit;
using UserList = System.Collections.Generic.List<MediaWiki.Models.User>;

namespace MediaWiki.Tests.Integration.Actions.Query.List
{
    public class AllUsersListQueryTests
    {
        private WikiClient _client;

        public AllUsersListQueryTests()
        {
            _client = new WikiClient("https://www.mediawiki.org/w/api.php");
        }

        private UserList ExecuteQuery(AllUsersListQuery query)
        {
            var result = _client.Query(query);
            return AllUsersListQuery.ExtractResults(result);
        }

        [IntegrationTest]
        public void DefaultParameters()
        {
            var allUsers = ExecuteQuery(new AllUsersListQuery());

            Assert.NotNull(allUsers);
            Assert.NotEmpty(allUsers);
            Assert.True(allUsers[0].Id > 0);
        }

        [IntegrationTest]
        public void FromParameter()
        {
            const string username = "Johnduhart";
            var allUsers = ExecuteQuery(new AllUsersListQuery{From = username});

            Assert.NotNull(allUsers);
            Assert.NotEmpty(allUsers);
            Assert.Equal(username, allUsers[0].Name);
            Assert.True(allUsers[0].Id > 0);
        }

        [IntegrationTest]
        public void ToParameter()
        {
            const string username = "! ari-ari-ari !";
            var allUsers = ExecuteQuery(new AllUsersListQuery { To = username });

            Assert.NotNull(allUsers);
            Assert.NotEmpty(allUsers);
            Assert.Equal(username, allUsers.Last().Name);
        }

        [IntegrationTest]
        public void PrefixParameter()
        {
            const string prefix = "Tim";
            var allUsers = ExecuteQuery(new AllUsersListQuery { Prefix = prefix });

            Assert.NotNull(allUsers);
            Assert.NotEmpty(allUsers);
            Assert.True(allUsers.All(u => u.Name.StartsWith(prefix)));
        }
    }
}