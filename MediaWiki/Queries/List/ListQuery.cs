using System.Collections.Generic;
using MediaWiki.Actions;
using RestSharp.Extensions;
using ServiceStack.Text;

namespace MediaWiki.Queries.List
{
    public abstract class ListQuery : Query
    {
    }

    public abstract class ListQuery<TQuery, TResult> : ListQuery
        where TQuery : ListQuery
        where TResult : class
    {
        public override object BuildResult(string json)
        {
            return JsonSerializer.DeserializeFromString<List<TResult>>(json);
        }

        public static List<TResult> ExtractResults(ApiResult<QueryResult> result)
        {
            // Retrieve the key from the attribute
            var key = typeof(TQuery).GetAttribute<QueryAttribute>().Name;

            return (List<TResult>)result.Result.List[key];
        }
    }
}