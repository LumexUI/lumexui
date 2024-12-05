using System.Diagnostics.CodeAnalysis;

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
        return new ListboxItemSlots()
        {
            Root = twMerge.Merge(
                ElementClass.Empty()
                    .Add( _base )
                    .Add( listboxItem.Class )
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
}
