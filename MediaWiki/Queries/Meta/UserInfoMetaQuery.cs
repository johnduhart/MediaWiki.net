using MediaWiki.Models;
using RestSharp.Extensions;
using ServiceStack.Text;

namespace MediaWiki.Queries.Meta
{
    [Query("userinfo", "ui")]
    public class UserInfoMetaQuery : MetaQuery<UserInfoMetaQuery, User>
    {
        // TODO: Properties
    }

    public abstract class MetaQuery<TQuery, TResult> : MetaQuery
        where TQuery : MetaQuery
        where TResult : class
    {
        public override object BuildResult(string json)
        {
            return JsonSerializer.DeserializeFromString<TResult>(json);
        }

        public static TResult ExtractResults(ApiResult<QueryResult> result)
        {
            // Retrieve the key from the attribute
            var key = typeof(TQuery).GetAttribute<QueryAttribute>().Name;

            return (TResult)result.Result.Meta[key];
        }
    }
}