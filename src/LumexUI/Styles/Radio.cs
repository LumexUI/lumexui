// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

namespace LumexUI.Styles;

internal enum SizeSlots
{
    Wrapper,
    Control,
    LabelWrapper,
    Label,
    Description
}

internal enum ColorSlots
{
    Control,
    Wrapper
}

[ExcludeFromCodeCoverage]
internal readonly record struct Radio
{
    private readonly static string _base = ElementClass.Empty()
        .Add( "group" )
        .Add( "relative" )
        .Add( "max-w-fit" )
        .Add( "inline-flex" )
        .Add( "items-center" )
        .Add( "justify-start" )
        .Add( "cursor-pointer" )
        .Add( "tap-highlight-transparent" )
        .Add( "p-2" )
        .Add( "-m-2" )
        .Add( "select-none" )
        .ToString();

    private readonly static string _wrapper = ElementClass.Empty()
        .Add( "relative" )
        .Add( "inline-flex" )
        .Add( "items-center" )
        .Add( "justify-center" )
        .Add( "flex-shrink-0" )
        .Add( "overflow-hidden" )
        .Add( "border-solid" )
        .Add( "border-medium" )
        .Add( "box-border" )
        .Add( "border-default" )
        .Add( "rounded-full" )
        .Add( "group-data-[hover-unselected=true]:bg-default-100" )
        // focus ring
        .Add( Utils.GroupFocusVisible )
        .ToString();

    private readonly static string _control = ElementClass.Empty()
        .Add( "z-10" )
        .Add( "w-2" )
        .Add( "h-2" )
        .Add( "opacity-0" )
        .Add( "scale-0" )
        .Add( "origin-center" )
        .Add( "rounded-full" )
        .Add( "group-data-[selected=true]:opacity-100" )
        .Add( "group-data-[selected=true]:scale-100" )
        .ToString();

    private readonly static string _labelWrapper = ElementClass.Empty()
        .Add( "relative" )
        .Add( "text-foreground" )
        .Add( "select-none" )
        .ToString();
    
    private readonly static string _label = ElementClass.Empty()
        .Add( "text-foreground" )
        .Add( "select-none" )
        .Add( "transition-colors-opacity" )
        .Add( "motion-reduce:transition-none" )
        .ToString();

    private readonly static string _disabled = ElementClass.Empty()
        .Add( "opacity-disabled" )
        .Add( "pointer-events-none" )
        .ToString();

    private static ElementClass GetColorStyles( ThemeColor color, ColorSlots slot )
    {
        switch (slot)
        {
            case ColorSlots.Control:
                return ElementClass.Empty()
                    .Add( "bg-default-500 text-default-foreground", when: color is ThemeColor.Default )
                    .Add( "bg-primary text-primary-foreground", when: color is ThemeColor.Primary )
                    .Add( "bg-secondary text-secondary-foreground", when: color is ThemeColor.Secondary )
                    .Add( "bg-success text-success-foreground", when: color is ThemeColor.Success )
                    .Add( "bg-warning text-warning-foreground", when: color is ThemeColor.Warning )
                    .Add( "bg-danger text-danger-foreground", when: color is ThemeColor.Danger )
                    .Add( "bg-info text-info-foreground", when: color is ThemeColor.Info );
            case ColorSlots.Wrapper:
                return ElementClass.Empty()
                    .Add( "group-data-[selected=true]:border-default-500", when: color is ThemeColor.Default )
                    .Add( "group-data-[selected=true]:border-primary", when: color is ThemeColor.Primary )
                    .Add( "group-data-[selected=true]:border-secondary", when: color is ThemeColor.Secondary )
                    .Add( "group-data-[selected=true]:border-success", when: color is ThemeColor.Success )
                    .Add( "group-data-[selected=true]:border-warning", when: color is ThemeColor.Warning )
                    .Add( "group-data-[selected=true]:border-danger", when: color is ThemeColor.Danger )
                    .Add( "group-data-[selected=true]:border-info", when: color is ThemeColor.Info );
            default:
                throw new ArgumentOutOfRangeException(nameof(slot), slot, "Unsupported slot");
        }
    }

    private static ElementClass GetSizeStyles( Size size, SizeSlots slot )
    {
        switch (slot)
        {
            case SizeSlots.Wrapper:
                return ElementClass.Empty()
                    .Add( "w-4 h-4", when: size is Size.Small )
                    .Add( "w-5 h-5", when: size is Size.Medium )
                    .Add( "w-6 h-6", when: size is Size.Large );
            case SizeSlots.Control:
                return ElementClass.Empty()
                    .Add( "w-1.5 h-1.5", when: size is Size.Small )
                    .Add( "w-2 h-2", when: size is Size.Medium )
                    .Add( "w-2.5 h-2.5", when: size is Size.Large );
            case SizeSlots.LabelWrapper:
                return ElementClass.Empty()
                    .Add( "ml-1", when: size is Size.Small )
                    .Add( "ms-2", when: size is Size.Medium )
                    .Add( "ms-2", when: size is Size.Large );
            case SizeSlots.Label:
                return ElementClass.Empty()
                    .Add( "text-small", when: size is Size.Small )
                    .Add( "text-medium", when: size is Size.Medium )
                    .Add( "text-large", when: size is Size.Large );
            case SizeSlots.Description:
                return ElementClass.Empty()
                    .Add( "text-tiny", when: size is Size.Small )
                    .Add( "text-small", when: size is Size.Medium )
                    .Add( "text-medium", when: size is Size.Large );
            default:
                throw new ArgumentOutOfRangeException(nameof(slot), slot, "Unsupported slot");
        }
    }

    public static string GetStyles<TValue>( LumexRadio<TValue> radio )
    {
        var radioGroup = radio.Context?.Owner;

        return ElementClass.Empty()
            .Add( _base )
            .Add( _disabled, when: radio.GetDisabledState() )
            .Add( radioGroup?.RadioClasses?.Root )
            .Add( radio.Classes?.Root )
            .Add( radio.Class )
            .ToString();
    }

    public static string GetWrapperStyles<TValue>( LumexRadio<TValue> radio )
    {
        var radioGroup = radio.Context?.Owner;

        return ElementClass.Empty()
            .Add( _wrapper )
            .Add( GetColorStyles( radio.Color, slot: ColorSlots.Wrapper ) )
            .Add( GetSizeStyles( radio.Size, slot: SizeSlots.Wrapper) )
            .Add( radioGroup?.RadioClasses?.Wrapper )
            .Add( radio.Classes?.Wrapper )
            .ToString();
    }

    public static string GetControlStyles<TValue>( LumexRadio<TValue> radio )
    {
        var radioGroup = radio.Context?.Owner;

        return ElementClass.Empty()
            .Add( _control )
            .Add( GetColorStyles( radio.Color, slot: ColorSlots.Control ) )
            .Add( GetSizeStyles( radio.Size, slot: SizeSlots.Control ) )
            .Add( radioGroup?.RadioClasses?.Control )
            .Add( radio.Classes?.Control )
            .ToString();
    }

    public static string GetLabelStyles<TValue>( LumexRadio<TValue> radio )
    {
        var checkboxGroup = radio.Context?.Owner;

        return ElementClass.Empty()
            .Add( _label )
            .Add( GetSizeStyles( radio.Size, slot: SizeSlots.Label ) )
            .Add( checkboxGroup?.RadioClasses?.Label )
            .Add( radio.Classes?.Label )
            .ToString();
    }
}

