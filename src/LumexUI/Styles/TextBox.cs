// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal readonly record struct TextBox
{
    private readonly static string _base = ElementClass.Empty()
        .Add( "group" )
        .Add( "flex" )
        .Add( "flex-col" )
        .ToString();

    private readonly static string _label = ElementClass.Empty()
        .Add( "absolute" )
        .Add( "z-10" )
        .Add( "block" )
        .Add( "text-foreground-500" )
        .Add( "origin-top-left" )
        .Add( "pointer-events-none" )
        .Add( "subpixel-antialiased" )
        .ToString();

    private readonly static string _inputWrapper = ElementClass.Empty()
        .Add( "relative" )
        .Add( "inline-flex" )
        .Add( "items-center" )
        .Add( "px-3" )
        .Add( "gap-3" )
        .Add( "w-full" )
        .Add( "shadow-sm" )
        .ToString();

    private readonly static string _innerWrapper = ElementClass.Empty()
        .Add( "inline-flex" )
        .Add( "items-center" )
        .Add( "w-full" )
        .Add( "h-full" )
        .ToString();

    private readonly static string _input = ElementClass.Empty()
        .Add( "w-full" )
        .Add( "font-normal" )
        .Add( "bg-transparent" )
        .Add( "outline-none" )
        // placeholder
        .Add( "placeholder:text-foreground-500" )
        // autofill
        .Add( "autofill:bg-transparent" )
        .ToString();

    private readonly static string _disabled = ElementClass.Empty()
        .Add( "opacity-disabled" )
        .Add( "pointer-events-none" )
        .ToString();

    private static ElementClass GetSizeStyles( Size size, string slot )
    {
        if( slot is "inputWrapper" )
        {
            return ElementClass.Empty()
                .Add( "h-8 min-h-8 rounded-small", when: size is Size.Small )
                .Add( "h-10 min-h-10 rounded-medium", when: size is Size.Medium )
                .Add( "h-12 min-h-12 rounded-large", when: size is Size.Large );
        }
        else if( slot is "input" )
        {
            return ElementClass.Empty()
                .Add( "text-small", when: size is Size.Small or Size.Medium )
                .Add( "text-medium", when: size is Size.Large );
        }
        else if( slot is "label" )
        {
            return ElementClass.Empty()
                .Add( "text-tiny", when: size is Size.Small )
                .Add( "text-small", when: size is Size.Medium or Size.Large );
        }

        return ElementClass.Empty();
    }

    private static ElementClass GetRadiusStyles( Radius? radius )
    {
        if( radius is null )
        {
            return ElementClass.Empty();
        }

        return ElementClass.Empty()
            .Add( "rounded-none", when: radius is Radius.None )
            .Add( "rounded-small", when: radius is Radius.Small )
            .Add( "rounded-medium", when: radius is Radius.Medium )
            .Add( "rounded-large", when: radius is Radius.Large );
    }

    public static string GetStyles( LumexTextBox textBox )
    {
        return ElementClass.Empty()
            .Add( _base )
            .Add( _disabled, when: textBox.Disabled )
            .Add( textBox.Class )
            .ToString();
    }

    public static string GetLabelStyles( LumexTextBox textBox )
    {
        return ElementClass.Empty()
            .Add( _label )
            .Add( GetSizeStyles( textBox.Size, slot: "label" ) )
            .ToString();
    }

    public static string GetInputWrapperStyles( LumexTextBox textBox )
    {
        return ElementClass.Empty()
            .Add( _inputWrapper )
            .Add( GetRadiusStyles( textBox.Radius ) )
            .Add( GetSizeStyles( textBox.Size, slot: "inputWrapper" ) )
            .ToString();
    }

    public static string GetInnerWrapperStyles()
    {
        return ElementClass.Empty()
            .Add( _innerWrapper )
            .ToString();
    }

    public static string GetInputStyles( LumexTextBox textBox )
    {
        return ElementClass.Empty()
            .Add( _input )
            .Add( GetSizeStyles( textBox.Size, slot: "input" ) )
            .ToString();
    }
}
