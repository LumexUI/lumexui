// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Utilities;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal static class Popover
{
    private readonly static string _base = ElementClass.Empty()
        .ToString();

    private readonly static string _innerWrapper = ElementClass.Empty()
        .Add( "animate-popover-bottom" )
        .ToString();

    private readonly static string _content = ElementClass.Empty()
        .Add( "z-10" )
        .Add( "py-1" )
        .Add( "px-2.5" )
        .Add( "w-full" )
        .Add( "inline-flex" )
        .Add( "flex-col" )
        .Add( "items-center" )
        .Add( "justify-center" )
        .ToString();

    public static string GetStyles( LumexPopover popover )
    {
        return ElementClass.Empty()
            .Add( _base )
            .Add( popover.Class )
            .ToString();
    }

    public static string GetInnerWrapperStyles()
    {
        return ElementClass.Empty()
            .Add( _innerWrapper )
            .ToString();
    }

    public static string GetContentStyles( LumexPopoverContent popoverContent )
    {
        return ElementClass.Empty()
            .Add( _content )
            .Add( "text-small" )
            .Add( "rounded-large" )
            .Add( "bg-default-50" )
            .Add( "shadow-small" )
            .Add( popoverContent.Class )
            .ToString();
    }
}
