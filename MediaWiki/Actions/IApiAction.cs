using System.Collections.Generic;
using RestSharp;
using JsonObject = ServiceStack.Text.JsonObject;

namespace MediaWiki.Actions
{
    public interface IApiAction<out TResult>
        where TResult : class
    {
        string Action { get; }
        Method RequestMethod { get; }
        Dictionary<string, string> BuildParameterList();
        TResult BuildResult(JsonObject jsonObject);
    }
}