// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

namespace LumexUI.Utilities;

[ExcludeFromCodeCoverage]
internal static class Utils
{
    internal static string GetDataAttributeValue( bool value )
    {
        return value ? "true" : "false";
    }

    internal static string GetDataAttributeValue( Enum value )
    {
        return value.ToLowerInvariant();
    }
}
