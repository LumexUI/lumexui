// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

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

    private readonly static string _sticky = ElementClass.Empty()
        .Add( "sticky" )
        .Add( "top-0" )
        .Add( "inset-x-0" )
        .ToString();

    private readonly static string _bordered = ElementClass.Empty()
        .Add( "border-b" )
        .Add( "border-divider" )
        .ToString();

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
            .Add( navbar.Classes?.Wrapper )
            .ToString();
    }
}
