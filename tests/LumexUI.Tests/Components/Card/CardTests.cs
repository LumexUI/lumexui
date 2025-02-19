// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Variants;

using Microsoft.Extensions.DependencyInjection;

using TailwindMerge;

namespace LumexUI.Tests.Components;

public class CardTests : TestContext
{
    public CardTests()
    {
        Services.AddSingleton<TwMerge>();
		Services.AddSingleton<TwVariant>();
	}

    [Fact]
    public void Card_ShouldRenderCorrectly()
    {
        var action = () => RenderComponent<LumexCard>();

        action.Should().NotThrow();
    }

    [Fact]
    public void CardHeader_ShouldRenderCorrectly()
    {
        var action = () => RenderComponent<LumexCard>( p => p
            .AddChildContent<LumexCardHeader>()
            .AddChildContent<LumexCardBody>()
            .AddChildContent<LumexCardFooter>()
        );

        action.Should().NotThrow();
    }

    [Fact]
    public void CardHeader_StandaloneUsage_ShouldThrowInvalidOperation()
    {
        var action = () => RenderComponent<LumexCardHeader>();

        action.Should().Throw<ContextNullException>();
    }

    [Fact]
    public void CardBody_StandaloneUsage_ShouldThrowInvalidOperation()
    {
        var action = () => RenderComponent<LumexCardBody>();

        action.Should().Throw<ContextNullException>();
    }

    [Fact]
    public void CardFooter_StandaloneUsage_ShouldThrowInvalidOperation()
    {
        var action = () => RenderComponent<LumexCardFooter>();

        action.Should().Throw<ContextNullException>();
    }
}