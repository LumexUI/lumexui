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
        .Add( "relative" )
        .Add( "flex" )
        .Add( "w-full" )
        .Add( "items-center" )
        .Add( "justify-center" )
        .ToString();

    private readonly static string _wrapper = ElementClass.Empty()
        .Add( "z-40" )
        .Add( "flex" )
        .Add( "px-6" )
        .Add( "gap-8" )
        .Add( "w-full" )
        .Add( "items-center" )
        .Add( "h-[var(--navbar-height)]" )
        .ToString();

    private readonly static string _toggle = ElementClass.Empty()
        .Add( "group" )
        .Add( "w-6" )
        .Add( "h-full" )
        .Add( "rounded-small" )
		.Add( "cursor-pointer" )
		// focus
		.Add( Utils.FocusVisible )
        .ToString();

    private readonly static string _toggleIcon = ElementClass.Empty()
        .Add( "w-full" )
        .Add( "h-full" )
        .Add( "pointer-events-none" )
        .Add( "flex" )
        .Add( "flex-col" )
        .Add( "items-center" )
        .Add( "justify-center" )
        .Add( "text-inherit" )
        .Add( "group-active:opacity-focus" )
        .Add( "transition-opacity" )
        // before - first line
        .Add( "before:h-px" )
        .Add( "before:w-6" )
        .Add( "before:bg-current" )
        .Add( "before:transition-transform" )
        .Add( "before:duration-150" )
        .Add( "before:-translate-y-1" )
        .Add( "before:rotate-0" )
        .Add( "group-data-[expanded]:before:translate-y-px" )
        .Add( "group-data-[expanded]:before:rotate-45" )
        // after - second line
        .Add( "after:h-px" )
        .Add( "after:w-6" )
        .Add( "after:bg-current" )
        .Add( "after:transition-transform" )
        .Add( "after:duration-150" )
        .Add( "after:translate-y-1" )
        .Add( "after:rotate-0" )
        .Add( "group-data-[expanded]:after:translate-y-0" )
        .Add( "group-data-[expanded]:after:-rotate-45" )
        .ToString();

    private readonly static string _brand = ElementClass.Empty()
        .Add( "flex" )
        .Add( "items-center" )
        .Add( "justify-start" )
        .Add( "text-medium" )
        .ToString();

    private readonly static string _content = ElementClass.Empty()
        .Add( "flex" )
        .Add( "gap-6" )
        .Add( "h-full" )
        .Add( "flex-nowrap" )
        .Add( "items-center" )
        .ToString();

    private readonly static string _item = ElementClass.Empty()
        .Add( "leading-medium" )
        .Add( "text-small" )
        .Add( "font-semibold" )
        .Add( "list-none" )
        .ToString();

    private readonly static string _menu = ElementClass.Empty()
        .Add( "z-30" )
        .Add( "px-6" )
        .Add( "pt-2" )
        .Add( "flex" )
        .Add( "flex-col" )
        .Add( "gap-2" )
        .Add( "fixed" )
        .Add( "top-[var(--navbar-height)]" )
        .Add( "bottom-0" )
        .Add( "inset-x-0" )
        .Add( "overflow-y-auto" )
        .ToString();

    private readonly static string _menuItem = ElementClass.Empty()
        .Add( "text-large" )
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

    private static ElementClass GetAlignStyles( Align? align )
    {
        return ElementClass.Empty()
            .Add( "me-auto", when: align is Align.Start )
            .Add( "ms-auto", when: align is Align.End );
    }

    private static ElementClass GetBlurredStyles( bool blurred, string slot )
    {
        return blurred switch
        {
            false => ElementClass.Empty()
                .Add( "bg-background", when: slot is nameof( _base ) )
                .Add( "bg-background", when: slot is nameof( _menu ) ),

            true => ElementClass.Empty()
                // https://stackoverflow.com/questions/60997948/backdrop-filter-not-working-for-nested-elements-in-chrome
                .Add( ElementClass.Empty()
                    .Add( "before:-z-10" )
                    .Add( "before:absolute" )
                    .Add( "before:inset-0" )
                    .Add( "before:backdrop-blur-lg" )
                    .Add( "before:backdrop-saturate-150" )
                    .Add( "before:bg-background/70" ), when: slot is nameof( _base ) )
                .Add( ElementClass.Empty()
                    .Add( "backdrop-blur-lg" )
                    .Add( "backdrop-saturate-150" )
                    .Add( "bg-background/70" ), when: slot is nameof( _menu ) )
        };
    }

    public static string GetStyles( LumexNavbar navbar )
    {
        return ElementClass.Empty()
            .Add( _base )
            .Add( _sticky, when: navbar.Sticky )
            .Add( _bordered, when: navbar.Bordered )
            .Add( GetBlurredStyles( navbar.Blurred, slot: nameof( _base ) ) )
            .Add( navbar.Classes?.Base )
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

    public static string GetContentStyles( LumexNavbarContent navbarContent )
    {
        var navbar = navbarContent.Context.Owner;

        return ElementClass.Empty()
            .Add( _content )
            .Add( GetAlignStyles( navbarContent.Align ) )
            .Add( navbar.Classes?.Content )
            .Add( navbarContent.Class )
            .ToString();
    }

    public static string GetItemStyles( LumexNavbarItem navbarItem )
    {
        var navbar = navbarItem.Context.Owner;

        return ElementClass.Empty()
            .Add( _item )
            .Add( navbar.Classes?.Item )
            .Add( navbarItem.Class )
            .ToString();
    }

    public static string GetMenuStyles( LumexNavbarMenu navbarMenu )
    {
        var navbar = navbarMenu.Context.Owner;

        return ElementClass.Empty()
            .Add( _menu )
            .Add( GetBlurredStyles( navbar.Blurred, slot: nameof( _menu ) ) )
            .Add( navbar.Classes?.Menu )
            .Add( navbarMenu.Class )
            .ToString();
    }

    public static string GetMenuItemStyles( LumexNavbarMenuItem navbarMenuItem )
    {
        var navbar = navbarMenuItem.Context.Owner;

        return ElementClass.Empty()
            .Add( _menuItem )
            .Add( navbar.Classes?.MenuItem )
            .Add( navbarMenuItem.Class )
            .ToString();
    }

    public static string GetToggleStyles( LumexNavbarMenuToggle navbarMenuToggle )
    {
        var navbar = navbarMenuToggle.Context.Owner;

        return ElementClass.Empty()
            .Add( _toggle )
            .Add( navbar.Classes?.Toggle )
            .Add( navbarMenuToggle.Class )
            .ToString();
    }

    public static string GetToggleIconStyles( LumexNavbarMenuToggle navbarMenuToggle )
    {
        var navbar = navbarMenuToggle.Context.Owner;

        return ElementClass.Empty()
            .Add( _toggleIcon )
            .Add( navbar.Classes?.ToggleIcon )
            .ToString();
    }
}
