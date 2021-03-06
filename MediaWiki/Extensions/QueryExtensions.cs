﻿using MediaWiki.Queries;
using RestSharp.Extensions;

namespace MediaWiki.Extensions
{
    internal static class QueryExtensions
    {
        internal static string GetQueryName(this Query query)
        {
            return GetQueryAttribute(query)
                .Name;
        }

        internal static bool IsFullJson(this Query query)
        {
            return GetQueryAttribute(query)
                .FullJson;
        }

        internal static QueryAttribute GetQueryAttribute(this Query query)
        {
            return query
                .GetType()
                .GetAttribute<QueryAttribute>();
        }
    }
}
