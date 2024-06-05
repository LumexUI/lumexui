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
    private readonly static string _base = ElementClass.Empty()
        .Add( "inline-flex" )
        .Add( "items-center" )
        .Add( "justify-center" )
        .Add( "appearance-none" )
        .Add( "outline-none" )
        .Add( "select-none" )
        .Add( "whitespace-nowrap" )
        .Add( "min-w-max" )
        .Add( "subpixel-antialiased" )
        .Add( "overflow-hidden" )
        .Add( "active:scale-[0.98]" )
        .Add( "transition-transform-colors-opacity" )
        .Add( "motion-reduce:transition-none" )
        .ToString();

    private readonly static string _disabled = ElementClass.Empty()
        .Add( "opacity-disabled" )
        .Add( "pointer-events-none" )
        .ToString();

    private readonly static string _fullWidth = ElementClass.Empty()
        .Add( "w-full" )
        .ToString();

    private static ElementClass GetSizeStyles( Size size )
    {
        return ElementClass.Empty()
            .Add( "min-w-16 h-8 px-3 gap-2 text-small rounded-small", when: size is Size.Small )
            .Add( "min-w-20 h-10 px-4 gap-2 text-medium rounded-medium", when: size is Size.Medium )
            .Add( "min-w-24 h-12 px-6 gap-2 text-large rounded-large", when: size is Size.Large );
    }

    private static ElementClass GetVariantStyles( Variant variant, ThemeColor color )
    {
        return ElementClass.Empty()
            .Add( ColorVariants.Solid[color], when: variant is Variant.Solid )
            .Add( ColorVariants.Outlined[color], when: variant is Variant.Outlined )
            .Add( ColorVariants.Flat[color], when: variant is Variant.Flat )
            .Add( ColorVariants.Shadow[color], when: variant is Variant.Shadow )
            .Add( ColorVariants.Ghost[color], when: variant is Variant.Ghost )
            .Add( ColorVariants.Light[color], when: variant is Variant.Light );
    }

    private static ElementClass GetHoverStyles( Variant variant, ThemeColor color )
    {
        var styles = ElementClass.Empty();

        if( variant is Variant.Light )
        {
            styles
                .Add( "hover:bg-default-50", when: color is ThemeColor.Default )
                .Add( "hover:bg-primary-50", when: color is ThemeColor.Primary )
                .Add( "hover:bg-secondary-50", when: color is ThemeColor.Secondary )
                .Add( "hover:bg-sucess-50", when: color is ThemeColor.Success )
                .Add( "hover:bg-warning-50", when: color is ThemeColor.Warning )
                .Add( "hover:bg-danger-50", when: color is ThemeColor.Danger )
                .Add( "hover:bg-info-50", when: color is ThemeColor.Info );
        }
        else
        {
            styles.Add( "hover:opacity-hover" );
        }

        return styles;
    }

    public static string GetStyles( LumexButton button )
    {
        return ElementClass.Empty()
            .Add( _base )
            .Add( _disabled, when: button.Disabled )
            .Add( _fullWidth, when: button.FullWidth )
            .Add( GetSizeStyles( button.Size ) )
            .Add( GetVariantStyles( button.Variant, button.Color ) )
            .Add( GetHoverStyles( button.Variant, button.Color ) )
            .Add( button.Class )
            .ToString();
    }
}
