using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using TailwindMerge;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal class DataGrid
{
    private readonly static string _base = ElementClass.Empty()
        .Add( "relative" )
        .Add( "w-full" )
        .Add( "flex" )
        .Add( "flex-col" )
        .Add( "gap-4" )
        .ToString();

    private readonly static string _wrapper = ElementClass.Empty()
        .Add( "relative" )
        .Add( "p-4" )
        .Add( "flex" )
        .Add( "flex-col" )
        .Add( "justify-between" )
        .Add( "gap-4" )
        .Add( "bg-surface1" )
        .Add( "overflow-auto" )
        .ToString();

    private readonly static string _emptyWrapper = ElementClass.Empty()
        .Add( "h-40" )
        .Add( "align-middle" )
        .Add( "text-small" )
        .Add( "text-center" )
        .Add( "text-foreground-400" )
        .ToString();

    private readonly static string _loadingWrapper = ElementClass.Empty()
        .Add( "absolute" )
        .Add( "inset-0" )
        .Add( "flex" )
        .Add( "items-center" )
        .Add( "justify-center" )
        .Add( "text-small" )
        .Add( "bg-surface1/70" )
        .Add( "backdrop-blur-[2px]" )
        .ToString();

    private readonly static string _table = ElementClass.Empty()
        .Add( "min-w-full" )
        .ToString();

    private readonly static string _tHead = ElementClass.Empty()
        .Add( "[&>tr]:first:rounded-lg" )
        .ToString();

    private readonly static string _tr = ElementClass.Empty()
        .Add( "group" )
        // focus
        .Add( Utils.FocusVisible )
        .ToString();

    private readonly static string _th = ElementClass.Empty()
        .Add( "group/th" )
        .Add( "px-3" )
        .Add( "h-10" )
        .Add( "align-middle" )
        .Add( "bg-default-100" )
        .Add( "text-foreground-500" )
        .Add( "text-tiny" )
        .Add( "font-semibold" )
        .Add( "whitespace-nowrap" )
        .Add( "first:rounded-s-lg" )
        .Add( "last:rounded-e-lg" )
        .Add( "hover:text-foreground-400" )
        .Add( "data-[sortable=true]:cursor-pointer" )
        // focus
        .Add( Utils.FocusVisible )
        .ToString();

    private readonly static string _td = ElementClass.Empty()
        .Add( "relative" )
        .Add( "py-2" )
        .Add( "px-3" )
        .Add( "align-middle" )
        .Add( "text-small" )
        // disabled
        .Add( "group-data-[disabled=true]:text-foreground-300" )
        .Add( "group-data-[disabled=true]:cursor-not-allowed" )
        // focus
        .Add( Utils.FocusVisible )
        .ToString();

    private readonly static string _placeholder = ElementClass.Empty()
        .Add( "before:block" )
        .Add( "before:w-3/4" )
        .Add( "before:h-4" )
        .Add( "before:rounded-md" )
        .Add( "before:bg-default-100" )
        .ToString();

    private readonly static string _sortIcon = ElementClass.Empty()
         .Add( "inline-block" )
         .Add( "ms-2" )
         .Add( "opacity-0" )
         .Add( "-rotate-90" )
         .Add( "transition-transform-opacity" )
         .Add( "data-[visible=true]:opacity-100" )
         .Add( "group-hover/th:opacity-100" )
         .Add( "group-aria-[sort=ascending]/th:rotate-90" )
         .ToString();

    private readonly static string _striped = ElementClass.Empty()
        .Add( "group-even:bg-default-100" )
        .ToString();

    private readonly static string _stickyHeader = ElementClass.Empty()
        .Add( "sticky" )
        .Add( "top-0" )
        .Add( "z-20" )
        .Add( "[&>tr]:first:shadow-small" )
        .ToString();

    private readonly static string _align = ElementClass.Empty()
        .Add( "data-[align=start]:text-start" )
        .Add( "data-[align=center]:text-center" )
        .Add( "data-[align=end]:text-end" )
        .ToString();

    public static DataGridSlots GetStyles<T>( LumexDataGrid<T> dataGrid, TwMerge twMerge )
    {
        return new DataGridSlots()
        {
            Base = twMerge.Merge(
                ElementClass.Empty()
                    .Add( _base )
                    .Add( dataGrid.Class )
                    .Add( dataGrid.Classes?.Base )
                    .ToString() ),

            Wrapper = twMerge.Merge(
                ElementClass.Empty()
                    .Add( _wrapper )
                    .Add( GetRadiusStyles( dataGrid.Radius, slot: nameof( _wrapper ) ) )
                    .Add( GetShadowStyles( dataGrid.Shadow, slot: nameof( _wrapper ) ) )
                    .Add( dataGrid.Classes?.Wrapper )
                    .ToString() ),

            EmptyWrapper = twMerge.Merge(
                ElementClass.Empty()
                    .Add( _emptyWrapper )
                    .Add( dataGrid.Classes?.EmptyWrapper )
                    .ToString() ),

            LoadingWrapper = twMerge.Merge(
                ElementClass.Empty()
                    .Add( _loadingWrapper )
                    .Add( dataGrid.Classes?.LoadingWrapper )
                    .ToString() ),

            Table = twMerge.Merge(
                ElementClass.Empty()
                    .Add( _table )
                    .Add( GetLayoutStyles( dataGrid.Layout, slot: nameof( _table ) ) )
                    .Add( dataGrid.Classes?.Table )
                    .ToString() ),

            Thead = twMerge.Merge(
                ElementClass.Empty()
                    .Add( _tHead )
                    .Add( _stickyHeader, when: dataGrid.StickyHeader )
                    .Add( dataGrid.Classes?.Thead )
                    .ToString() ),

            Tbody = twMerge.Merge(
                ElementClass.Empty()
                    .Add( dataGrid.Classes?.Tbody )
                    .ToString() ),

            Tfoot = twMerge.Merge(
                ElementClass.Empty()
                    .Add( dataGrid.Classes?.Tfoot )
                    .ToString() ),

            Tr = twMerge.Merge(
                    ElementClass.Empty()
                    .Add( _tr )
                    .Add( GetHoverableStyles( dataGrid.Hoverable, slot: nameof( _tr ) ) )
                    .Add( dataGrid.Classes?.Tr )
                    .ToString() ),

            Th = twMerge.Merge(
                ElementClass.Empty()
                    .Add( _th )
                    .Add( _align )
                    .Add( dataGrid.Classes?.Th )
                    .ToString() ),

            Td = twMerge.Merge(
                ElementClass.Empty()
                    .Add( _td )
                    .Add( _align )
                    .Add( _striped, when: dataGrid.Striped )
                    .Add( GetColorStyles( dataGrid.Color, slot: nameof( _td ) ) )
                    .Add( GetStripedColorStyles( dataGrid.Color, slot: nameof( _td ) ), when: dataGrid.Striped )
                    .Add( GetHoverableStyles( dataGrid.Hoverable, slot: nameof( _td ) ) )
                    .Add( GetSelectionModeStyles( dataGrid.SelectionMode, slot: nameof( _td ) ) )
                    .Add( dataGrid.Classes?.Td )
                    .ToString() ),

            Placeholder = twMerge.Merge(
                ElementClass.Empty()
                    .Add( _placeholder )
                    .Add( dataGrid.Classes?.Placeholder )
                    .ToString() ),

            SortIcon = twMerge.Merge(
                ElementClass.Empty()
                    .Add( _sortIcon )
                    .Add( dataGrid.Classes?.SortIcon )
                    .ToString() ),
        };
    }

    private static ElementClass GetHoverableStyles( bool hoverable, string slot )
    {
        return hoverable switch
        {
            true => ElementClass.Empty()
                .Add( "cursor-default", when: slot is nameof( _tr ) )
                .Add( ElementClass.Empty()
                    .Add( "group-aria-[selected=false]:group-data-[disabled=false]:group-hover:bg-default-100/70" )
                    .Add( "first:rounded-s-lg last:rounded-e-lg" ), when: slot is nameof( _td ) ),

            _ => ElementClass.Empty()
        };
    }

    private static ElementClass GetSelectionModeStyles( SelectionMode selectionMode, string slot )
    {
        return selectionMode switch
        {
            SelectionMode.Single or SelectionMode.None => ElementClass.Empty()
                .Add( "first:rounded-s-lg last:rounded-e-lg" , when: slot is nameof( _td ) ),

            SelectionMode.Multiple => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "group-first:first:rounded-tl-lg" )
                    .Add( "group-first:last:rounded-tr-lg" )
                    .Add( "first:rounded-none" )
                    .Add( "last:rounded-none" )
                    .Add( "group-last:first:rounded-bl-lg" )
                    .Add( "group-last:last:rounded-br-lg" ), when: slot is nameof( _td ) ),

            _ => ElementClass.Empty()
        };
    }

    private static ElementClass GetColorStyles( ThemeColor color, string slot )
    {
        return color switch
        {
            ThemeColor.Default => ElementClass.Empty()
                .Add( "data-[selected=true]:bg-default/60 data-[selected=true]:text-default-foreground", when: slot is nameof( _td ) ),

            ThemeColor.Primary => ElementClass.Empty()
                .Add( "data-[selected=true]:bg-primary/20 data-[selected=true]:text-primary-600", when: slot is nameof( _td ) ),

            ThemeColor.Secondary => ElementClass.Empty()
                .Add( "data-[selected=true]:bg-secondary/20 data-[selected=true]:text-secondary-600", when: slot is nameof( _td ) ),

            ThemeColor.Success => ElementClass.Empty()
                .Add( "data-[selected=true]:bg-success/20 data-[selected=true]:text-success-800 dark:data-[selected=true]:text-success-600", when: slot is nameof( _td ) ),

            ThemeColor.Warning => ElementClass.Empty()
                .Add( "data-[selected=true]:bg-warning/20 data-[selected=true]:text-warning-800 dark:data-[selected=true]:text-warning-700", when: slot is nameof( _td ) ),

            ThemeColor.Danger => ElementClass.Empty()
                .Add( "data-[selected=true]:bg-danger/20 data-[selected=true]:text-danger-600", when: slot is nameof( _td ) ),

            ThemeColor.Info => ElementClass.Empty()
                .Add( "data-[selected=true]:bg-info/20 data-[selected=true]:text-info-600", when: slot is nameof( _td ) ),

            _ => ElementClass.Empty()
        };
    }

    private static ElementClass GetStripedColorStyles( ThemeColor color, string slot )
    {
        return color switch
        {
            ThemeColor.Default => ElementClass.Empty()
                .Add( "group-even:data-[selected=true]:bg-default-100", when: slot is nameof( _td ) ),

            ThemeColor.Primary => ElementClass.Empty()
                .Add( "group-even:data-[selected=true]:bg-primary-100", when: slot is nameof( _td ) ),

            ThemeColor.Secondary => ElementClass.Empty()
                .Add( "group-even:data-[selected=true]:bg-secondary-100", when: slot is nameof( _td ) ),

            ThemeColor.Success => ElementClass.Empty()
                .Add( "group-even:data-[selected=true]:bg-success-100", when: slot is nameof( _td ) ),

            ThemeColor.Warning => ElementClass.Empty()
                .Add( "group-even:data-[selected=true]:bg-warning-100", when: slot is nameof( _td ) ),

            ThemeColor.Danger => ElementClass.Empty()
                .Add( "group-even:data-[selected=true]:bg-danger-100", when: slot is nameof( _td ) ),

            ThemeColor.Info => ElementClass.Empty()
                .Add( "group-even:data-[selected=true]:bg-info-100", when: slot is nameof( _td ) ),

            _ => ElementClass.Empty()
        };
    }

    private static ElementClass GetRadiusStyles( Radius radius, string slot )
    {
        return radius switch
        {
            Radius.None => ElementClass.Empty()
                .Add( "rounded-none", when: slot is nameof( _wrapper ) ),

            Radius.Small => ElementClass.Empty()
                .Add( "rounded-small", when: slot is nameof( _wrapper ) ),

            Radius.Medium => ElementClass.Empty()
                .Add( "rounded-medium", when: slot is nameof( _wrapper ) ),

            Radius.Large => ElementClass.Empty()
                .Add( "rounded-large", when: slot is nameof( _wrapper ) ),

            _ => ElementClass.Empty()
        };
    }

    private static ElementClass GetShadowStyles( Shadow shadow, string slot )
    {
        return shadow switch
        {
            Shadow.None => ElementClass.Empty()
                .Add( "shadow-none", when: slot is nameof( _wrapper ) ),

            Shadow.Small => ElementClass.Empty()
                .Add( "shadow-small", when: slot is nameof( _wrapper ) ),

            Shadow.Medium => ElementClass.Empty()
                .Add( "shadow-medium", when: slot is nameof( _wrapper ) ),

            Shadow.Large => ElementClass.Empty()
                .Add( "shadow-large", when: slot is nameof( _wrapper ) ),

            _ => ElementClass.Empty()
        };
    }

    private static ElementClass GetLayoutStyles( Layout layout, string slot )
    {
        return layout switch
        {
            Layout.Auto => ElementClass.Empty()
                .Add( "table-auto", when: slot is nameof( _table ) ),

            Layout.Fixed => ElementClass.Empty()
                .Add( "table-fixed", when: slot is nameof( _table ) ),

            _ => ElementClass.Empty()
        };
    }
}
