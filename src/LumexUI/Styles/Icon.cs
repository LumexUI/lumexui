// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal readonly struct Icon
{
    private readonly static string _base = ElementClass.Empty()
        .Add( "inline-block" )
        .Add( "fill-current" )
        .ToString();

    private static ElementClass GetColorStyles( ThemeColor color )
    {
        return ElementClass.Empty()
            .Add( "text-default", when: color is ThemeColor.Default )
            .Add( "text-primary", when: color is ThemeColor.Primary )
            .Add( "text-secondary", when: color is ThemeColor.Secondary )
            .Add( "text-success", when: color is ThemeColor.Success )
            .Add( "text-warning", when: color is ThemeColor.Warning )
            .Add( "text-danger", when: color is ThemeColor.Danger )
            .Add( "text-info", when: color is ThemeColor.Info );
    }

    public static string GetStyles( LumexIcon icon )
    {
        return ElementClass.Empty()
            .Add( _base )
            .Add( GetColorStyles( icon.Color ) )
            .Add( icon.Class )
            .ToString();
    }
}
