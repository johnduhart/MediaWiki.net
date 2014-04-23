using System.Collections.Generic;
using System.Linq;
using MediaWiki.Actions;
using MediaWiki.Models;
using MediaWiki.Queries.List;
using MediaWiki.Queries.Meta;
using RestSharp;
using ServiceStack.Text;
using JsonObject = ServiceStack.Text.JsonObject;

namespace MediaWiki
{
    public class WikiClient
    {
        private readonly IRestClient _client;

        static WikiClient()
        {
            JsConfig<bool>.RawDeserializeFn = str => str == "" || bool.Parse(str);
        }

        internal WikiClient(IRestClient client)
        {
            _client = client;
        }

        public WikiClient(string apiUrl)
        {
            _client = new RestClient(apiUrl);
            _client.DefaultParameters.Add(new Parameter
            {
                Name = "format",
                Value = "json",
                Type = ParameterType.GetOrPost
            });
        }

        public void Query()
        {
            var query = new QueryAction();
            query.AddQuery(new AllPagesListQuery
            {
                Namespace = 8,
                From = "B",
            });
            query.AddQuery(new UserInfoMetaQuery());
            query.AddQuery(new SiteInfoMetaQuery
            {
                Properties = SiteInfoProperties.Namespaces | SiteInfoProperties.General | SiteInfoProperties.DbReplicationLag
            });

            var response = Execute(query);

            var pages = AllPagesListQuery.ExtractResults(response);
        }

        private ApiResult<TResult> Execute<TResult>(IApiAction<TResult> apiAction)
            where TResult : class
        {
            var request = new RestRequest("", apiAction.RequestMethod);
            request.AddParameter("action", apiAction.Action);

            var parameters = apiAction.BuildParameterList();
            foreach (var pair in parameters)
            {
                request.AddParameter(pair.Key, pair.Value);
            }

            var response = _client.Execute(request);

            var json = JsonObject.Parse(response.Content);
            var actionJson = json.Object(apiAction.Action);

            var result = new ApiResult<TResult>
            {
                Result = apiAction.BuildResult(actionJson),
                Response = response,
            };

            return result;
        }
    }

    public class ApiResult<T>
        where T : class
    {
        public T Result { get; set; }

        public IRestResponse Response { get; set; }
    }

    public class QueryResult
    {
        public Dictionary<string, object> List { get; set; }
        public Dictionary<string, object> Meta { get; set; }
    }
}
