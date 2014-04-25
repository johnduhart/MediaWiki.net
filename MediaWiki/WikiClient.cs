using MediaWiki.Actions;
using MediaWiki.Queries;
using MediaWiki.Results;
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

        public ApiResult<QueryResult> Query(params Query[] queries)
        {
            var queryAction = new QueryAction();

            foreach (var query in queries)
            {
                queryAction.AddQuery(query);
            }

            return Execute(queryAction);
        }

        internal ApiResult<TResult> Execute<TResult>(IApiAction<TResult> apiAction)
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
}
