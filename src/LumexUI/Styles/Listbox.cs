using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using TailwindMerge;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal class Listbox
{
    private readonly static string _base = ElementClass.Empty()
        .Add( "relative" )
        .Add( "w-full" )
        .Add( "p-1" )
        .Add( "gap-1" )
        .Add( "flex" )
        .Add( "flex-col" )
        .ToString();

    private readonly static string _list = ElementClass.Empty()
        .Add( "w-full" )
        .Add( "gap-0.5" )
        .Add( "flex" )
        .Add( "flex-col" )
        .ToString();

    private readonly static string _emptyContent = ElementClass.Empty()
        .Add( "w-full" )
        .Add( "h-10" )
        .Add( "px-2" )
        .Add( "py-1.5" )
        .Add( "text-start" )
        .Add( "text-foreground-400" )
        .ToString();

    public static ListboxSlots GetStyles<T>( LumexListbox<T> listbox, TwMerge twMerge )
    {
        return new ListboxSlots()
        {
            Base = twMerge.Merge(
                ElementClass.Empty()
                    .Add( _base )
                    .Add( listbox.Classes?.Base )
                    .Add( listbox.Class )
                    .ToString() ),

            List = twMerge.Merge(
                ElementClass.Empty()
                    .Add( _list )
                    .Add( listbox.Classes?.List )
                    .ToString() ),

            EmptyContent = twMerge.Merge(
                ElementClass.Empty()
                    .Add( _emptyContent )
                    .Add( listbox.Classes?.EmptyContent )
                    .ToString() ),
        };
    }
}

[ExcludeFromCodeCoverage]
internal class ListboxItem
{
    private readonly static string _base = ElementClass.Empty()
        .Add( "relative" )
        .Add( "group" )
        .Add( "w-full" )
        .Add( "h-full" )
        .Add( "px-2" )
        .Add( "py-1.5" )
        .Add( "gap-2" )
        .Add( "flex" )
        .Add( "items-center" )
        .Add( "justify-between" )
        .Add( "rounded-small" )
        .Add( "cursor-pointer" )
        // transition
        .Add( "hover:transition-colors-shadow" )
        // focus ring
        .Add( Utils.FocusVisible )
        .ToString();

    private readonly static string _wrapper = ElementClass.Empty()
        .Add( "w-full" )
        .Add( "flex" )
        .Add( "flex-col" )
        .Add( "items-start" )
        .Add( "justify-center" )
        .ToString();

    private readonly static string _title = ElementClass.Empty()
        .Add( "flex-1" )
        .Add( "text-small" )
        .Add( "truncate" )
        .ToString();

    private readonly static string _description = ElementClass.Empty()
        .Add( "w-full" )
        .Add( "text-tiny" )
        .Add( "text-foreground-500" )
        .Add( "group-hover:text-current" )
        .ToString();

    private readonly static string _selectedIcon = ElementClass.Empty()
        .Add( "w-3" )
        .Add( "h-3" )
        .Add( "flex-shrink-0" )
        .Add( "text-inherit" )
        .ToString();

    private readonly static string _disabled = ElementClass.Empty()
        .Add( "opacity-disabled" )
        .Add( "pointer-events-none" )
        .ToString();

    public static ListboxItemSlots GetStyles<T>( LumexListboxItem<T> listboxItem, TwMerge twMerge )
    {
        var listbox = listboxItem.Context?.Owner;

        return new ListboxItemSlots()
        {
			Base = twMerge.Merge(
                ElementClass.Empty()
                    .Add( _base )
                    .Add( _disabled, when: listboxItem.GetDisabledState() )
                    .Add( GetVariantStyles( listboxItem.Variant, slot: nameof( _base ) ) )
                    .Add( GetCompoundStyles( listboxItem.Variant, listboxItem.Color, slot: nameof( _base ) ) )
                    .Add( listbox?.ItemClasses?.Base )
                    .Add( listboxItem.Classes?.Base )
                    .Add( listboxItem.Class )
                    .ToString() ),

            Wrapper = twMerge.Merge(
                ElementClass.Empty()
                    .Add( _wrapper )
                    .Add( listbox?.ItemClasses?.Wrapper )
                    .Add( listboxItem.Classes?.Wrapper )
                    .ToString() ),

            Title = twMerge.Merge(
                ElementClass.Empty()
                    .Add( _title )
                    .Add( listbox?.ItemClasses?.Title )
                    .Add( listboxItem.Classes?.Title )
                    .ToString() ),

            Description = twMerge.Merge(
                ElementClass.Empty()
                    .Add( _description )
                    .Add( listbox?.ItemClasses?.Description )
                    .Add( listboxItem.Classes?.Description )
                    .ToString() ),

            SelectedIcon = twMerge.Merge(
                ElementClass.Empty()
                    .Add( _selectedIcon )
                    .Add( listbox?.ItemClasses?.SelectedIcon )
                    .Add( listboxItem.Classes?.SelectedIcon )
                    .ToString() ),
        };
    }

