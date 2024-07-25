// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal readonly record struct TextBox
{
    private readonly static string _base = ElementClass.Empty()
        .Add( "group" )
        .Add( "flex" )
        .Add( "flex-col" )
        .ToString();

    private readonly static string _label = ElementClass.Empty()
        .Add( "absolute" )
        .Add( "z-10" )
        .Add( "block" )
        .Add( "text-small" )
        .Add( "text-foreground-500" )
        .Add( "origin-top-left" )
        .Add( "pointer-events-none" )
        .Add( "subpixel-antialiased" )
        // transition
        .Add( "will-change-auto" )
        .Add( "transition-[transform,color,left,opacity]" )
        .Add( "motion-reduce:transition-none" )
        .ToString();

    private readonly static string _inputWrapper = ElementClass.Empty()
        .Add( "relative" )
        .Add( "inline-flex" )
        .Add( "items-center" )
        .Add( "px-3" )
        .Add( "gap-3" )
        .Add( "w-full" )
        .Add( "shadow-sm" )
        .Add( "cursor-text" )
        // transition
        .Add( "transition-[background]" )
        .Add( "motion-reduce:transition-none" )
        .ToString();

    private readonly static string _innerWrapper = ElementClass.Empty()
        .Add( "inline-flex" )
        .Add( "items-center" )
        .Add( "w-full" )
        .Add( "h-full" )
        .ToString();

    private readonly static string _input = ElementClass.Empty()
        .Add( "w-full" )
        .Add( "font-normal" )
        .Add( "bg-transparent" )
        .Add( "focus-visible:outline-none" )
        .Add( "placeholder:text-foreground-500" )
        .Add( "autofill:bg-transparent" )
        .ToString();

    private readonly static string _disabled = ElementClass.Empty()
        .Add( "opacity-disabled" )
        .Add( "pointer-events-none" )
        .ToString();

    private readonly static string _fullWidth = ElementClass.Empty()
        .Add( "w-full" )
        .ToString();

    private static ElementClass GetSizeStyles( Size size, string slot )
    {
        if( slot is "inputWrapper" )
        {
            return ElementClass.Empty()
                .Add( "h-8 min-h-8 rounded-small", when: size is Size.Small )
                .Add( "h-10 min-h-10 rounded-medium", when: size is Size.Medium )
                .Add( "h-12 min-h-12 rounded-large", when: size is Size.Large );
        }
        else if( slot is "input" )
        {
            return ElementClass.Empty()
                .Add( "text-small", when: size is Size.Small or Size.Medium )
                .Add( "text-medium", when: size is Size.Large );
        }

        return ElementClass.Empty();
    }

    private static ElementClass GetRadiusStyles( Radius? radius )
    {
        if( radius is null )
        {
            return ElementClass.Empty();
        }

        return ElementClass.Empty()
            .Add( "rounded-none", when: radius is Radius.None )
            .Add( "rounded-small", when: radius is Radius.Small )
            .Add( "rounded-medium", when: radius is Radius.Medium )
            .Add( "rounded-large", when: radius is Radius.Large );
    }


    private static ElementClass GetLabelPlacementStyles( LabelPlacement labelPlacement, string slot )
    {
        if( slot is "inputWrapper" )
        {
            return ElementClass.Empty()
                .Add( "flex-col items-start justify-center", when: labelPlacement is LabelPlacement.Inside );
        }
        else if( slot is "innerWrapper" )
        {
            return ElementClass.Empty()
                .Add( "group-has-[label]:items-end", when: labelPlacement is LabelPlacement.Inside );
        }
        else if( slot is "label" )
        {
            return ElementClass.Empty()
                .Add( "group-data-[filled-focused=true]:pointer-events-auto" )
                .Add( "group-data-[filled-focused=true]:scale-90 cursor-text", when: labelPlacement is LabelPlacement.Inside );
        }

        return ElementClass.Empty();
    }

    private static ElementClass GetLabelPlacementInsideBySizeStyles( Size size, string slot )
    {
        if( slot is "inputWrapper" )
        {
            return ElementClass.Empty()
                .Add( "h-12 py-1.5", when: size is Size.Small )
                .Add( "h-14 py-2", when: size is Size.Medium )
                .Add( "h-16 py-2.5", when: size is Size.Large );
        }
        else if( slot is "label" )
        {
            return ElementClass.Empty()
                .Add( "text-small roup-data-[filled-focused=true]:-translate-y-[calc(50%_+_theme(fontSize.tiny)/2_-_8px)]", when: size is Size.Small )
                .Add( "text-small group-data-[filled-focused=true]:-translate-y-[calc(50%_+_theme(fontSize.small)/2_-_6px)]", when: size is Size.Medium )
                .Add( "text-medium group-data-[filled-focused=true]:-translate-y-[calc(50%_+_theme(fontSize.small)/2_-_8px)]", when: size is Size.Large );
        }

        return ElementClass.Empty();
    }

    public static string GetStyles( LumexTextBox textBox )
    {
        return ElementClass.Empty()
            .Add( _base )
            .Add( _disabled, when: textBox.Disabled )
            .Add( _fullWidth, when: textBox.FullWidth )
            .Add( textBox.Class )
            .ToString();
    }

    public static string GetLabelStyles( LumexTextBox textBox )
    {
        return ElementClass.Empty()
            .Add( _label )
            .Add( GetSizeStyles( textBox.Size, slot: "label" ) )
            .Add( GetLabelPlacementStyles( textBox.LabelPlacement, slot: "label" ) )
            .Add( GetLabelPlacementInsideBySizeStyles( textBox.Size, slot: "label" ), when: textBox.LabelPlacement is LabelPlacement.Inside )
            // LabelPlacement & ThemeColor.Default
            .Add( ElementClass.Empty()
                .Add( "group-data-[filled-focused=true]:text-default-600", when: textBox.LabelPlacement is LabelPlacement.Inside && textBox.Color is ThemeColor.Default )
                .Add( "group-data-[filled-focused=true]:text-foreground", when: textBox.LabelPlacement is LabelPlacement.Outside && textBox.Color is ThemeColor.Default ) )
            .ToString();
    }

    public static string GetInputWrapperStyles( LumexTextBox textBox )
    {
        return ElementClass.Empty()
            .Add( _inputWrapper )
            .Add( GetSizeStyles( textBox.Size, slot: "inputWrapper" ) )
            .Add( GetRadiusStyles( textBox.Radius ) )
            .Add( GetLabelPlacementStyles( textBox.LabelPlacement, slot: "inputWrapper" ) )
            .Add( GetLabelPlacementInsideBySizeStyles( textBox.Size, slot: "inputWrapper" ), when: textBox.LabelPlacement is LabelPlacement.Inside )
            .ToString();
    }

    public static string GetInnerWrapperStyles( LumexTextBox textBox )
    {
        return ElementClass.Empty()
            .Add( _innerWrapper )
            .Add( GetLabelPlacementStyles( textBox.LabelPlacement, slot: "innerWrapper" ) )
            .ToString();
    }

    public static string GetInputStyles( LumexTextBox textBox )
    {
        return ElementClass.Empty()
            .Add( _input )
            .Add( GetSizeStyles( textBox.Size, slot: "input" ) )
            .ToString();
    }
}
