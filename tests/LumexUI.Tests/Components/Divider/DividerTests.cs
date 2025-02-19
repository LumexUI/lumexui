// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Variants;

using Microsoft.Extensions.DependencyInjection;

using TailwindMerge;

namespace LumexUI.Tests.Components;

public class DividerTests : TestContext
{
    public DividerTests()
    {
        Services.AddSingleton<TwMerge>();
		Services.AddSingleton<TwVariant>();
	}

    [Fact]
    public void Divider_ShouldRenderCorrectly()
    {
        var action = () => RenderComponent<LumexDivider>();

        action.Should().NotThrow();
    }

    [Fact]
    public void Divider_Horizontal_ShouldRenderAsHr()
    {
        var cut = RenderComponent<LumexDivider>( p => p
            .Add( p => p.Orientation, Orientation.Horizontal )
        );

        cut.Markup.Should().StartWith( "<hr" );
    }

    [Fact]
    public void Divider_Vertical_ShouldRenderAsDiv()
    {
        var cut = RenderComponent<LumexDivider>( p => p
            .Add( p => p.Orientation, Orientation.Vertical )
        );

        cut.Markup.Should().StartWith( "<div" );
    }
}