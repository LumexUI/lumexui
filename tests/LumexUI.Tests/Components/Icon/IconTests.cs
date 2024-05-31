// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using Microsoft.Extensions.DependencyInjection;

using TailwindMerge;

namespace LumexUI.Tests.Components;

public class IconTests : TestContext
{
    public IconTests()
    {
        Services.AddSingleton<TwMerge>();
    }

    [Fact]
    public void Icon_ShouldRenderCorrectly()
    {
        var action = () => RenderComponent<LumexIcon>();

        action.Should().NotThrow();
    }

    [Fact]
    public void Icon_IconPath_ShouldRenderSvgIcon()
    {
        var cut = RenderComponent<LumexIcon>( p => p
            .Add( p => p.Icon, Icons.Rounded.Sunny )
        );

        var svg = cut.Find( "svg" );

        svg.Should().NotBeNull();
    }
}