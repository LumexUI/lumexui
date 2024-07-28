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
        .Add( "relative" )
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

    private readonly static string _mainWrapper = ElementClass.Empty()
        .Add( "h-full" )
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

    private static ElementClass GetVariantStyles( InputVariant variant )
    {
        return ElementClass.Empty()
            .Add( "bg-default-100 hover:bg-default-200 group-focus-within:bg-default-100", when: variant is InputVariant.Flat );
    }

    private static ElementClass GetLabelPlacementStyles( LabelPlacement labelPlacement, string slot )
    {
        if( slot is "base" )
        {
            return ElementClass.Empty()
                .Add( "justify-end", when: labelPlacement is LabelPlacement.Outside );
        }
        else if( slot is "mainWrapper" )
        {
            return ElementClass.Empty()
                .Add( "flex flex-col", when: labelPlacement is LabelPlacement.Outside );
        }
        else if( slot is "inputWrapper" )
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
                .Add( "group-data-[filled-focused=true]:pointer-events-auto pe-2 max-w-full text-ellipsis overflow-hidden" )
                .Add( "group-data-[filled-focused=true]:scale-90 cursor-text", when: labelPlacement is LabelPlacement.Inside )
                .Add( "group-data-[filled-focused=true]:left-0 z-20 top-1/2 -translate-y-1/2", when: labelPlacement is LabelPlacement.Outside );
        }

        return ElementClass.Empty();
    }

    private static ElementClass GetLabelInsideBySizeStyles( Size size, string slot )
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

    private static ElementClass GetLabelOutsideBySizeStyles( Size size, string slot )
    {
        if( slot is "base" )
        {
            return ElementClass.Empty()
                .Add( "has-[label]:mt-[calc(theme(fontSize.small)_+_8px)]", when: size is Size.Small )
                .Add( "has-[label]:mt-[calc(theme(fontSize.small)_+_10px)]", when: size is Size.Medium )
                .Add( "has-[label]:mt-[calc(theme(fontSize.small)_+_12px)]", when: size is Size.Large );
        }
        else if( slot is "label" )
        {
            return ElementClass.Empty()
                .Add( "group-data-[filled-focused=true]:-translate-y-[calc(100%_+_theme(fontSize.tiny)/2_+_16px)] left-2 text-tiny", when: size is Size.Small )
                .Add( "group-data-[filled-focused=true]:-translate-y-[calc(100%_+_theme(fontSize.small)/2_+_20px)] left-3 text-small", when: size is Size.Medium )
                .Add( "group-data-[filled-focused=true]:-translate-y-[calc(100%_+_theme(fontSize.small)/2_+_24px)] left-3 text-medium", when: size is Size.Large );
        }

        return ElementClass.Empty();
    }

    public static string GetStyles( LumexTextBox textBox )
    {
        return ElementClass.Empty()
            .Add( _base )
            .Add( _disabled, when: textBox.Disabled )
            .Add( _fullWidth, when: textBox.FullWidth )
            .Add( GetLabelOutsideBySizeStyles( textBox.Size, slot: "base" ), when: textBox.LabelPlacement is LabelPlacement.Outside )
            .Add( textBox.Class )
            .ToString();
    }

    public static string GetLabelStyles( LumexTextBox textBox )
    {
        return ElementClass.Empty()
            .Add( _label )
            .Add( GetLabelPlacementStyles( textBox.LabelPlacement, slot: "label" ) )
            .Add( GetLabelInsideBySizeStyles( textBox.Size, slot: "label" ), when: textBox.LabelPlacement is LabelPlacement.Inside )
            .Add( GetLabelOutsideBySizeStyles( textBox.Size, slot: "label" ), when: textBox.LabelPlacement is LabelPlacement.Outside )
            // LabelPlacement & ThemeColor.Default
            .Add( ElementClass.Empty()
                .Add( "group-data-[filled-focused=true]:text-default-600", when: textBox.LabelPlacement is LabelPlacement.Inside && textBox.Color is ThemeColor.Default )
                .Add( "group-data-[filled-focused=true]:text-foreground", when: textBox.LabelPlacement is LabelPlacement.Outside && textBox.Color is ThemeColor.Default ) )
            .ToString();
    }

    public static string GetMainWrapperStyles( LumexTextBox textBox )
    {
        return ElementClass.Empty()
            .Add( _mainWrapper )
            .Add( GetLabelPlacementStyles( textBox.LabelPlacement, slot: "mainWrapper" ) )
            .ToString();
    }

    public static string GetInputWrapperStyles( LumexTextBox textBox )
    {
        return ElementClass.Empty()
            .Add( _inputWrapper )
            .Add( GetRadiusStyles( textBox.Radius ) )
            .Add( GetVariantStyles( textBox.Variant ) )
            .Add( GetSizeStyles( textBox.Size, slot: "inputWrapper" ) )
            .Add( GetLabelPlacementStyles( textBox.LabelPlacement, slot: "inputWrapper" ) )
            .Add( GetLabelInsideBySizeStyles( textBox.Size, slot: "inputWrapper" ), when: textBox.LabelPlacement is LabelPlacement.Inside )
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
