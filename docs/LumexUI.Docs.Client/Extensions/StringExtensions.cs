// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Text.RegularExpressions;

namespace LumexUI.Docs.Client.Extensions;

internal static partial class StringExtensions
{
    private static readonly char[] _separators = [' ', '_', '-'];

    public static string? ToKebabCase( this string? value )
    {
        if( string.IsNullOrEmpty( value ) )
        {
            return value;
        }

        var words = value.Split( _separators, StringSplitOptions.RemoveEmptyEntries );
        return string.Join( "-", words ).ToLower();
    }

    public static string SplitPascalCase( this string value )
    {
        if( string.IsNullOrEmpty( value ) )
        {
            return value;
        }

        var words = PascalCaseSplitter().Split( value );
        return string.Join( " ", words );
    }

    [GeneratedRegex( "(?<!^)(?=[A-Z])" )]
    private static partial Regex PascalCaseSplitter();
}