[ExcludeFromCodeCoverage]
internal readonly record struct RadioGroup
{
    private readonly static string _base = ElementClass.Empty()
        .Add( "relative" )
        .Add( "flex" )
        .Add( "flex-col" )
        .Add( "gap-2" )
        .ToString();

    private readonly static string _label = ElementClass.Empty()
        .Add( "text-medium" )
        .Add( "text-foreground-500" )
        .ToString();

    private readonly static string _wrapper = ElementClass.Empty()
        .Add( "flex" )
        .Add( "flex-col" )
        .Add( "flex-wrap" )
        .Add( "gap-2" )
        .Add( "data-[orientation=horizontal]:flex-row" )
        .ToString();

    private readonly static string _description = ElementClass.Empty()
        .Add( "text-tiny" )
        .Add( "text-foreground-400" )
        .ToString();

    public static string GetStyles<TValue>( LumexRadioGroup<TValue> radioGroup )
    {
        return ElementClass.Empty()
            .Add( _base )
            .Add( radioGroup.Classes?.Root )
            .Add( radioGroup.Class )
            .ToString();
    }

    public static string GetLabelStyles<TValue>( LumexRadioGroup<TValue> radioGroup )
    {
        return ElementClass.Empty()
            .Add( _label )
            .Add( radioGroup.Classes?.Label )
            .ToString();
    }

    public static string GetWrapperStyles<TValue>( LumexRadioGroup<TValue> radioGroup )
    {
        return ElementClass.Empty()
            .Add( _wrapper )
            .Add( radioGroup.Classes?.Wrapper )
            .ToString();
    }

    public static string GetDescriptionStyles<TValue>( LumexRadioGroup<TValue> radioGroup )
    {
        return ElementClass.Empty()
            .Add( _description )
            .Add( radioGroup.Classes?.Description )
            .ToString();
    }
}