// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal readonly record struct Button
{
    private static string _base = CssBuilder.Empty()
        .AddClass( "inline-flex" )
        .AddClass( "items-center" )
        .AddClass( "justify-center" )
        .AddClass( "appearance-none" )
        .AddClass( "outline-none" )
        .AddClass( "select-none" )
        .AddClass( "whitespace-nowrap" )
        .AddClass( "min-w-max" )
        .AddClass( "subpixel-antialiased" )
        .AddClass( "overflow-hidden" )
        .AddClass( "bg-blue-400" )
        .AddClass( "text-white" )
        .AddClass( "hover:opacity-80" )
        .Build();

    private static string _disabled = CssBuilder.Empty()
        .AddClass( "opacity-disabled" )
        .AddClass( "pointer-events-none" )
        .Build();

    private static string _fullWidth = CssBuilder.Empty()
        .AddClass( "w-full" )
        .Build();

    private static string GetSizeStyles( Size size ) => size switch
    {
        Size.Small => "min-w-16 h-8 px-3 gap-2 text-sm rounded-lg",
        Size.Medium => "min-w-20 h-10 px-4 gap-2 text-base rounded-xl",
        Size.Large => "min-w-24 h-12 px-6 gap-2 text-lg rounded-xl",
        _ => throw new NotImplementedException()
    };

    private static string GetVariantStyles( Variant variant, ThemeColor color ) => variant switch
    {
        Variant.Solid => ColorVariants.Solid[color],
        Variant.Outlined => ColorVariants.Outlined[color],
        Variant.Flat => ColorVariants.Flat[color],
        Variant.Shadow => ColorVariants.Shadow[color],
        Variant.Ghost => ColorVariants.Ghost[color],
        Variant.Light => ColorVariants.Light[color],
        _ => throw new NotImplementedException()
    };

    public static string GetStyles( LumexButton button )
    {
        var styles = new CssBuilder()
            .AddClass( _base )
            .AddClass( _disabled, when: button.Disabled )
            .AddClass( _fullWidth, when: button.FullWidth )
            .AddClass( GetSizeStyles( button.Size ) )
            .AddClass( GetVariantStyles( button.Variant, button.Color ) )
            .AddClass( button.Class )
            .Build();

        return styles;
    }
}