    private static ElementClass GetVariantStyles( ListboxVariant variant, string slot )
    {
        return variant switch
        {
            ListboxVariant.Solid => ElementClass.Empty()
                .Add( "", when: slot is nameof( _base ) ),

            ListboxVariant.Outlined => ElementClass.Empty()
                .Add( "border-2 border-transparent bg-transparent", when: slot is nameof( _base ) ),

            ListboxVariant.Flat => ElementClass.Empty()
                .Add( "", when: slot is nameof( _base ) ),

            ListboxVariant.Shadow => ElementClass.Empty()
                .Add( "hover:shadow-md", when: slot is nameof( _base ) ),

            ListboxVariant.Light => ElementClass.Empty()
                .Add( "bg-transparent", when: slot is nameof( _base ) ),

            _ => ElementClass.Empty()
        };
    }

    private static ElementClass GetCompoundStyles( ListboxVariant variant, ThemeColor color, string slot )
    {
        return (variant, color) switch
        {
            // solid / color

            (ListboxVariant.Solid, ThemeColor.Default ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:bg-default hover:text-default-foreground" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Solid, ThemeColor.Primary ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:bg-primary hover:text-primary-foreground" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Solid, ThemeColor.Secondary ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:bg-secondary hover:text-secondary-foreground" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Solid, ThemeColor.Success ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:bg-success hover:text-success-foreground" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Solid, ThemeColor.Warning ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:bg-warning hover:text-warning-foreground" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Solid, ThemeColor.Danger ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:bg-danger hover:text-danger-foreground" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Solid, ThemeColor.Info ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:bg-info hover:text-info-foreground" ), when: slot is nameof( _base ) ),

            // outlined / color

            (ListboxVariant.Outlined, ThemeColor.Default ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:border-default" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Outlined, ThemeColor.Primary ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:border-primary hover:text-primary" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Outlined, ThemeColor.Secondary ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:border-secondary hover:text-secondary" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Outlined, ThemeColor.Success ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:border-success hover:text-success" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Outlined, ThemeColor.Warning ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:border-warning hover:text-warning" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Outlined, ThemeColor.Danger ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:border-danger hover:text-danger" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Outlined, ThemeColor.Info ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:border-info hover:text-info" ), when: slot is nameof( _base ) ),

            // flat / color

            (ListboxVariant.Flat, ThemeColor.Default ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:bg-default/40 hover:text-default-foreground" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Flat, ThemeColor.Primary ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:bg-primary/20 hover:text-primary-600" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Flat, ThemeColor.Secondary ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:bg-secondary/20 hover:text-secondary-600" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Flat, ThemeColor.Success ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:bg-success/20 hover:text-success-800 dark:hover:text-success-600" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Flat, ThemeColor.Warning ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:bg-warning/20 hover:text-warning-800 dark:hover:text-warning-700" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Flat, ThemeColor.Danger ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:bg-danger/20 hover:text-danger-600" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Flat, ThemeColor.Info ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:bg-info/20 hover:text-info-600" ), when: slot is nameof( _base ) ),

            // shadow / color

            (ListboxVariant.Shadow, ThemeColor.Default ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:shadow-default/40 hover:bg-default hover:text-default-foreground" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Shadow, ThemeColor.Primary ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:shadow-primary/40 hover:bg-primary hover:text-primary-foreground" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Shadow, ThemeColor.Secondary ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:shadow-secondary/40 hover:bg-secondary hover:text-secondary-foreground" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Shadow, ThemeColor.Success ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:shadow-success/40 hover:bg-success hover:text-success-foreground" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Shadow, ThemeColor.Warning ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:shadow-warning/40 hover:bg-warning hover:text-warning-foreground" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Shadow, ThemeColor.Danger ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:shadow-danger/40 hover:bg-danger hover:text-danger-foreground" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Shadow, ThemeColor.Info ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:shadow-info/40 hover:bg-info hover:text-info-foreground" ), when: slot is nameof( _base ) ),

            // light / color

            (ListboxVariant.Light, ThemeColor.Default ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:text-default-500" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Light, ThemeColor.Primary ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:text-primary" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Light, ThemeColor.Secondary ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:text-secondary" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Light, ThemeColor.Success ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:text-success" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Light, ThemeColor.Warning ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:text-warning" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Light, ThemeColor.Danger ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:text-danger" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Light, ThemeColor.Info ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:text-info" ), when: slot is nameof( _base ) ),

            _ => ElementClass.Empty()
        };
    }
}
