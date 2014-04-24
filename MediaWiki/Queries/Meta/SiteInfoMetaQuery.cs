using System;
using System.Linq;
using MediaWiki.Models.SiteInfo;
using RestSharp.Extensions;
using ServiceStack;
using ServiceStack.Text;

namespace MediaWiki.Queries.Meta
{
    [Query("siteinfo", "si", FullJson = true)]
    public class SiteInfoMetaQuery : MetaQuery
    {
        [QueryParameter("prop")]
        public SiteInfoProperties Properties { get; set; }

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
                             pi.GetAttribute<ApiEnumMappingAttribute>().Name == enumName));

                string json = jsonObject.Child(enumName);
                object deserialized = JsonSerializer.DeserializeFromString(json, property.PropertyType);
                property.SetValue(result,
                    deserialized);
            }

            return result;
        }
    }

    [ApiEnum, Flags]
    public enum SiteInfoProperties
    {
        General = 1,
        Namespaces = 2,
        NamespaceAliases = 4,
        SpecialPageAliases = 8,
        MagicWords = 16,
        InterWikiMap = 32,
        [ApiEnumValue("dbrepllag")]
        DbReplicationLag = 64,
        Statistics = 128,
        UserGroups = 256,
        Extensions = 512,
        FileExtensions = 1024,
        RightsInfo = 2048,
        Restrictions = 4096,
        Languages = 8192,
        Skins = 16384,
        ExtensionTags = 32768,
        FunctionHooks = 65536,
        ShowHooks = 131072,
        Variables = 262144,
        Protocols = 524288,
        DefaultOptions = 1048576,
    }
}
