using RestSharp;

namespace MediaWiki.Results
{
    public class ApiResult<T>
        where T : class
    {
        public T Result { get; set; }

        public IRestResponse Response { get; set; }
    }
}