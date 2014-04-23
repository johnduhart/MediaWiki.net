using System;
using MediaWiki.Queries.Meta;
using NUnit.Framework;

namespace MediaWiki.Tests
{
    public class WikiClientTests
    {
        [Test]
        public void Constructor_GivenValidApiUrl_Succeeds()
        {
            new WikiClient("https://www.mediawiki.org/w/api.php");
        }

        [Test]
        public void Constructor_GivenInvalidApiUrl_ThrowsException()
        {
            Assert.Throws<Exception>(() => new WikiClient("not a URL"));
        }

        
        [Test]
        public void QueryTest()
        {
            var client = new WikiClient("https://www.mediawiki.org/w/api.php");
            client.Query();

            /*var flags = SiteInfoMetaQuery.SiteInfoProperties.General;
            flags.ToString();*/
        }
    }
}
