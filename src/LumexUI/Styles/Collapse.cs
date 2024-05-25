// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Utilities;

using static LumexUI.LumexCollapse;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal readonly record struct Collapse
{
    private static ElementClass GetStateStyles( CollapseState state )
    {
        var transitioning = state is CollapseState.Expanding or CollapseState.Collapsing;

        return ElementClass.Empty()
            .Add( "hidden", when: state is CollapseState.Collapsed )
            .Add( "h-0 overflow-hidden transition-[height]", when: transitioning );
    }

    public static string GetStyles( LumexCollapse collapse )
    {
        return ElementClass.Empty()
            .Add( GetStateStyles( collapse.State ) )
            .Add( collapse.Class )
            .ToString();
    }
}
