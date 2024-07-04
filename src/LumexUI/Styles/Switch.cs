﻿// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal readonly record struct Switch
{
    private readonly static string _base = ElementClass.Empty()
        .Add( "group" )
        .Add( "relative" )
        .Add( "inline-flex" )
        .Add( "items-center" )
        .Add( "justify-start" )
        .Add( "outline-none" )
        .Add( "cursor-pointer" )
        .Add( "touch-none" )
        .ToString();

    private readonly static string _wrapper = ElementClass.Empty()
        .Add( "px-1" )
        .Add( "mr-2" )
        .Add( "relative" )
        .Add( "inline-flex" )
        .Add( "items-center" )
        .Add( "justify-start" )
        .Add( "flex-shrink-0" )
        .Add( "overflow-hidden" )
        .Add( "bg-default-200" )
        .Add( "rounded-full" )
        //transition
        .Add( "transition-background" )
        // focus ring
        .Add( Utils.GroupFocusVisible )
        .ToString();

    private readonly static string _thumb = ElementClass.Empty()
        .Add( "z-10" )
        .Add( "flex" )
        .Add( "items-center" )
        .Add( "justify-center" )
        .Add( "bg-white" )
        .Add( "shadow-small" )
        .Add( "rounded-full" )
        .Add( "origin-right" )
        // transition
        .Add( "transition-all" )
        .ToString();

    private readonly static string _thumbIcon = ElementClass.Empty()
        .Add( "p-0.5" )
        .Add( "text-black" )
        .ToString();

    private readonly static string _startIcon = ElementClass.Empty()
        .Add( "z-0" )
        .Add( "p-0.5" )
        .Add( "absolute" )
        .Add( "left-1.5" )
        .Add( "text-current" )
        // transition
        .Add( "opacity-0" )
        .Add( "scale-50" )
        .Add( "transition-[transform,opacity]" )
        .Add( "group-data-[checked]:scale-100" )
        .Add( "group-data-[checked]:opacity-100" )
        .ToString();

    private readonly static string _endIcon = ElementClass.Empty()
        .Add( "z-0" )
        .Add( "p-0.5" )
        .Add( "absolute" )
        .Add( "right-1.5" )
        .Add( "text-default-600" )
        // transition
        .Add( "opacity-100" )
        .Add( "transition-[transform,opacity]" )
        .Add( "group-data-[checked]:translate-x-3" )
        .Add( "group-data-[checked]:opacity-0" )
        .ToString();

    private readonly static string _label = ElementClass.Empty()
        .Add( "relative" )
        .Add( "text-foreground" )
        .Add( "select-none" )
        .ToString();

    private readonly static string _disabled = ElementClass.Empty()
        .Add( "opacity-disabled" )
        .Add( "pointer-events-none" )
        .ToString();

    private static ElementClass GetColorStyles( ThemeColor color )
    {
        return ElementClass.Empty()
            .Add( "group-data-[checked]:bg-default-400 group-data-[checked]:text-default-foreground", when: color is ThemeColor.Default )
            .Add( "group-data-[checked]:bg-primary group-data-[checked]:text-primary-foreground", when: color is ThemeColor.Primary )
            .Add( "group-data-[checked]:bg-secodary group-data-[checked]:text-secondary-foreground", when: color is ThemeColor.Secondary )
            .Add( "group-data-[checked]:bg-success group-data-[checked]:text-success-foreground", when: color is ThemeColor.Success )
            .Add( "group-data-[checked]:bg-warning group-data-[checked]:text-warning-foreground", when: color is ThemeColor.Warning )
            .Add( "group-data-[checked]:bg-danger group-data-[checked]:text-danger-foreground", when: color is ThemeColor.Danger )
            .Add( "group-data-[checked]:bg-info group-data-[checked]:text-info-foreground", when: color is ThemeColor.Info );
    }

    private static ElementClass GetSizeStyles( Size size, string slot )
    {
        if( slot is "wrapper" )
        {
            return ElementClass.Empty()
                .Add( "w-10 h-5", when: size is Size.Small )
                .Add( "w-12 h-6", when: size is Size.Medium )
                .Add( "w-14 h-7", when: size is Size.Large );
        }
        else if( slot is "thumb" )
        {
            return ElementClass.Empty()
                .Add( "w-3 h-3 text-tiny group-data-[checked]:ml-5 group-active:w-4 group-data-[checked]:group-active:ml-3", when: size is Size.Small )
                .Add( "w-4 h-4 text-small group-data-[checked]:ml-6 group-active:w-5 group-data-[checked]:group-active:ml-4", when: size is Size.Medium )
                .Add( "w-5 h-5 text-medium group-data-[checked]:ml-7 group-active:w-6 group-data-[checked]:group-active:ml-5", when: size is Size.Large );
        }
        else if( slot is "startIcon" or "endIcon" )
        {
            return ElementClass.Empty()
                .Add( "text-tiny", when: size is Size.Small )
                .Add( "text-small", when: size is Size.Medium )
                .Add( "text-medium", when: size is Size.Large );
        }
        else // part is "label"
        {
            return ElementClass.Empty()
                .Add( "text-small", when: size is Size.Small )
                .Add( "text-medium", when: size is Size.Medium )
                .Add( "text-large", when: size is Size.Large );
        }
    }

    public static string GetStyles( LumexSwitch @switch )
    {
        return ElementClass.Empty()
            .Add( _base )
            .Add( _disabled, when: @switch.Disabled )
            .Add( @switch.Classes?.Root )
            .Add( @switch.Class )
            .ToString();
    }

    public static string GetWrapperStyles( LumexSwitch @switch )
    {
        return ElementClass.Empty()
            .Add( _wrapper )
            .Add( GetColorStyles( @switch.Color ) )
            .Add( GetSizeStyles( @switch.Size, slot: "wrapper" ) )
            .Add( @switch.Classes?.Wrapper )
            .ToString();
    }

    public static string GetThumbStyles( LumexSwitch @switch )
    {
        return ElementClass.Empty()
            .Add( _thumb )
            .Add( GetSizeStyles( @switch.Size, slot: "thumb" ) )
            .Add( @switch.Classes?.Thumb )
            .ToString();
    }

    public static string GetThumbIconStyles( LumexSwitch @switch )
    {
        return ElementClass.Empty()
            .Add( _thumbIcon )
            .Add( @switch.Classes?.ThumbIcon )
            .ToString();
    }

    public static string GetStartIconStyles( LumexSwitch @switch )
    {
        return ElementClass.Empty()
            .Add( _startIcon )
            .Add( GetSizeStyles( @switch.Size, slot: "startIcon" ) )
            .Add( @switch.Classes?.StartIcon )
            .ToString();
    }

    public static string GetEndIconStyles( LumexSwitch @switch )
    {
        return ElementClass.Empty()
            .Add( _endIcon )
            .Add( GetSizeStyles( @switch.Size, slot: "endIcon" ) )
            .Add( @switch.Classes?.EndIcon )
            .ToString();
    }

    public static string GetLabelStyles( LumexSwitch @switch )
    {
        return ElementClass.Empty()
            .Add( _label )
            .Add( GetSizeStyles( @switch.Size, slot: "label" ) )
            .Add( @switch.Classes?.Label )
            .ToString();
    }
}
