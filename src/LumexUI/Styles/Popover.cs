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
        .Add( "bg-default-50" )
        .ToString();

    private static ElementClass GetColorStyles( ThemeColor color, string slot )
    {
        return color switch
        {
            ThemeColor.Default => ElementClass.Empty()
                .Add( "bg-content1 shadow-small", when: slot is nameof( _arrow ) )
                .Add( "bg-content1", when: slot is nameof( _content ) ),

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

    public static string GetStyles( LumexPopover popover )
    {
        return ElementClass.Empty()
            .Add( _base )
            .Add( popover.Class )
            .ToString();
    }

    public static string GetInnerWrapperStyles( LumexPopoverContent popoverContent )
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
            .Add( GetSizeStyles( popover.Size ) )
            .Add( GetColorStyles( popover.Color, slot: nameof( _content ) ) )
            .Add( "text-small" )
            .Add( GetTextSizeStyles( popover.Size ) )
            .Add( "shadow-small" )
            .Add( popoverContent.Class )
            .ToString();

        static ElementClass GetSizeStyles( Size size )
        {
            return ElementClass.Empty()
                .Add( "text-tiny", when: size is Size.Small )
                .Add( "text-small", when: size is Size.Medium )
                .Add( "text-medium", when: size is Size.Large );
        }
    }

    public static string GetTriggerStyles( LumexPopoverContent popoverContent )
    {
        return ElementClass.Empty()
            .Add( _arrow )
            .ToString();
    }

    public static string GetArrowStyles( LumexPopoverContent popoverContent )
    {
        var popover = popoverContent.Context.Owner;

        return ElementClass.Empty()
            .Add( _arrow )
            .Add( GetColorStyles( popover.Color, slot: nameof( _arrow ) ) )
            .ToString();
    }
}
