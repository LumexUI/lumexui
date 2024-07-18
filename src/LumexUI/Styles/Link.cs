// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal readonly record struct LinkBase
{
    private readonly static string _base = ElementClass.Empty()
        .Add( "relative" )
        .Add( "inline-flex" )
        .Add( "items-center" )
        .Add( "hover:opacity-hover" )
        .Add( "active:opacity-60" )
        .Add( "transition-opacity" )
        .ToString();

    private readonly static string _disabled = ElementClass.Empty()
        .Add( "opacity-disabled" )
        .Add( "pointer-events-none" )
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

    public static string GetStyles( LumexLinkBase link )
    {
        return ElementClass.Empty()
            .Add( _base )
            .Add( _disabled, when: link.Disabled )
            .Add( GetColorStyles( link.Color ) )
            .Add( link.Class )
            .ToString();
    }
}

[ExcludeFromCodeCoverage]
internal readonly record struct Link
{
    private static ElementClass GetUnderlineStyles( Underline underline )
    {
        return ElementClass.Empty()
            .Add( "no-underline", when: underline is Underline.None )
            .Add( "hover:underline", when: underline is Underline.Hover )
            .Add( "underline", when: underline is Underline.Always )
            .Add( "underline-offset-4", when: underline is not Underline.None );
    }

    public static string GetStyles( LumexLink link )
    {
        return ElementClass.Empty()
            .Add( LinkBase.GetStyles( link ) )
            .Add( GetUnderlineStyles( link.Underline ) )
            .Add( link.Class )
            .ToString();
    }
}

[ExcludeFromCodeCoverage]
internal readonly record struct NavLink
{
    private readonly static string _active = ElementClass.Empty()
        .Add( "data-[active=true]:font-semibold" )
        .ToString();

    public static string GetStyles( LumexNavLink navLink )
    {
        return ElementClass.Empty()
            .Add( LinkBase.GetStyles( navLink ) )
            .Add( _active )
            .Add( navLink.Class )
            .ToString();
    }
}
