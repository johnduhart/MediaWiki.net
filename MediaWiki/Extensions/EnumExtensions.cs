﻿using System;
using MediaWiki.Extensions;

namespace MediaWiki
{
    internal static class EnumExtensions
    {
        internal static string GetEnumValue(this Enum value)
        {
            var enumType = value.GetType();

            if (!enumType.HasAttribute<ApiEnumAttribute>())
                return ToLowerString(value);

            var enumName = Enum.GetName(enumType, value);
            var enumField = enumType.GetField(enumName);

            if (!enumField.HasAttribute<ApiEnumValueAttribute>())
                return ToLowerString(value);

            return enumField.GetAttribute<ApiEnumValueAttribute>().Name;
        }

        internal static string ToLowerString(this object value)
        {
            return value.ToString().ToLowerInvariant();
        }
    }
}
