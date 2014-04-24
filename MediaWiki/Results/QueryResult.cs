using System.Collections.Generic;

namespace MediaWiki.Results
{
    public class QueryResult
    {
        public Dictionary<string, object> List { get; set; }
        public Dictionary<string, object> Meta { get; set; }
    }
}