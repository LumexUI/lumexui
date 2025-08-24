// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal readonly record struct Checkbox
{
    private readonly static string _base = ElementClass.Empty()
        .Add( "p-2" )
        .Add( "-m-2" )
        .Add( "group" )
        .Add( "max-w-fit" )
        .Add( "inline-flex" )
        .Add( "items-center" )
        .Add( "justify-start" )
        .Add( "outline-hidden" )
        .Add( "cursor-pointer" )
        .ToString();

    private readonly static string _wrapper = ElementClass.Empty()
        .Add( "mr-2" )
        .Add( "relative" )
        .Add( "inline-flex" )
        .Add( "items-center" )
        .Add( "justify-center" )
        .Add( "flex-shrink-0" )
        .Add( "overflow-hidden" )
        .Add( "transition-transform" )
        .Add( "motion-reduce:transition-none" )
        .Add( "group-active:scale-95" )
        // before
        .Add( "before:absolute" )
        .Add( "before:inset-0" )
        .Add( "before:border-2" )
        .Add( "before:border-solid" )
        .Add( "before:border-default" )
        .Add( "before:transition-colors" )
        // after
        .Add( "after:absolute" )
        .Add( "after:inset-0" )
        .Add( "after:scale-50" )
        .Add( "after:opacity-0" )
        .Add( "after:origin-center" )
        .Add( "after:transition[transform,opacity]" )
        .Add( "after:!duration-200" )
        .Add( "group-data-[checked=true]:after:scale-100" )
        .Add( "group-data-[checked=true]:after:opacity-100" )
        // hover
        .Add( "group-hover:before:bg-default-100" )
        // focus ring
        .Add( Utils.GroupFocusVisible )
        .ToString();

    private readonly static string _icon = ElementClass.Empty()
        .Add( "contents" )
        .Add( "*:z-10" )
        .Add( "*:opacity-0" )
        .Add( "*:transition-opacity" )
        .Add( "*:motion-reduce:transition-none" )
        .Add( "*:group-data-[checked=true]:opacity-100" )
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

    private readonly static string _radiusSmall = ElementClass.Empty()
        .Add( "rounded-[calc(var(--radius-small)*0.5)]" )
        .Add( "before:rounded-[calc(var(--radius-small)*0.5)]" )
        .Add( "after:rounded-[calc(var(--radius-small)*0.5)]" )
        .ToString();

    private readonly static string _radiusMedium = ElementClass.Empty()
        .Add( "rounded-[calc(var(--radius-medium)*0.5)]" )
        .Add( "before:rounded-[calc(var(--radius-medium)*0.5)]" )
        .Add( "after:rounded-[calc(var(--radius-medium)*0.5)]" )
        .ToString();

    private readonly static string _radiusLarge = ElementClass.Empty()
        .Add( "rounded-[calc(var(--radius-large)*0.5)]" )
        .Add( "before:rounded-[calc(var(--radius-large)*0.5)]" )
        .Add( "after:rounded-[calc(var(--radius-large)*0.5)]" )
        .ToString();

    private static ElementClass GetColorStyles( ThemeColor color )
    {
        return ElementClass.Empty()
            .Add( "after:bg-default text-default-foreground", when: color is ThemeColor.Default )
            .Add( "after:bg-primary text-primary-foreground", when: color is ThemeColor.Primary )
            .Add( "after:bg-secondary text-secondary-foreground", when: color is ThemeColor.Secondary )
            .Add( "after:bg-success text-success-foreground", when: color is ThemeColor.Success )
            .Add( "after:bg-warning text-warning-foreground", when: color is ThemeColor.Warning )
            .Add( "after:bg-danger text-danger-foreground", when: color is ThemeColor.Danger )
            .Add( "after:bg-info text-info-foreground", when: color is ThemeColor.Info );
    }

    private static ElementClass GetRadiusStyles( Radius radius )
    {
        return ElementClass.Empty()
            .Add( "rounded-none before:rounded-none after:rounded-none", when: radius is Radius.None )
            .Add( _radiusSmall, when: radius is Radius.Small )
            .Add( _radiusMedium, when: radius is Radius.Medium )
            .Add( _radiusLarge, when: radius is Radius.Large );
    }

    private static ElementClass GetSizeStyles( Size size, string slot )
    {
        if( slot == "wrapper" )
        {
            return ElementClass.Empty()
                .Add( $"w-4 h-4 {_radiusSmall}", when: size is Size.Small )
                .Add( $"w-5 h-5 {_radiusMedium}", when: size is Size.Medium )
                .Add( $"w-6 h-6 {_radiusLarge}", when: size is Size.Large );
        }
        else if( slot == "icon" )
        {
            return ElementClass.Empty()
                .Add( "*:w-3 *:h-2", when: size is Size.Small )
                .Add( "*:w-4 *:h-3", when: size is Size.Medium )
                .Add( "*:w-5 *:h-4", when: size is Size.Large );
        }
        else // part == "label"
        {
            return ElementClass.Empty()
                .Add( "text-small", when: size is Size.Small )
                .Add( "text-medium", when: size is Size.Medium )
                .Add( "text-large", when: size is Size.Large );
        }
    }

    public static string GetStyles( LumexCheckbox checkbox )
    {
        var checkboxGroup = checkbox.Context?.Owner;

        return ElementClass.Empty()
            .Add( _base )
            .Add( _disabled, when: checkbox.GetDisabledState() )
            .Add( checkboxGroup?.CheckboxClasses?.Base )
            .Add( checkbox.Classes?.Base )
            .Add( checkbox.Class )
            .ToString();
    }

    public static string GetWrapperStyles( LumexCheckbox checkbox )
    {
        var checkboxGroup = checkbox.Context?.Owner;

        return ElementClass.Empty()
            .Add( _wrapper )
            .Add( GetColorStyles( checkbox.Color ) )
            .Add( GetSizeStyles( checkbox.Size, slot: "wrapper" ) )
            .Add( GetRadiusStyles( checkbox.Radius ) )
            .Add( checkboxGroup?.CheckboxClasses?.Wrapper )
            .Add( checkbox.Classes?.Wrapper )
            .ToString();
    }

    public static string GetIconStyles( LumexCheckbox checkbox )
    {
        var checkboxGroup = checkbox.Context?.Owner;

        return ElementClass.Empty()
            .Add( _icon )
            .Add( GetSizeStyles( checkbox.Size, slot: "icon" ) )
            .Add( checkboxGroup?.CheckboxClasses?.Icon )
            .Add( checkbox.Classes?.Icon )
            .ToString();
    }

    public static string GetLabelStyles( LumexCheckbox checkbox )
    {
        var checkboxGroup = checkbox.Context?.Owner;

        return ElementClass.Empty()
            .Add( _label )
            .Add( GetSizeStyles( checkbox.Size, slot: "label" ) )
            .Add( checkboxGroup?.CheckboxClasses?.Label )
            .Add( checkbox.Classes?.Label )
            .ToString();
    }
}

[ExcludeFromCodeCoverage]
internal readonly record struct CheckboxGroup
{
    private readonly static string _base = ElementClass.Empty()
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
        .ToString();

    private readonly static string _description = ElementClass.Empty()
        .Add( "text-small" )
        .Add( "text-foreground-400" )
        .ToString();

    public static string GetStyles( LumexCheckboxGroup checkboxGroup )
    {
        return ElementClass.Empty()
            .Add( _base )
            .Add( checkboxGroup.Classes?.Base )
            .Add( checkboxGroup.Class )
            .ToString();
    }

    public static string GetLabelStyles( LumexCheckboxGroup checkboxGroup )
    {
        return ElementClass.Empty()
            .Add( _label )
            .Add( checkboxGroup.Classes?.Label )
            .ToString();
    }

    public static string GetWrapperStyles( LumexCheckboxGroup checkboxGroup )
    {
        return ElementClass.Empty()
            .Add( _wrapper )
            .Add( checkboxGroup.Classes?.Wrapper )
            .ToString();
    }

    public static string GetDescriptionStyles( LumexCheckboxGroup checkboxGroup )
    {
        return ElementClass.Empty()
            .Add( _description )
            .Add( checkboxGroup.Classes?.Description )
            .ToString();
    }
}
