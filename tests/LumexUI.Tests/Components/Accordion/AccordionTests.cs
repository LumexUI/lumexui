// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Variants;

using Microsoft.Extensions.DependencyInjection;

using TailwindMerge;

namespace LumexUI.Tests.Components;

public class AccordionTests : TestContext
{
    public AccordionTests()
    {
        Services.AddSingleton<TwMerge>();
		Services.AddSingleton<TwVariant>();
		JSInterop.Setup<int>( "Lumex.elementReference.getScrollHeight", _ => true );
    }

    [Fact]
    public void Accordion_ShouldRenderCorrectly()
    {
        var action = () => RenderComponent<LumexAccordion>( p => p
            .AddChildContent<LumexAccordionItem>( p => p
                .Add( p => p.Id, "1" )
            )
        );

        action.Should().NotThrow();
    }

    [Fact]
    public void Accordion_ShouldDisplayCorrectAmountOfItems()
    {
        var cut = RenderComponent<LumexAccordion>( p => p
            .AddChildContent<LumexAccordionItem>( p => p
                .Add( p => p.Id, "1" )
            )
            .AddChildContent<LumexAccordionItem>( p => p
                .Add( p => p.Id, "2" )
            )
        );

        cut.FindAll( "button" ).Should().HaveCount( 2 );
    }

    [Fact]
    public void Accordion_ExpandedItems_ShouldBeOpened()
    {
        var cut = RenderComponent<LumexAccordion>( p => p
            .Add( p => p.ExpandedItems, ["1"] )
            .Add( p => p.SelectionMode, SelectionMode.Multiple )
            .AddChildContent<LumexAccordionItem>( p => p
                .Add( p => p.Id, "1" )
            )
            .AddChildContent<LumexAccordionItem>( p => p
                .Add( p => p.Id, "2" )
            )
        );

        var items = cut.FindComponents<LumexAccordionItem>();

        items[0].Instance.GetExpandedState().Should().BeTrue();
        items[1].Instance.GetExpandedState().Should().BeFalse();
    }

    [Fact]
    public void Accordion_DisabledItems_ShouldBeDisabled()
    {
        var cut = RenderComponent<LumexAccordion>( p => p
            .Add( p => p.DisabledItems, ["1"] )
            .AddChildContent<LumexAccordionItem>( p => p
                .Add( p => p.Id, "1" )
            )
            .AddChildContent<LumexAccordionItem>( p => p
                .Add( p => p.Id, "2" )
            )
        );

        var items = cut.FindComponents<LumexAccordionItem>();

        items[0].Instance.GetDisabledState().Should().BeTrue();
        items[1].Instance.GetDisabledState().Should().BeFalse();
    }

    [Fact]
    public void Accordion_OnAccordionItemClick_ShouldExpand()
    {
        var cut = RenderComponent<LumexAccordion>( p => p
            .AddChildContent<LumexAccordionItem>( p => p
                .Add( p => p.Id, "1" )
            )
            .AddChildContent<LumexAccordionItem>( p => p
                .Add( p => p.Id, "2" )
            )
        );

        var item = cut.FindComponent<LumexAccordionItem>();
        var wrapper = item.Find( "div" );

        wrapper.GetAttribute( "data-opened" ).Should().BeNull();

        item.Find( "button" ).Click();

        wrapper.GetAttribute( "data-opened" ).Should().NotBeNull();
    }

    [Fact]
    public void Accordion_OnDisabledAccordionItemClick_ShouldNotExpand()
    {
        var cut = RenderComponent<LumexAccordion>( p => p
            .AddChildContent<LumexAccordionItem>( p => p
                .Add( p => p.Id, "1" )
                .Add( p => p.Disabled, true )
            )
        );

        var item = cut.FindComponent<LumexAccordionItem>();
        var wrapper = item.Find( "div" );

        item.Find( "button" ).Click();

        wrapper.GetAttribute( "data-opened" ).Should().BeNull();
    }

    [Fact]
    public void Accordion_SelectionModeNone_ShouldNotExpand()
    {
        var cut = RenderComponent<LumexAccordion>( p => p
            .Add( p => p.SelectionMode, SelectionMode.None )
            .AddChildContent<LumexAccordionItem>( p => p
                .Add( p => p.Id, "1" )
            )
        );

        var item = cut.FindComponent<LumexAccordionItem>();
        var wrapper = item.Find( "div" );

        item.Find( "button" ).Click();

        wrapper.GetAttribute( "data-opened" ).Should().BeNull();
    }

