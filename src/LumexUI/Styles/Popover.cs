// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal static class Popover
{
    private readonly static string _base = ElementClass.Empty()
        .ToString();

    private readonly static string _innerWrapper = ElementClass.Empty()
        .Add( "animate-appearance-in" )
        .ToString();

    private readonly static string _content = ElementClass.Empty()
        .Add( "z-10" )
        .Add( "py-1" )
        .Add( "px-2.5" )
        .Add( "w-full" )
        .Add( "inline-flex" )
        .Add( "flex-col" )
        .Add( "items-center" )
        .Add( "justify-center" )
        .ToString();

    private readonly static string _trigger = ElementClass.Empty()
        .Add( "z-10" )
        .ToString();

    private readonly static string _arrow = ElementClass.Empty()
        .Add( "z-[-1]" )
        .Add( "w-2.5" )
        .Add( "h-2.5" )
        .Add( "absolute" )
        .Add( "rotate-45" )
        .Add( "rounded-sm" )
        .Add( "shadow-small" )
        .ToString();

    private static ElementClass GetColorStyles( ThemeColor color, string slot )
    {
        return color switch
        {
            ThemeColor.Default => ElementClass.Empty()
                .Add( "bg-surface1 shadow-small", when: slot is nameof( _arrow ) )
                .Add( "bg-surface1", when: slot is nameof( _content ) ),

            ThemeColor.Primary => ElementClass.Empty()
                .Add( "bg-primary", when: slot is nameof( _arrow ) )
                .Add( ColorVariants.Solid[ThemeColor.Primary], when: slot is nameof( _content ) ),

            ThemeColor.Secondary => ElementClass.Empty()
                .Add( "bg-secondary", when: slot is nameof( _arrow ) )
                .Add( ColorVariants.Solid[ThemeColor.Secondary], when: slot is nameof( _content ) ),

            ThemeColor.Success => ElementClass.Empty()
                .Add( "bg-success", when: slot is nameof( _arrow ) )
                .Add( ColorVariants.Solid[ThemeColor.Success], when: slot is nameof( _content ) ),

            ThemeColor.Warning => ElementClass.Empty()
                .Add( "bg-warning", when: slot is nameof( _arrow ) )
                .Add( ColorVariants.Solid[ThemeColor.Warning], when: slot is nameof( _content ) ),

            ThemeColor.Danger => ElementClass.Empty()
                .Add( "bg-danger", when: slot is nameof( _arrow ) )
                .Add( ColorVariants.Solid[ThemeColor.Danger], when: slot is nameof( _content ) ),

            ThemeColor.Info => ElementClass.Empty()
                .Add( "bg-info", when: slot is nameof( _arrow ) )
                .Add( ColorVariants.Solid[ThemeColor.Info], when: slot is nameof( _content ) ),

            _ => ElementClass.Empty()
        };
    }

    private static ElementClass GetSizeStyles( Size size, string slot )
    {
        return size switch
        {
            Size.Small => ElementClass.Empty()
                .Add( "text-tiny", when: slot is nameof( _content ) ),

            Size.Medium => ElementClass.Empty()
                .Add( "text-small", when: slot is nameof( _content ) ),

            Size.Large => ElementClass.Empty()
                .Add( "text-medium", when: slot is nameof( _content ) ),

            _ => ElementClass.Empty()
        };
    }

    private static ElementClass GetRadiusStyles( Radius radius, string slot )
    {
        return radius switch
        {
            Radius.None => ElementClass.Empty()
                .Add( "rounded-none", when: slot is nameof( _content ) ),

            Radius.Small => ElementClass.Empty()
                .Add( "rounded-small", when: slot is nameof( _content ) ),

            Radius.Medium => ElementClass.Empty()
                .Add( "rounded-medium", when: slot is nameof( _content ) ),

            Radius.Large => ElementClass.Empty()
                .Add( "rounded-large", when: slot is nameof( _content ) ),

            _ => ElementClass.Empty()
        };
    }

    private static ElementClass GetShadowStyles( Shadow shadow, string slot )
    {
        return shadow switch
        {
            Shadow.None => ElementClass.Empty()
                .Add( "shadow-none", when: slot is nameof( _content ) ),

            Shadow.Small => ElementClass.Empty()
                .Add( "shadow-small", when: slot is nameof( _content ) ),

            Shadow.Medium => ElementClass.Empty()
                .Add( "shadow-medium", when: slot is nameof( _content ) ),

            Shadow.Large => ElementClass.Empty()
                .Add( "shadow-large", when: slot is nameof( _content ) ),

            _ => ElementClass.Empty()
        };
    }

    public static string GetStyles( LumexPopover popover )
    {
        return ElementClass.Empty()
            .Add( _base )
            .Add( popover.Classes?.Root )
            .Add( popover.Class )
            .ToString();
    }

    public static string GetTriggerStyles( LumexPopoverTrigger popoverTrigger )
    {
        var popover = popoverTrigger.Context.Owner;

        return ElementClass.Empty()
            .Add( _trigger )
            .Add( popover.Classes?.Trigger )
            .Add( popoverTrigger.Class )
            .ToString();
    }

    public static string GetInnerWrapperStyles()
    {
        return ElementClass.Empty()
            .Add( _innerWrapper )
            .ToString();
    }

    public static string GetContentStyles( LumexPopoverContent popoverContent )
    {
        var popover = popoverContent.Context.Owner;

        return ElementClass.Empty()
            .Add( _content )
            .Add( GetSizeStyles( popover.Size, slot: nameof( _content ) ) )
            .Add( GetColorStyles( popover.Color, slot: nameof( _content ) ) )
            .Add( GetRadiusStyles( popover.Radius, slot: nameof( _content ) ) )
            .Add( GetShadowStyles( popover.Shadow, slot: nameof( _content ) ) )
            .Add( popover.Classes?.Content )
            .Add( popoverContent.Class )
            .ToString();
    }

    public static string GetArrowStyles( LumexPopoverContent popoverContent )
    {
        var popover = popoverContent.Context.Owner;

        return ElementClass.Empty()
            .Add( _arrow )
            .Add( GetColorStyles( popover.Color, slot: nameof( _arrow ) ) )
            .Add( popover.Classes?.Arrow )
            .ToString();
    }
}
