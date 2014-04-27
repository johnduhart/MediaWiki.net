using System;
using System.Collections.Generic;
using System.Linq;
using MediaWiki.Extensions;
using MediaWiki.Queries;
using MediaWiki.Queries.List;
using MediaWiki.Queries.Meta;
using MediaWiki.Results;
using RestSharp;
using RestSharp.Extensions;
using ServiceStack.Text;
using JsonObject = ServiceStack.Text.JsonObject;

namespace MediaWiki.Actions
{
    public class QueryAction : IApiAction<QueryResult>
    {
        private readonly List<Query> _queries = new List<Query>();

        private IEnumerable<ListQuery> ListQueries
        {
            get { return GetQueries<ListQuery>(); }
        }

        private IEnumerable<MetaQuery> MetaQueries
        {
            get { return GetQueries<MetaQuery>(); }
        }

        public string Action { get { return "query"; } }
        public Method RequestMethod { get { return Method.GET; } }

        public void AddQuery(Query listQuery)
        {
            _queries.Add(listQuery);
        }

        private IEnumerable<TQuery> GetQueries<TQuery>()
        {
            return _queries.Where(q => q.GetType().IsInstanceOf(typeof(TQuery))).Cast<TQuery>();
        }

        public Dictionary<string, string> BuildParameterList()
        {
            var parameters = new Dictionary<string, string>();
            var modules = new Dictionary<string, List<string>>
            {
                {"list", new List<string>()},
                {"prop", new List<string>()},
                {"meta", new List<string>()},
            };

            // Add lists to the query
            BuildQueries(modules["list"], parameters, ListQueries);
            BuildQueries(modules["meta"], parameters, MetaQueries);

            foreach (var pair in modules.Where(pair => pair.Value.Count > 0))
            {
                parameters.Add(pair.Key, string.Join("|", pair.Value));
            }

            return parameters;
        }

        private void BuildQueries<TQuery>(List<string> moduleNames, Dictionary<string, string> parameters, IEnumerable<TQuery> queryList)
        {
            foreach (var query in queryList)
            {
                var queryType = query.GetType();
                var queryAttribute = queryType.GetAttribute<QueryAttribute>();

                if (queryAttribute == null)
                {
                    // This is not a query
                    continue;
                }

                moduleNames.Add(queryAttribute.Name);

                var queryParameters =
                    queryType.GetPublicProperties().Where(prop => prop.HasAttribute<QueryParameterAttribute>());
                var parameterPrefix = queryAttribute.Prefix;

                foreach (var parameter in queryParameters)
                {
                    var attribute = parameter.GetAttr<QueryParameterAttribute>();
                    var name = attribute.Name ?? parameter.Name.ToLowerInvariant();
                    var parameterName = parameterPrefix + name;

                    var value = parameter.GetValue(query);
                    if (value == null)
                    {
                        continue;
                    }

                    var propertyType = parameter.PropertyType;
                    if (propertyType == typeof (string))
                    {
                        parameters.Add(parameterName, (string) value);
                    }
                    else if (propertyType == typeof (bool))
                    {
                        if ((bool) value)
                            parameters.Add(parameterName, "true");
                    }
                    else if (propertyType.IsEnum)
                    {
                        var @enum = ((Enum) value);
                        if (!propertyType.HasAttribute<FlagsAttribute>())
                        {
                            // Not flags based
                            parameters.Add(parameterName, @enum.GetEnumValue());
                            continue;
                        }

                        var values = new List<string>();
                        var enumValues = Enum.GetValues(propertyType);

                        foreach (Enum enumValue in enumValues)
                        {
                            if (@enum.HasFlag(enumValue))
                            {
                                values.Add(enumValue.GetEnumValue());
                            }
                        }

                        parameters.Add(parameterName, string.Join("|", values));
                    }
                    else if (propertyType.IsValueType)
                    {
                        parameters.Add(parameterName, value.ToString());
                    }
                }
            }
        }

        public QueryResult BuildResult(JsonObject jsonObject)
        {
            return new QueryResult
            {
                List = BuildResultsForQueries(jsonObject, ListQueries),
                Meta = BuildResultsForQueries(jsonObject, MetaQueries),
            };
        }

        private Dictionary<string, object> BuildResultsForQueries<TQuery>(JsonObject jsonObject, IEnumerable<TQuery> queries)
            where TQuery : Query
        {
            var results = new Dictionary<string, object>();

            foreach (var query in queries)
            {
                object result;
                var name = query.GetQueryName();

                if (query.IsFullJson())
                {
                    result = query.BuildResultFullJson(jsonObject);
                }
                else
                {
                    string json = jsonObject.Child(name);
                    result = query.BuildResult(json);
                }

                results.Add(name, result);
            }

            return results;
        }
    }
}
