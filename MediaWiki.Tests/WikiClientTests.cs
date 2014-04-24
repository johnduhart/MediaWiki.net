using System;
using MediaWiki.Queries.Meta;
using Xunit;

namespace MediaWiki.Tests
{
    public class WikiClientTests
    {
        [Fact]
        public void Constructor_GivenValidApiUrl_Succeeds()
        {
            new WikiClient("https://www.mediawiki.org/w/api.php");
        }

        [Fact(Skip = "Not yet complete")]
        public void Constructor_GivenInvalidApiUrl_ThrowsException()
        {
            Assert.Throws<Exception>(() => new WikiClient("not a URL"));
        }
    }
}
