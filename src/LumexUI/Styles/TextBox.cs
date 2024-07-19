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

    public static string GetStyles( LumexTextBox textBox )
    {
        return ElementClass.Empty()
            .Add( _base )
            .Add( textBox.Class )
            .ToString();
    }
}
