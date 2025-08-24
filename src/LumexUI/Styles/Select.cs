using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using TailwindMerge;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal class Select
{
    private readonly static string _base = ElementClass.Empty()
        .Add( "relative" )
        .Add( "group" )
        .Add( "flex" )
        .Add( "flex-col" )
        .ToString();

    private readonly static string _label = ElementClass.Empty()
        .Add( "z-10" )
        .Add( "block" )
        .Add( "absolute" )
        .Add( "origin-top-left" )
        .Add( "text-small" )
        .Add( "text-foreground-500" )
        .Add( "pointer-events-none" )
        // transition
        .Add( "will-change-auto" )
        .Add( "origin-top-left" )
        .Add( "transition-[transform,color,left,opacity,translate,scale]" )
        .Add( "motion-reduce:transition-none" )
        .ToString();

    private readonly static string _mainWrapper = ElementClass.Empty()
        .Add( "w-full" )
        .Add( "flex" )
        .Add( "flex-col" )
        .ToString();

    private readonly static string _trigger = ElementClass.Empty()
        .Add( "relative" )
        .Add( "w-full" )
        .Add( "inline-flex" )
        .Add( "items-center" )
        .Add( "gap-3" )
        .Add( "px-3" )
        .Add( "shadow-xs" )
        .Add( "outline-hidden" )
        .Add( "cursor-pointer" )
        // transition
        .Add( "transition-[background]" )
        .Add( "motion-reduce:transition-none" )
        .ToString();

    private readonly static string _innerWrapper = ElementClass.Empty()
        .Add( "h-full" )
        .Add( "min-h-4" )
        .Add( "w-[calc(100%_-_--spacing(6))]" )
        .Add( "gap-1.5" )
        .Add( "inline-flex" )
        .Add( "items-center" )
        .ToString();

    private readonly static string _selectorIcon = ElementClass.Empty()
        .Add( "absolute" )
        .Add( "w-4" )
        .Add( "h-4" )
        .Add( "end-3" )
        .Add( "data-[open=true]:rotate-180" )
        // transition
        .Add( "duration-200" )
        .Add( "ease-out" )
        .Add( "transition-colors-transform-opacity" )
        .Add( "motion-reduce:transition-none" )
        .ToString();

    private readonly static string _value = ElementClass.Empty()
        .Add( "w-full" )
        .Add( "text-left" )
        .Add( "text-foreground-500" )
        .Add( "truncate" )
        // transition
        .Add( "transition-colors" )
        .Add( "motion-reduce:transition-none" )
        .ToString();

    private readonly static string _listbox = ElementClass.Empty()
        .Add( "overflow-y-auto" )
        .Add( "scrollbar-hide" )
        .ToString();

    private readonly static string _popoverContent = ElementClass.Empty()
        .Add( "w-full" )
        .Add( "p-1" )
        .Add( "overflow-hidden" )
        .ToString();

    private readonly static string _helperWrapper = ElementClass.Empty()
        .Add( "relative" )
        .Add( "flex" )
        .Add( "flex-col" )
        .Add( "gap-1.5" )
        .Add( "p-1" )
        .ToString();

    private readonly static string _description = ElementClass.Empty()
        .Add( "text-tiny" )
        .Add( "text-foreground-400" )
        .ToString();

    private readonly static string _errorMessage = ElementClass.Empty()
        .Add( "text-tiny" )
        .Add( "text-danger" )
        .ToString();

    private readonly static string _fullWidth = ElementClass.Empty()
        .Add( "w-full" )
        .ToString();

    public static SelectSlots GetStyles<T>( LumexSelect<T> select, TwMerge twMerge )
    {
        return new SelectSlots()
        {
			Base = twMerge.Merge(
                ElementClass.Empty()
                    .Add( _base )
                    .Add( _fullWidth, when: select.FullWidth )
                    .Add( GetDisabledStyles( slot: nameof( _base ) ), when: select.Disabled )
                    .Add( GetLabelPlacementStyles( select.LabelPlacement, slot: nameof( _base ) ) )
                    .Add( GetCompoundStyles( select.LabelPlacement, select.Size, slot: nameof( _base ) ) )
                    .Add( select.Classes?.Base )
                    .Add( select.Class )
                    .ToString() ),

            Label = twMerge.Merge(
                ElementClass.Empty()
                    .Add( _label )
                    .Add( GetInvalidStyles( slot: nameof( _label ) ), when: select.Invalid )
                    .Add( GetRequiredStyles( slot: nameof( _label ) ), when: select.Required )
                    .Add( GetSizeStyles( select.Size, slot: nameof( _label ) ) )
                    .Add( GetLabelPlacementStyles( select.LabelPlacement, slot: nameof( _label ) ) )
                    .Add( GetCompoundStyles( select.Variant, select.Color, slot: nameof( _label ) ) )
					.Add( GetCompoundStyles( select.Variant, slot: nameof( _label ) ), when: select.Invalid )
                    .Add( GetCompoundStyles( select.LabelPlacement, select.Size, slot: nameof( _label ) ) )
					.Add( GetCompoundStyles( select.LabelPlacement, slot: nameof( _label ) ), when: select.Color is ThemeColor.Default )
                    .Add( GetCompoundStyles( select.Size, select.Variant, slot: nameof( _label ) ), when: select.LabelPlacement is LabelPlacement.Inside )
                    .Add( select.Classes?.Label )
                    .ToString() ),

            MainWrapper = twMerge.Merge(
                ElementClass.Empty()
                    .Add( _mainWrapper )
                    .Add( select.Classes?.MainWrapper )
                    .ToString() ),

            Trigger = twMerge.Merge(
                ElementClass.Empty()
                    .Add( _trigger )
                    .Add( GetDisabledStyles( slot: nameof( _trigger ) ), when: select.Disabled )
                    .Add( GetSizeStyles( select.Size, slot: nameof( _trigger ) ) )
                    .Add( GetRadiusStyles( select.Radius, slot: nameof( _trigger ) ) )
                    .Add( GetVariantStyles( select.Variant, slot: nameof( _trigger ) ) )
                    .Add( GetLabelPlacementStyles( select.LabelPlacement, slot: nameof( _trigger ) ) )
                    .Add( GetCompoundStyles( select.Variant, select.Color, slot: nameof( _trigger ) ) )
                    .Add( GetCompoundStyles( select.Variant, slot: nameof( _trigger ) ), when: select.Invalid )
                    .Add( GetCompoundStyles( select.LabelPlacement, select.Size, slot: nameof( _trigger ) ) )
                    .Add( select.Classes?.Trigger )
                    .ToString() ),

            InnerWrapper = twMerge.Merge(
                ElementClass.Empty()
                    .Add( _innerWrapper )
                    .Add( GetCompoundStyles( select.LabelPlacement, select.Size, slot: nameof( _innerWrapper ) ) )
                    .Add( select.Classes?.InnerWrapper )
                    .ToString() ),

            SelectorIcon = twMerge.Merge(
                ElementClass.Empty()
                    .Add( _selectorIcon )
                    .Add( GetInvalidStyles( slot: nameof( _selectorIcon ) ), when: select.Invalid )
					.Add( GetCompoundStyles( select.Variant, slot: nameof( _selectorIcon ) ), when: select.Invalid )
					.Add( select.Classes?.SelectorIcon )
                    .ToString() ),

            Value = twMerge.Merge(
                ElementClass.Empty()
                    .Add( _value )
                    .Add( GetInvalidStyles( slot: nameof( _value ) ), when: select.Invalid )
                    .Add( GetSizeStyles( select.Size, slot: nameof( _value ) ) )
                    .Add( GetVariantStyles( select.Variant, slot: nameof( _value ) ) )
                    .Add( GetCompoundStyles( select.Variant, select.Color, slot: nameof( _value ) ) )
					.Add( GetCompoundStyles( select.Variant, slot: nameof( _value ) ), when: select.Invalid )
					.Add( select.Classes?.Value )
                    .ToString() ),

            Listbox = twMerge.Merge(
                ElementClass.Empty()
                    .Add( _listbox )
                    .Add( select.Classes?.Listbox )
                    .ToString() ),

            PopoverContent = twMerge.Merge(
                ElementClass.Empty()
                    .Add( _popoverContent )
                    .Add( select.Classes?.PopoverContent )
                    .ToString() ),

            HelperWrapper = twMerge.Merge(
                ElementClass.Empty()
                    .Add( _helperWrapper )
                    .Add( select.Classes?.HelperWrapper )
                    .ToString() ),

            Description = twMerge.Merge(
                ElementClass.Empty()
                    .Add( _description )
                    .Add( select.Classes?.Description )
                    .ToString() ),

            ErrorMessage = twMerge.Merge(
                ElementClass.Empty()
                    .Add( _errorMessage )
                    .Add( select.Classes?.ErrorMessage )
                    .ToString() ),
        };
    }

    private static ElementClass GetVariantStyles( InputVariant variant, string slot )
    {
        return variant switch
        {
            InputVariant.Flat => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "bg-default-100" )
                    .Add( "group-hover:bg-default-200" ), when: slot is nameof( _trigger ) ),

            InputVariant.Outlined => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "border-2" )
                    .Add( "border-default-200" )
                    .Add( "data-[open=true]:border-default-foreground" )
                    .Add( "group-data-[focus=true]:border-default-foreground" )
                    .Add( "group-data-[focus=false]:hover:border-default-400" )
                    .Add( "transition-colors" )
                    .Add( "motion-reduce:transition-none" ), when: slot is nameof( _trigger ) )
                .Add( "group-data-[has-value=true]:text-default-foreground", when: slot is nameof( _value ) ),

            InputVariant.Underlined => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "!px-1" )
                    .Add( "!pb-0" )
                    .Add( "!gap-0" )
                    .Add( "!rounded-none" )
                    .Add( "relative" )
                    .Add( "border-b-2" )
                    .Add( "border-default-200" )
                    .Add( "shadow-[0_1px_0px_0_rgba(0,0,0,0.05)]" )
                    .Add( "hover:border-default-300" )
                    .Add( "after:w-0" )
                    .Add( "after:origin-center" )
                    .Add( "after:bg-default-foreground" )
                    .Add( "after:absolute" )
                    .Add( "after:left-1/2" )
                    .Add( "after:-translate-x-1/2" )
                    .Add( "after:-bottom-[2px]" )
                    .Add( "after:h-[2px]" )
                    .Add( "data-[open=true]:after:w-full" )
                    .Add( "group-data-[focus=true]:after:w-full" )
                    .Add( "after:transition-[width]" )
                    .Add( "motion-reduce:after:transition-none" ), when: slot is nameof( _trigger ) )
                .Add( "group-data-[has-value=true]:text-default-foreground", when: slot is nameof( _value ) ),

            _ => ElementClass.Empty()
        };
    }

    private static ElementClass GetSizeStyles( Size size, string slot )
    {
        return size switch
        {
            Size.Small => ElementClass.Empty()
                .Add( "text-tiny", when: slot is nameof( _label ) )
                .Add( "h-8 min-h-8 rounded-small", when: slot is nameof( _trigger ) )
                .Add( "text-small", when: slot is nameof( _value ) ),

            Size.Medium => ElementClass.Empty()
                .Add( "h-10 min-h-10 rounded-medium", when: slot is nameof( _trigger ) )
                .Add( "text-small", when: slot is nameof( _value ) ),

            Size.Large => ElementClass.Empty()
                .Add( "h-12 min-h-12 rounded-large", when: slot is nameof( _trigger ) )
                .Add( "text-medium", when: slot is nameof( _value ) ),

            _ => ElementClass.Empty()
        };
    }

    private static ElementClass GetRadiusStyles( Radius? radius, string slot )
    {
        return radius switch
        {
            Radius.None => ElementClass.Empty()
                .Add( "rounded-none", when: slot is nameof( _trigger ) ),

            Radius.Small => ElementClass.Empty()
                .Add( "rounded-small", when: slot is nameof( _trigger ) ),

            Radius.Medium => ElementClass.Empty()
                .Add( "rounded-medium", when: slot is nameof( _trigger ) ),

            Radius.Large => ElementClass.Empty()
                .Add( "rounded-large", when: slot is nameof( _trigger ) ),

            _ => ElementClass.Empty()
        };
    }

    private static ElementClass GetLabelPlacementStyles( LabelPlacement labelPlacement, string slot )
    {
        return labelPlacement switch
        {
            LabelPlacement.Outside => ElementClass.Empty()
                .Add( "flex flex-col", when: slot is nameof( _base ) ),

            LabelPlacement.Inside => ElementClass.Empty()
                .Add( "cursor-pointer group-data-[filled=true]:scale-[0.85]", when: slot is nameof( _label ) )
                .Add( "flex-col items-start justify-center gap-0", when: slot is nameof( _trigger ) ),

            _ => ElementClass.Empty()
        };
    }

    private static ElementClass GetDisabledStyles( string slot )
    {
        return ElementClass.Empty()
            .Add( "opacity-disabled pointer-events-none", when: slot is nameof( _base ) )
            .Add( "pointer-events-none", when: slot is nameof( _trigger ) );
    }

    private static ElementClass GetRequiredStyles( string slot )
    {
        return ElementClass.Empty()
            .Add( "after:content-['*'] after:text-danger after:ms-0.5", when: slot is nameof( _label ) );
    }

    private static ElementClass GetInvalidStyles( string slot )
    {
        return ElementClass.Empty()
            .Add( "text-danger!", when: slot is nameof( _label ) )
            .Add( "text-danger!", when: slot is nameof( _value ) )
            .Add( "text-danger!", when: slot is nameof( _selectorIcon ) );
    }

    private static ElementClass GetCompoundStyles( InputVariant variant, ThemeColor color, string slot )
    {
        return (variant, color) switch
        {
            // flat / color

            (InputVariant.Flat, ThemeColor.Default ) => ElementClass.Empty()
                .Add( "group-data-[has-value=true]:text-default-foreground", when: slot is nameof( _value ) ),

            (InputVariant.Flat, ThemeColor.Primary ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
					.Add( "bg-primary/20" )
					.Add( "group-hover:bg-primary/10" )
					.Add( "group-data-[focus=true]:bg-primary/10" ), when: slot is nameof( _trigger ) )
                .Add( "text-primary dark:text-primary-500", when: slot is nameof( _value ) )
                .Add( "text-primary dark:text-primary-500", when: slot is nameof( _label ) ),

            (InputVariant.Flat, ThemeColor.Secondary ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
					.Add( "bg-secondary/20" )
					.Add( "group-hover:bg-secondary/10" )
					.Add( "group-data-[focus=true]:bg-secondary/10" ), when: slot is nameof( _trigger ) )
                .Add( "text-secondary dark:text-secondary-500", when: slot is nameof( _value ) )
                .Add( "text-secondary dark:text-secondary-500", when: slot is nameof( _label ) ),

            (InputVariant.Flat, ThemeColor.Success ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
					.Add( "bg-success/20" )
					.Add( "group-hover:bg-success/10" )
					.Add( "group-data-[focus=true]:bg-success/10" ), when: slot is nameof( _trigger ) )
                .Add( "text-success-700 dark:text-success", when: slot is nameof( _value ) )
                .Add( "text-success-700 dark:text-success", when: slot is nameof( _label ) ),

            (InputVariant.Flat, ThemeColor.Warning ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
					.Add( "bg-warning/20" )
					.Add( "group-hover:bg-warning/10" )
					.Add( "group-data-[focus=true]:bg-warning/10" ), when: slot is nameof( _trigger ) )
                .Add( "text-warning-700 dark:text-warning", when: slot is nameof( _value ) )
                .Add( "text-warning-700 dark:text-warning", when: slot is nameof( _label ) ),

            (InputVariant.Flat, ThemeColor.Danger ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
					.Add( "bg-danger/20" )
					.Add( "group-hover:bg-danger/10" )
					.Add( "group-data-[focus=true]:bg-danger/10" ), when: slot is nameof( _trigger ) )
                .Add( "text-danger-700 dark:text-danger-500", when: slot is nameof( _value ) )
                .Add( "text-danger-700 dark:text-danger-500", when: slot is nameof( _label ) ),

            (InputVariant.Flat, ThemeColor.Info ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
					.Add( "bg-info/20" )
					.Add( "group-hover:bg-info/10" )
					.Add( "group-data-[focus=true]:bg-info/10" ), when: slot is nameof( _trigger ) )
                .Add( "text-info dark:text-info-500", when: slot is nameof( _value ) )
                .Add( "text-info dark:text-info-500", when: slot is nameof( _label ) ),

            // underlined / color

            (InputVariant.Underlined, ThemeColor.Default ) => ElementClass.Empty()
                .Add( "group-data-[has-value=true]:text-foreground", when: slot is nameof( _value ) ),

            (InputVariant.Underlined, ThemeColor.Primary ) => ElementClass.Empty()
                .Add( "after:bg-primary", when: slot is nameof( _trigger ) )
                .Add( "text-primary", when: slot is nameof( _label ) ),

            (InputVariant.Underlined, ThemeColor.Secondary ) => ElementClass.Empty()
                .Add( "after:bg-secondary", when: slot is nameof( _trigger ) )
                .Add( "text-secondary", when: slot is nameof( _label ) ),

            (InputVariant.Underlined, ThemeColor.Success ) => ElementClass.Empty()
                .Add( "after:bg-success", when: slot is nameof( _trigger ) )
                .Add( "text-success", when: slot is nameof( _label ) ),

            (InputVariant.Underlined, ThemeColor.Warning ) => ElementClass.Empty()
                .Add( "after:bg-warning", when: slot is nameof( _trigger ) )
                .Add( "text-warning", when: slot is nameof( _label ) ),

            (InputVariant.Underlined, ThemeColor.Danger ) => ElementClass.Empty()
                .Add( "after:bg-danger", when: slot is nameof( _trigger ) )
                .Add( "text-danger", when: slot is nameof( _label ) ),

            (InputVariant.Underlined, ThemeColor.Info ) => ElementClass.Empty()
                .Add( "after:bg-info", when: slot is nameof( _trigger ) )
                .Add( "text-info", when: slot is nameof( _label ) ),

            // outlined / color

            (InputVariant.Outlined, ThemeColor.Primary ) => ElementClass.Empty()
                .Add( "data-[open=true]:border-primary group-data-[focus=true]:border-primary", when: slot is nameof( _trigger ) )
                .Add( "text-primary", when: slot is nameof( _label ) ),

            (InputVariant.Outlined, ThemeColor.Secondary ) => ElementClass.Empty()
                .Add( "data-[open=true]:border-secondary group-data-[focus=true]:border-secondary", when: slot is nameof( _trigger ) )
                .Add( "text-secondary", when: slot is nameof( _label ) ),

            (InputVariant.Outlined, ThemeColor.Success ) => ElementClass.Empty()
                .Add( "data-[open=true]:border-success group-data-[focus=true]:border-success", when: slot is nameof( _trigger ) )
                .Add( "text-success", when: slot is nameof( _label ) ),

            (InputVariant.Outlined, ThemeColor.Warning ) => ElementClass.Empty()
                .Add( "data-[open=true]:border-warning group-data-[focus=true]:border-warning", when: slot is nameof( _trigger ) )
                .Add( "text-warning", when: slot is nameof( _label ) ),

            (InputVariant.Outlined, ThemeColor.Danger ) => ElementClass.Empty()
                .Add( "data-[open=true]:border-danger group-data-[focus=true]:border-danger", when: slot is nameof( _trigger ) )
                .Add( "text-danger", when: slot is nameof( _label ) ),

            (InputVariant.Outlined, ThemeColor.Info ) => ElementClass.Empty()
                .Add( "data-[open=true]:border-info group-data-[focus=true]:border-info", when: slot is nameof( _trigger ) )
                .Add( "text-info", when: slot is nameof( _label ) ),

            _ => ElementClass.Empty()
        };
    }

    private static ElementClass GetCompoundStyles( LabelPlacement labelPLacement, string slot )
    {
        // color=default
        return labelPLacement switch
        {
            LabelPlacement.Inside => ElementClass.Empty()
                .Add( "group-data-[filled=true]:text-default-600", when: slot is nameof( _label ) ),

            LabelPlacement.Outside => ElementClass.Empty()
                .Add( "group-data-[filled=true]:text-foreground", when: slot is nameof( _label ) ),

            _ => ElementClass.Empty()
        };
    }

    private static ElementClass GetCompoundStyles( LabelPlacement labelPLacement, Size size, string slot )
    {
        return (labelPLacement, size) switch
        {
            // inside / size

            (LabelPlacement.Inside, Size.Small ) => ElementClass.Empty()
                .Add( "text-small", when: slot is nameof( _label ) )
                .Add( "h-12 min-h-12 py-1.5", when: slot is nameof( _trigger ) )
                .Add( "group-has-[label]:pt-4", when: slot is nameof( _innerWrapper ) ),

            (LabelPlacement.Inside, Size.Medium ) => ElementClass.Empty()
                .Add( "text-small", when: slot is nameof( _label ) )
                .Add( "h-14 min-h-14 py-2", when: slot is nameof( _trigger ) )
                .Add( "group-has-[label]:pt-4", when: slot is nameof( _innerWrapper ) ),

            (LabelPlacement.Inside, Size.Large ) => ElementClass.Empty()
                .Add( "text-medium", when: slot is nameof( _label ) )
                .Add( "h-16 min-h-16 py-2.5", when: slot is nameof( _trigger ) )
                .Add( "group-has-[label]:pt-5", when: slot is nameof( _innerWrapper ) ),

            // outside / size

            (LabelPlacement.Outside, Size.Small ) => ElementClass.Empty()
                .Add( "justify-end has-[label]:mt-[calc(var(--text-small)_+_8px)]", when: slot is nameof( _base ) )
                .Add( ElementClass.Empty()
                    .Add( "text-tiny" )
                    .Add( "z-20" )
                    .Add( "top-1/2" )
                    .Add( "start-2" )
                    .Add( "-translate-y-1/2" )
                    .Add( "group-data-[filled=true]:start-0" )
                    .Add( "group-data-[filled=true]:-translate-y-[calc(100%_+_var(--text-tiny)/2_+_16px)]" ), when: slot is nameof( _label ) ),

            (LabelPlacement.Outside, Size.Medium ) => ElementClass.Empty()
                .Add( "justify-end has-[label]:mt-[calc(var(--text-small)_+_10px)]", when: slot is nameof( _base ) )
                .Add( ElementClass.Empty()
                    .Add( "text-small" )
                    .Add( "z-20" )
                    .Add( "top-1/2" )
                    .Add( "start-3" )
                    .Add( "-translate-y-1/2" )
                    .Add( "group-data-[filled=true]:start-0" )
                    .Add( "group-data-[filled=true]:-translate-y-[calc(100%_+_var(--text-small)/2_+_20px)]" ), when: slot is nameof( _label ) ),

            (LabelPlacement.Outside, Size.Large ) => ElementClass.Empty()
                .Add( "justify-end has-[label]:mt-[calc(var(--text-small)_+_12px)]", when: slot is nameof( _base ) )
                .Add( ElementClass.Empty()
                    .Add( "text-medium" )
                    .Add( "z-20" )
                    .Add( "top-1/2" )
                    .Add( "start-3" )
                    .Add( "-translate-y-1/2" )
                    .Add( "group-data-[filled=true]:start-0" )
                    .Add( "group-data-[filled=true]:-translate-y-[calc(100%_+_var(--text-small)/2_+_24px)]" ), when: slot is nameof( _label ) ),

            _ => ElementClass.Empty()
        };
    }

    private static ElementClass GetCompoundStyles( Size size, InputVariant variant, string slot )
    {
        // labelPlacement=inside
        return (size, variant) switch
        {
            // size / flat

            (Size.Small, InputVariant.Flat ) => ElementClass.Empty()
                .Add( "group-data-[filled=true]:-translate-y-[calc(50%_+_var(--text-tiny)/2_-_8px)]", when: slot is nameof( _label ) ),

            (Size.Medium, InputVariant.Flat ) => ElementClass.Empty()
                .Add( "group-data-[filled=true]:-translate-y-[calc(50%_+_var(--text-small)/2_-_6px)]", when: slot is nameof( _label ) ),

            (Size.Large, InputVariant.Flat ) => ElementClass.Empty()
                .Add( "group-data-[filled=true]:-translate-y-[calc(50%_+_var(--text-small)/2_-_8px)]", when: slot is nameof( _label ) ),

            // size / outlined

            (Size.Small, InputVariant.Outlined ) => ElementClass.Empty()
                .Add( "group-data-[filled=true]:-translate-y-[calc(50%_+_var(--text-tiny)/2_-_8px_-_--spacing(0.5))]", when: slot is nameof( _label ) ),

            (Size.Medium, InputVariant.Outlined ) => ElementClass.Empty()
                .Add( "group-data-[filled=true]:-translate-y-[calc(50%_+_var(--text-small)/2_-_6px_-_--spacing(0.5))]", when: slot is nameof( _label ) ),

            (Size.Large, InputVariant.Outlined ) => ElementClass.Empty()
                .Add( "group-data-[filled=true]:-translate-y-[calc(50%_+_var(--text-small)/2_-_8px_-_--spacing(0.5))]", when: slot is nameof( _label ) ),

            // size / underlined

            (Size.Small, InputVariant.Underlined ) => ElementClass.Empty()
                .Add( "group-data-[filled=true]:-translate-y-[calc(50%_+_var(--text-tiny)/2_-_5px)]", when: slot is nameof( _label ) ),

            (Size.Medium, InputVariant.Underlined ) => ElementClass.Empty()
                .Add( "group-data-[filled=true]:-translate-y-[calc(50%_+_var(--text-small)/2_-_3.5px)]", when: slot is nameof( _label ) ),

            (Size.Large, InputVariant.Underlined ) => ElementClass.Empty()
                .Add( "group-data-[filled=true]:-translate-y-[calc(50%_+_var(--text-small)/2_-_4px)]", when: slot is nameof( _label ) ),

            _ => ElementClass.Empty()
        };
    }

    private static ElementClass GetCompoundStyles( InputVariant variant, string slot )
    {
        // invalid=true
        return variant switch
        {
            InputVariant.Flat => ElementClass.Empty()
                .Add( "bg-danger/20 group-hover:bg-danger/10 group-data-[focus=true]:bg-danger/10", when: slot is nameof( _trigger ) )
				// For a better accessibility
				.Add( "text-danger-700! dark:text-danger-500!", when: slot is nameof( _label ) )
				.Add( "text-danger-700! dark:text-danger-500!", when: slot is nameof( _value ) )
				.Add( "text-danger-700! dark:text-danger-500!", when: slot is nameof( _selectorIcon ) ),

            InputVariant.Outlined => ElementClass.Empty()
                .Add( "border-danger group-data-[focus=true]:border-danger", when: slot is nameof( _trigger ) ),

            InputVariant.Underlined => ElementClass.Empty()
                .Add( "after:bg-danger", when: slot is nameof( _trigger ) ),

            _ => ElementClass.Empty()
		};
    }
}
