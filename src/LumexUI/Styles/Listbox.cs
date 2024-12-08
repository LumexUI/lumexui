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
            Root = twMerge.Merge(
                ElementClass.Empty()
                    .Add( _base )
                    .Add( listbox.Class )
                    .ToString() ),

            List = twMerge.Merge(
                ElementClass.Empty()
                    .Add( _list )
                    .ToString() ),

            EmptyContent = twMerge.Merge(
                ElementClass.Empty()
                    .Add( _emptyContent )
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
        .ToString();

    public static ListboxItemSlots GetStyles<T>( LumexListboxItem<T> listboxItem, TwMerge twMerge )
    {
        var listbox = listboxItem.Context.Owner;

        return new ListboxItemSlots()
        {
            Root = twMerge.Merge(
                ElementClass.Empty()
                    .Add( _base )
                    .Add( listboxItem.Class )
                    .Add( GetVariantStyles( listbox.Variant, slot: nameof( _base ) ) )
                    .Add( GetCompoundStyles( listbox.Variant, listboxItem.Color, slot: nameof( _base ) ) )
                    .ToString() ),

            Wrapper = twMerge.Merge(
                ElementClass.Empty()
                    .Add( _wrapper )
                    .ToString() ),

            Title = twMerge.Merge(
                ElementClass.Empty()
                    .Add( _title )
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
                .Add( "border-medium border-transparent bg-transparent", when: slot is nameof( _base ) ),

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
                    .Add( "hover:border-primary" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Outlined, ThemeColor.Secondary ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:border-secondary" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Outlined, ThemeColor.Success ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:border-success" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Outlined, ThemeColor.Warning ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:border-warning" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Outlined, ThemeColor.Danger ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:border-danger" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Outlined, ThemeColor.Info ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:border-info" ), when: slot is nameof( _base ) ),

            // flat / color

            (ListboxVariant.Flat, ThemeColor.Default ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:bg-default/40 hover:text-default-foreground" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Flat, ThemeColor.Primary ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:bg-primary-100 hover:text-primary-foreground" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Flat, ThemeColor.Secondary ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:bg-secondary-100 hover:text-secondary-foreground" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Flat, ThemeColor.Success ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:bg-success-100 hover:text-success-foreground" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Flat, ThemeColor.Warning ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:bg-warning-100 hover:text-warning-foreground" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Flat, ThemeColor.Danger ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:bg-danger-100 hover:text-danger-foreground" ), when: slot is nameof( _base ) ),

            (ListboxVariant.Flat, ThemeColor.Info ) => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "hover:bg-info-100 hover:text-info-foreground" ), when: slot is nameof( _base ) ),

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
