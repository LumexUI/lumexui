// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Utilities;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal static class Select
{
    private readonly static string _base = ElementClass.Empty()
        .Add( "group" )
        .Add( "relative" )
        .Add( "inline-flex" )
        .Add( "flex-col" )
        .Add( "w-full" )
        .ToString();

    //private readonly static string _label = ElementClass.Empty()
    //    .Add( "absolute" )
    //    .Add( "z-10" )
    //    .Add( "block" )
    //    .Add( "text-small" )
    //    .Add( "text-foreground-500" )
    //    .Add( "origin-top-left" )
    //    .Add( "rtl:origin-top-right" )
    //    .Add( "pointer-events-none" )
    //    .Add( "subpixel-antialiased" )
    //    //.Add( "pe-2" )
    //    //.Add( "max-w-full" )
    //    //.Add( "text-ellipsis" )
    //    //.Add( "overflow-hidden" )
    //    //.Add( "group-data-[filled-focused=true]:pointer-events-auto" )
    //    // transition
    //    //.Add( "will-change-auto" )
    //    //.Add( "transition-[transform,color,left,opacity]" )
    //    //.Add( "motion-reduce:transition-none" )
    //    .ToString();

    private readonly static string _mainWrapper = ElementClass.Empty()
        .Add( "flex" )
        .Add( "flex-col" )
        .Add( "w-full" )
        .ToString();

    private readonly static string _trigger = ElementClass.Empty()
        .Add( "relative" )
        .Add( "px-3" )
        .Add( "gap-3" )
        .Add( "w-full" )
        .Add( "inline-flex" )
        .Add( "items-center" )
        .Add( "outline-none" )
        .Add( "shadow-sm" )
        .ToString();

    private readonly static string _popoverContent = ElementClass.Empty()
        .Add( "w-full" )
        .Add( "p-1" )
        .Add( "overflow-hidden" )
        .ToString();

    public static string GetStyles<TValue>( LumexSelect<TValue> select )
    {
        return ElementClass.Empty()
            .Add( _base )
            .Add( select.Class )
            .ToString();
    }

    public static string GetMainWrapperStyles<TValue>( LumexSelect<TValue> select )
    {
        return ElementClass.Empty()
            .Add( _mainWrapper )
            .ToString();
    }

    public static string GetTriggerStyles<TValue>( LumexSelect<TValue> select )
    {
        return ElementClass.Empty()
            .Add( _trigger )
            .ToString();
    }

    public static string GetPopoverContentStyles<TValue>( LumexSelect<TValue> select )
    {
        return ElementClass.Empty()
            .Add( _popoverContent )
            .ToString();
    }
}

[ExcludeFromCodeCoverage]
internal static class SelectItem
{
    private readonly static string _base = ElementClass.Empty()
        .Add( "group" )
        .ToString();

    public static string GetStyles<TValue>( LumexSelectItem<TValue> selectItem )
    {
        return ElementClass.Empty()
            .Add( _base )
            .Add( selectItem.Class )
            .ToString();
    }
}
