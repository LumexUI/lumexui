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
        return ElementClass.Empty()
            .Add( "data-[state=collapsed]:hidden", when: state is CollapseState.Collapsed )
            .Add( "data-[state=collapsing]:h-0 overflow-hidden transition-[height]", when: state is CollapseState.Collapsing )
            .Add( "data-[state=expanding]:h-0 overflow-hidden transition-[height]", when: state is CollapseState.Expanding );
    }

    public static string GetStyles( LumexCollapse collapse )
    {
        return ElementClass.Empty()
            .Add( GetStateStyles( collapse.State ) )
            .Add( collapse.Class )
            .ToString();
    }
}
