using System;
using System.Linq;
using System.Reflection;

namespace MediaWiki.Extensions
{
    internal static class ReflectionExtensions
    {
        public static object[] AllAttributes(this MemberInfo memberInfo)
        {
            return memberInfo.GetCustomAttributes(true).ToArray();
        }

        public static bool HasAttribute<TAttr>(this MemberInfo propertyInfo)
        {
            return propertyInfo.AllAttributes().Any(a => a.GetType() == typeof(TAttr));
        }

        public static TAttr GetAttribute<TAttr>(this MemberInfo memberInfo) where TAttr : class
        {
            return Attribute.GetCustomAttribute(memberInfo, typeof(TAttr)) as TAttr;
        }

        // FUCKING RESTSHARP AND THEIR PUBLIC EXTENSIONS
        public static TAttr GetAttr<TAttr>(this MemberInfo memberInfo) where TAttr : class
        {
            return GetAttribute<TAttr>(memberInfo);
        }
    }
}