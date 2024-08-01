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
        .Add( "pe-2" )
        .Add( "max-w-full" )
        .Add( "text-ellipsis" )
        .Add( "overflow-hidden" )
        .Add( "group-data-[filled-focused=true]:pointer-events-auto" )
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

    private static ElementClass GetSize( Size size, string slot )
    {
        return size switch
        {
            Size.Small => ElementClass.Empty()
                .Add( "h-8 min-h-8 px-2 rounded-small", when: slot is nameof( _inputWrapper ) )
                .Add( "text-small", when: slot is "input" ),

            Size.Medium => ElementClass.Empty()
                .Add( "h-10 min-h-10 rounded-medium", when: slot is nameof( _inputWrapper ) )
                .Add( "text-small", when: slot is "input" ),

            Size.Large => ElementClass.Empty()
                .Add( "h-12 min-h-12 rounded-large", when: slot is nameof( _inputWrapper ) )
                .Add( "text-medium", when: slot is "input" ),

            _ => ElementClass.Empty()
        };
    }

    private static ElementClass GetRadius( Radius? radius, string slot )
    {
        return radius switch
        {
            Radius.None => ElementClass.Empty()
                .Add( "rounded-none", when: slot is nameof( _inputWrapper ) ),

            Radius.Small => ElementClass.Empty()
                .Add( "rounded-small", when: slot is nameof( _inputWrapper ) ),

            Radius.Medium => ElementClass.Empty()
                .Add( "rounded-medium", when: slot is nameof( _inputWrapper ) ),

            Radius.Large => ElementClass.Empty()
                .Add( "rounded-large", when: slot is nameof( _inputWrapper ) ),

            _ => ElementClass.Empty()
        };
    }

    private static ElementClass GetVariant( InputVariant variant, string slot )
    {
        return variant switch
        {
            InputVariant.Flat => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "bg-default-100" )
                    .Add( "hover:bg-default-200" )
                    .Add( "group-data-[filled-focused=true]:bg-default-100" ), when: slot is nameof( _inputWrapper ) ),

            InputVariant.Outlined => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "border-2" )
                    .Add( "border-default-200" )
                    .Add( "hover:border-default-300" )
                    .Add( "transition-colors" )
                    .Add( "group-data-[filled-focused=true]:border-default-foreground" ), when: slot is nameof( _inputWrapper ) ),

            InputVariant.Underlined => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "!px-1" )
                    .Add( "!pb-1" )
                    .Add( "!rounded-none" )
                    .Add( "relative" )
                    .Add( "border-b-2" )
                    .Add( "shadow-[0_1px_0px_0_rgba(0,0,0,0.05)]" )
                    .Add( "border-default-200" )
                    .Add( "hover:border-default-300" )
                    .Add( "after:w-0" )
                    .Add( "after:origin-center" )
                    .Add( "after:bg-default-foreground" )
                    .Add( "after:absolute" )
                    .Add( "after:left-1/2" )
                    .Add( "after:-translate-x-1/2" )
                    .Add( "after:-bottom-[2px]" )
                    .Add( "after:h-[2px]" )
                    .Add( "after:transition-[width]" )
                    .Add( "group-data-[filled-focused=true]:after:w-full" ), when: slot is nameof( _inputWrapper ) )
                .Add( "pb-1", when: slot is nameof( _innerWrapper ) )
                .Add( "group-data-[filled-focused=true]:text-foreground", when: slot is nameof( _label ) ),

            _ => ElementClass.Empty()
        };
    }

    private static ElementClass GetLabelPlacement( LabelPlacement labelPlacement, string slot )
    {
        return labelPlacement switch
        {
            LabelPlacement.Inside => ElementClass.Empty()
                .Add( "flex-col items-start justify-center", when: slot is nameof( _inputWrapper ) )
                .Add( "group-has-[label]:items-end", when: slot is nameof( _innerWrapper ) )
                .Add( "cursor-text group-data-[filled-focused=true]:scale-90", when: slot is nameof( _label ) ),

            LabelPlacement.Outside => ElementClass.Empty()
                .Add( "justify-end", when: slot is nameof( _base ) )
                .Add( "flex flex-col", when: slot is nameof( _mainWrapper ) )
                .Add( ElementClass.Empty()
                    .Add( "z-20" )
                    .Add( "top-1/2" )
                    .Add( "-translate-y-1/2" )
                    .Add( "group-data-[filled-focused=true]:left-0" ), when: slot is nameof( _label ) ),

            _ => ElementClass.Empty()
        };
    }

    private static ElementClass GetLabelPlacementInsideBySize( Size size, string slot )
    {
        return size switch
        {
            Size.Small => ElementClass.Empty()
                .Add( "h-12 py-1.5", when: slot is nameof( _inputWrapper ) )
                .Add( ElementClass.Empty()
                    .Add( "text-small" )
                    .Add( "group-data-[filled-focused=true]:-translate-y-[calc(50%_+_theme(fontSize.tiny)/2_-_8px)]" ), when: slot is nameof( _label ) ),

            Size.Medium => ElementClass.Empty()
                .Add( "h-14 py-2", when: slot is nameof( _inputWrapper ) )
                .Add( ElementClass.Empty()
                    .Add( "text-small" )
                    .Add( "group-data-[filled-focused=true]:-translate-y-[calc(50%_+_theme(fontSize.small)/2_-_6px)]" ), when: slot is nameof( _label ) ),

            Size.Large => ElementClass.Empty()
                .Add( "h-16 py-2.5", when: slot is nameof( _inputWrapper ) )
                .Add( ElementClass.Empty()
                    .Add( "text-medium" )
                    .Add( "group-data-[filled-focused=true]:-translate-y-[calc(50%_+_theme(fontSize.small)/2_-_8px)]" ), when: slot is nameof( _label ) ),

            _ => ElementClass.Empty()
        };
    }

    private static ElementClass GetLabelPlacementOutsideBySize( Size size, string slot )
    {
        return size switch
        {
            Size.Small => ElementClass.Empty()
                .Add( "has-[label]:mt-[calc(theme(fontSize.small)_+_8px)]", when: slot is nameof( _base ) )
                .Add( ElementClass.Empty()
                    .Add( "text-tiny" )
                    .Add( "left-2" )
                    .Add( "group-data-[filled-focused=true]:-translate-y-[calc(100%_+_theme(fontSize.tiny)/2_+_16px)]" ), when: slot is nameof( _label ) ),

            Size.Medium => ElementClass.Empty()
                .Add( "has-[label]:mt-[calc(theme(fontSize.small)_+_10px)]", when: slot is nameof( _base ) )
                .Add( ElementClass.Empty()
                    .Add( "text-small" )
                    .Add( "left-3" )
                    .Add( "group-data-[filled-focused=true]:-translate-y-[calc(100%_+_theme(fontSize.small)/2_+_20px)]" ), when: slot is nameof( _label ) ),

            Size.Large => ElementClass.Empty()
                .Add( "has-[label]:mt-[calc(theme(fontSize.small)_+_12px)]", when: slot is nameof( _base ) )
                .Add( ElementClass.Empty()
                    .Add( "text-medium" )
                    .Add( "left-3" )
                    .Add( "group-data-[filled-focused=true]:-translate-y-[calc(100%_+_theme(fontSize.small)/2_+_24px)]" ), when: slot is nameof( _label ) ),

            _ => ElementClass.Empty()
        };
    }

    public static string GetStyles( LumexTextBox textBox )
    {
        return ElementClass.Empty()
            .Add( _base )
            .Add( _disabled, when: textBox.Disabled )
            .Add( _fullWidth, when: textBox.FullWidth )
            .Add( GetLabelPlacement( textBox.LabelPlacement, slot: nameof( _base ) ) )
            .Add( GetLabelPlacementOutsideBySize( textBox.Size, slot: nameof( _base ) ), when: textBox.LabelPlacement is LabelPlacement.Outside )
            .Add( textBox.Class )
            .ToString();
    }

    public static string GetLabelStyles( LumexTextBox textBox )
    {
        return ElementClass.Empty()
            .Add( _label )
            .Add( GetVariant( textBox.Variant, slot: nameof( _label ) ) )
            .Add( GetLabelPlacement( textBox.LabelPlacement, slot: nameof( _label ) ) )
            .Add( GetLabelPlacementInsideBySize( textBox.Size, slot: nameof( _label ) ), when: textBox.LabelPlacement is LabelPlacement.Inside )
            .Add( GetLabelPlacementOutsideBySize( textBox.Size, slot: nameof( _label ) ), when: textBox.LabelPlacement is LabelPlacement.Outside )
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
            .Add( GetLabelPlacement( textBox.LabelPlacement, slot: nameof( _mainWrapper ) ) )
            .ToString();
    }

    public static string GetInputWrapperStyles( LumexTextBox textBox )
    {
        return ElementClass.Empty()
            .Add( _inputWrapper )
            .Add( GetSize( textBox.Size, slot: nameof( _inputWrapper ) ) )
            .Add( GetRadius( textBox.Radius, slot: nameof( _inputWrapper ) ) )
            .Add( GetVariant( textBox.Variant, slot: nameof( _inputWrapper ) ) )
            .Add( GetLabelPlacement( textBox.LabelPlacement, slot: nameof( _inputWrapper ) ) )
            .Add( GetLabelPlacementInsideBySize( textBox.Size, slot: nameof( _inputWrapper ) ), when: textBox.LabelPlacement is LabelPlacement.Inside )
            .ToString();
    }

    public static string GetInnerWrapperStyles( LumexTextBox textBox )
    {
        return ElementClass.Empty()
            .Add( _innerWrapper )
            .Add( GetVariant( textBox.Variant, slot: nameof( _innerWrapper ) ) )
            .Add( GetLabelPlacement( textBox.LabelPlacement, slot: nameof( _innerWrapper ) ) )
            .ToString();
    }

    public static string GetInputStyles( LumexTextBox textBox )
    {
        return ElementClass.Empty()
            .Add( _input )
            .Add( GetSize( textBox.Size, slot: nameof( _input ) ) )
            .ToString();
    }
}
