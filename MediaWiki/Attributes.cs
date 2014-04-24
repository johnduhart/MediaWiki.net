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

    [AttributeUsage(AttributeTargets.Enum)]
    public class ApiEnumAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class ApiEnumValueAttribute : Attribute
    {
        public ApiEnumValueAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }

    public class ApiEnumMappingAttribute : Attribute
    {
        public string Name { get; set; }

        public ApiEnumMappingAttribute(string name)
        {
            Name = name;
        }
    }
}