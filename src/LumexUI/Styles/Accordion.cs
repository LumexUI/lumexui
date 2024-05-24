// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Utilities;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal readonly record struct Accordion
{
    private readonly static string _fullWidth = ElementClass.Empty()
        .Add( "w-full" )
        .ToString();

    public static string GetStyles( LumexAccordion accordion )
    {
        return ElementClass.Empty()
            .Add( _fullWidth, when: accordion.FullWidth )
            .Add( accordion.Classes?.Root )
            .Add( accordion.Class )
            .ToString();
    }
}
