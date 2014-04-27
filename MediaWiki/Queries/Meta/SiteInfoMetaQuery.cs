using System;
using System.Linq;
using MediaWiki.Extensions;
using MediaWiki.Models.SiteInfo;
using RestSharp.Extensions;
using ServiceStack.Text;

namespace MediaWiki.Queries.Meta
{
    [Query("siteinfo", "si", FullJson = true)]
    public class SiteInfoMetaQuery : MetaQuery<SiteInfoMetaQuery, SiteInfoResult>
    {
        [QueryParameter("prop")]
        public SiteInfoProperties Properties { get; set; }

        [QueryParameter]
        public bool ShowAllDb { get; set; }

        [QueryParameter]
        public bool NumberInGroup { get; set; }

        [QueryParameter("inlanguagecode")]
        public string LanguageCode { get; set; }

        // TODO: Missing: filteriw

        public override object BuildResultFullJson(JsonObject jsonObject)
        {
            var result = new SiteInfoResult();
            var enumValues = Enum.GetValues(typeof(SiteInfoProperties));
            var resultProperties = typeof(SiteInfoResult).GetPublicProperties();

            foreach (Enum enumValue in enumValues)
            {
                if (!Properties.HasFlag(enumValue))
                {
                    continue;
                }

                var enumName = enumValue.GetEnumValue();

                // Find the matching property
                var property =
                    resultProperties.First(
                        pi =>
                            pi.Name.ToLowerInvariant() == enumName ||
                            (pi.HasAttribute<ApiEnumMappingAttribute>() &&
                             pi.GetAttr<ApiEnumMappingAttribute>().Name == enumName));

                string json = jsonObject.Child(enumName);
                object deserialized = JsonSerializer.DeserializeFromString(json, property.PropertyType);
                property.SetValue(result,
                    deserialized);
            }

            return result;
        }
    }
}
