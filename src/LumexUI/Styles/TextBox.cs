// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

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
        .Add( "text-small" )
        .Add( "text-foreground-500" )
        .Add( "origin-top-left" )
        .Add( "pointer-events-none" )
        .Add( "subpixel-antialiased" )
        .ToString();

    private readonly static string _inputWrapper = ElementClass.Empty()
        .Add( "relative" )
        .Add( "px-3" )
        .Add( "inline-flex" )
        .Add( "items-center" )
        .Add( "gap-3" )
        .Add( "w-full" )
        .Add( "shadow-sm" )
        .ToString();

    public static string GetStyles( LumexTextBox textBox )
    {
        return ElementClass.Empty()
            .Add( _base )
            .Add( textBox.Class )
            .ToString();
    }

    public static string GetLabelStyles()
    {
        return ElementClass.Empty()
            .Add( _label )
            .ToString();
    }

    public static string GetInputWrapperStyles()
    {
        return ElementClass.Empty()
            .Add( _inputWrapper )
            .ToString();
    }
}