    [Fact]
    public void Accordion_SelectionModeMultiple_ShouldExpandMoreThanOne()
    {
        var cut = RenderComponent<LumexAccordion>( p => p
            .Add( p => p.SelectionMode, SelectionMode.Multiple )
            .AddChildContent<LumexAccordionItem>( p => p
                .Add( p => p.Id, "1" )
            )
            .AddChildContent<LumexAccordionItem>( p => p
                .Add( p => p.Id, "2" )
            )
        );

        var items = cut.FindComponents<LumexAccordionItem>();
        var wrapper1 = items[0].Find( "div" );
        var wrapper2 = items[1].Find( "div" );

        items[0].Find( "button" ).Click();
        items[1].Find( "button" ).Click();

        wrapper1.GetAttribute( "data-opened" ).Should().NotBeNull();
        wrapper2.GetAttribute( "data-opened" ).Should().NotBeNull();
    }

    [Fact]
    public void Accordion_ExpandAsync_ShouldExpand()
    {
        var cut = RenderComponent<LumexAccordion>( p => p
            .AddChildContent<LumexAccordionItem>( p => p
                .Add( p => p.Id, "1" )
            )
        );

        var item = cut.FindComponent<LumexAccordionItem>();
        cut.InvokeAsync( item.Instance.ExpandAsync );

        item.Instance.GetExpandedState().Should().BeTrue();
    }

    [Fact]
    public void Accordion_CollapseAsync_ShouldCollapse()
    {
        var cut = RenderComponent<LumexAccordion>( p => p
            .AddChildContent<LumexAccordionItem>( p => p
                .Add( p => p.Id, "1" )
            )
        );

        var item = cut.FindComponent<LumexAccordionItem>();
        cut.InvokeAsync( item.Instance.CollapseAsync );

        item.Instance.GetExpandedState().Should().BeFalse();
    }

    [Fact]
    public void Accordion_StartContent_ShouldRenderStartContent()
    {
        var startContent = "start-content";

        var cut = RenderComponent<LumexAccordion>( p => p
            .AddChildContent<LumexAccordionItem>( p => p
                .Add( p => p.Id, "1" )
                .Add( p => p.StartContent, startContent )
            )
        );

        cut.Markup.Should().Contain( startContent );
    }

    [Fact]
    public void Accordion_Title_ShouldRenderTitle()
    {
        var title = "title";

        var cut = RenderComponent<LumexAccordion>( p => p
            .AddChildContent<LumexAccordionItem>( p => p
                .Add( p => p.Id, "1" )
                .Add( p => p.Title, title )
            )
        );

        cut.Markup.Should().Contain( title );
    }

    [Fact]
    public void Accordion_TitleContent_ShouldRenderTitleContent()
    {
        var titleContent = "title-content";

        var cut = RenderComponent<LumexAccordion>( p => p
            .AddChildContent<LumexAccordionItem>( p => p
                .Add( p => p.Id, "1" )
                .Add( p => p.TitleContent, titleContent )
            )
        );

        cut.Markup.Should().Contain( titleContent );
    }

    [Fact]
    public void Accordion_Subtitle_ShouldRenderSubtitle()
    {
        var subtitle = "subtitle";

        var cut = RenderComponent<LumexAccordion>( p => p
            .AddChildContent<LumexAccordionItem>( p => p
                .Add( p => p.Id, "1" )
                .Add( p => p.Subtitle, subtitle )
            )
        );

        cut.Markup.Should().Contain( subtitle );
    }

    [Fact]
    public void Accordion_SubtitleContent_ShouldRenderSubtitleContent()
    {
        var subtitleContent = "subtitle";

        var cut = RenderComponent<LumexAccordion>( p => p
            .AddChildContent<LumexAccordionItem>( p => p
                .Add( p => p.Id, "1" )
                .Add( p => p.SubtitleContent, subtitleContent )
            )
        );

        cut.Markup.Should().Contain( subtitleContent );
    }

    [Fact]
    public void Accordion_MissingAccordionItemId_ShouldThrowInvalidOperation()
    {
        var action = () => RenderComponent<LumexAccordion>( p => p
            .AddChildContent<LumexAccordionItem>()
        );

        action.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void Accordion_TitleAndTitleContent_ShouldThrowInvalidOperation()
    {
        var action = () => RenderComponent<LumexAccordion>( p => p
            .AddChildContent<LumexAccordionItem>( p => p
                .Add( p => p.Id, "1" )
                .Add( p => p.Title, "title" )
                .Add( p => p.TitleContent, "title-content" )
            )
        );

        action.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void Accordion_SubtitleAndSubtitleContent_ShouldThrowInvalidOperation()
    {
        var action = () => RenderComponent<LumexAccordion>( p => p
            .AddChildContent<LumexAccordionItem>( p => p
                .Add( p => p.Id, "1" )
                .Add( p => p.Subtitle, "subtitle" )
                .Add( p => p.SubtitleContent, "subtitle-content" )
            )
        );

        action.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void AccordionItem_StandaloneUsage_ShouldThrowInvalidOperation()
    {
        var action = () => RenderComponent<LumexAccordionItem>( p => p
            .Add( p => p.Id, "1" )
        );

        action.Should().Throw<ContextNullException>();
    }
}