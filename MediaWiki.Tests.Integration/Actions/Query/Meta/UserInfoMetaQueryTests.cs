using System;
using MediaWiki.Queries.Meta;
using Xunit;

namespace MediaWiki.Tests.Integration.Actions.Query.Meta
{
    public class UserInfoMetaQueryTests
    {
        private WikiClient _client;

        public UserInfoMetaQueryTests()
        {
            _client = new WikiClient("https://www.mediawiki.org/w/api.php");
        }

        private UserInfoMeta ExecuteWithProperty(UserInfoProperties? properties)
        {
            var query = new UserInfoMetaQuery();

            if (properties.HasValue)
                query.Properties = properties.Value;

            var result = _client.Query(query);
            return UserInfoMetaQuery.ExtractResults(result);
        }

        [IntegrationTest]
        public void BasicInfo()
        {
            var userInfo = ExecuteWithProperty(null);

            Assert.NotNull(userInfo);
            Assert.Equal<uint>(0, userInfo.Id);
            Assert.True(userInfo.Anonymous);
        }

        [IntegrationTest(Skip = "Block information is not implemented")]
        public void BlockInfo()
        {
            var userInfo = ExecuteWithProperty(UserInfoProperties.BlockInfo);
        }

        [IntegrationTest(Skip = "TODO: Message test")]
        public void HasMessage()
        {
            var userInfo = ExecuteWithProperty(UserInfoProperties.HasMessage);
        }

        [IntegrationTest]
        public void Groups()
        {
            var userInfo = ExecuteWithProperty(UserInfoProperties.Groups);

            Assert.NotNull(userInfo);
            Assert.NotEmpty(userInfo.Groups);
            Assert.Contains("*", userInfo.Groups);
        }

        [IntegrationTest]
        public void ImplicitGroups()
        {
            var userInfo = ExecuteWithProperty(UserInfoProperties.ImplicitGroups);

            Assert.NotNull(userInfo);
            Assert.NotEmpty(userInfo.ImplicitGroups);
            Assert.Contains("*", userInfo.ImplicitGroups);
        }

        [IntegrationTest]
        public void Rights()
        {
            var userInfo = ExecuteWithProperty(UserInfoProperties.Rights);

            Assert.NotNull(userInfo);
            Assert.NotEmpty(userInfo.Rights);
            Assert.Contains("read", userInfo.Rights);
        }

        [IntegrationTest]
        public void ChangeableGroups()
        {
            var userInfo = ExecuteWithProperty(UserInfoProperties.ChangeableGroups);

            Assert.NotNull(userInfo);
            Assert.NotNull(userInfo.ChangeableGroups);
        }

        [IntegrationTest]
        public void Options()
        {
            var userInfo = ExecuteWithProperty(UserInfoProperties.Options);

            Assert.NotNull(userInfo);
            Assert.NotNull(userInfo.Options);
            Assert.Equal("default", userInfo.Options["date"]);
        }

        [IntegrationTest]
        public void PreferencesToken()
        {
            var userInfo = ExecuteWithProperty(UserInfoProperties.PreferencesToken);

            Assert.NotNull(userInfo);
            Assert.NotNull(userInfo.PreferencesToken);
            Assert.Equal("+\\", userInfo.PreferencesToken);
        }

        [IntegrationTest(Skip = "Anonymous users do not have edit counts")]
        public void EditCount()
        {
            var userInfo = ExecuteWithProperty(UserInfoProperties.EditCount);

            Assert.NotNull(userInfo);
            Assert.NotNull(userInfo.EditCount);
            Assert.Equal<uint>(0, userInfo.EditCount);
        }

        [IntegrationTest]
        public void RateLimits()
        {
            var userInfo = ExecuteWithProperty(UserInfoProperties.RateLimits);

            Assert.NotNull(userInfo);
            Assert.NotNull(userInfo.RateLimits);
            Assert.Contains("edit", userInfo.RateLimits.Keys);
        }

        [IntegrationTest(Skip = "Anonymous users do not have real names")]
        public void RealName()
        {
            var userInfo = ExecuteWithProperty(UserInfoProperties.RealName);

            Assert.NotNull(userInfo);
        }

        [IntegrationTest(Skip = "Anonymous users do not have emails")]
        public void Email()
        {
            var userInfo = ExecuteWithProperty(UserInfoProperties.Email);

            Assert.NotNull(userInfo);
            Assert.True(userInfo.Email != "");
        }

        [IntegrationTest(Skip = "Anonymous users do not have registrations")]
        public void RegistrationDate()
        {
            var userInfo = ExecuteWithProperty(UserInfoProperties.RegistrationDate);

            Assert.NotNull(userInfo);
        }

        [IntegrationTest(Skip = "RestSharp does not pass an AcceptLang")]
        public void AcceptLang()
        {
            var userInfo = ExecuteWithProperty(UserInfoProperties.AcceptLang);

            Assert.NotNull(userInfo);
            Assert.NotNull(userInfo.AcceptLang);
            Assert.NotEmpty(userInfo.AcceptLang);
        }
    }
}