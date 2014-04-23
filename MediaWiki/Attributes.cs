using System;

namespace MediaWiki
{
    internal class QueryAttribute : Attribute
    {
        public string Name { get; set; }
        public string Prefix { get; set; }
        public bool FullJson { get; set; }

        public QueryAttribute(string name, string prefix)
        {
            Name = name;
            Prefix = prefix;
        }
    }
    internal class QueryParameterAttribute : Attribute
    {
        public string Name { get; set; }

        public QueryParameterAttribute(string name)
        {
            Name = name;
        }
    }
}