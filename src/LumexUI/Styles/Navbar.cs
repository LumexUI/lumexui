// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal readonly record struct Navbar
{
    private readonly static string _base = ElementClass.Empty()
        .Add( "z-40" )
        .Add( "flex" )
        .Add( "items-center" )
        .Add( "justify-center" )
        .ToString();

    private readonly static string _wrapper = ElementClass.Empty()
        .Add( "z-40" )
        .Add( "flex" )
        .Add( "px-6" )
        .Add( "gap-6" )
        .Add( "w-full" )
        .Add( "items-center" )
        .Add( "justify-between" )
        .Add( "h-[var(--navbar-height)]" )
        .ToString();

    private readonly static string _brand = ElementClass.Empty()
        .Add( "flex" )
        .Add( "items-center" )
        .Add( "justify-start" )
        .Add( "text-medium" )
        .ToString();

    private readonly static string _sticky = ElementClass.Empty()
        .Add( "sticky" )
        .Add( "top-0" )
        .Add( "inset-x-0" )
        .ToString();

    private readonly static string _bordered = ElementClass.Empty()
        .Add( "border-b" )
        .Add( "border-divider" )
        .ToString();

    private static ElementClass GetMaxWidthStyles( MaxWidth maxWidth )
    {
        return ElementClass.Empty()
            .Add( "max-w-screen-sm", when: maxWidth is MaxWidth.Small )
            .Add( "max-w-screen-md", when: maxWidth is MaxWidth.Medium )
            .Add( "max-w-screen-lg", when: maxWidth is MaxWidth.Large )
            .Add( "max-w-screen-xl", when: maxWidth is MaxWidth.XLarge )
            .Add( "max-w-screen-2xl", when: maxWidth is MaxWidth.XXLarge );
    }

    public static string GetStyles( LumexNavbar navbar )
    {
        return ElementClass.Empty()
            .Add( _base )
            .Add( _sticky, when: navbar.Sticky )
            .Add( _bordered, when: navbar.Bordered )
            .Add( navbar.Classes?.Root )
            .Add( navbar.Class )
            .ToString();
    }

    public static string GetWrapperStyles( LumexNavbar navbar )
    {
        return ElementClass.Empty()
            .Add( _wrapper )
            .Add( GetMaxWidthStyles( navbar.MaxWidth ) )
            .Add( navbar.Classes?.Wrapper )
            .ToString();
    }

    public static string GetBrandStyles( LumexNavbarBrand navbarBrand )
    {
        var navbar = navbarBrand.Context.Owner;

        return ElementClass.Empty()
            .Add( _brand )
            .Add( navbar.Classes?.Brand )
            .Add( navbarBrand.Class )
            .ToString();
    }
}
