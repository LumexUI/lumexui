// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Linq;

using Microsoft.Extensions.DependencyInjection;

using TailwindMerge;

namespace LumexUI.Tests.Components;

public class CardTests : TestContext
{
    public CardTests()
    {
        Services.AddSingleton<TwMerge>();
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
        );

        action.Should().NotThrow();
    }

    [Fact]
    public void CardBody_ShouldRenderCorrectly()
    {
        var action = () => RenderComponent<LumexCard>( p => p
            .AddChildContent<LumexCardBody>()
        );

        action.Should().NotThrow();
    }

    [Fact]
    public void CardFooter_ShouldRenderCorrectly()
    {
        var action = () => RenderComponent<LumexCard>( p => p
            .AddChildContent<LumexCardFooter>()
        );

        action.Should().NotThrow();
    }

    [Fact]
    public void CardHeader_StandaloneUsage_ShouldThrowInvalidOperation()
    {
        var action = () => RenderComponent<LumexCardHeader>();

        action.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void CardBody_StandaloneUsage_ShouldThrowInvalidOperation()
    {
        var action = () => RenderComponent<LumexCardBody>();

        action.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void CardFooter_StandaloneUsage_ShouldThrowInvalidOperation()
    {
        var action = () => RenderComponent<LumexCardFooter>();

        action.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void Card_WithSlots_ShouldRenderCorrectCss()
    {
        var slots = new CardSlots()
        {
            Root = "custom-class",
            Header = "custom-class",
            Body = "custom-class",
            Footer = "custom-class"
        };

        var cut = RenderComponent<LumexCard>( p => p
            .Add( p => p.Classes, slots )
            .AddChildContent<LumexCardHeader>()
            .AddChildContent<LumexCardBody>()
            .AddChildContent<LumexCardFooter>()
        );

        cut.Find( "[data-slot=root]" ).ClassName.Should().Contain( slots.Root );
        cut.Find( "[data-slot=header]" ).ClassName.Should().Contain( slots.Header );
        cut.Find( "[data-slot=body]" ).ClassName.Should().Contain( slots.Body );
        cut.Find( "[data-slot=footer]" ).ClassName.Should().Contain( slots.Footer );
    }
}