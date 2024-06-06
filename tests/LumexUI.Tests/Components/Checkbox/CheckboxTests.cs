// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using Microsoft.Extensions.DependencyInjection;

using TailwindMerge;

namespace LumexUI.Tests.Components;

public class CheckboxTests : TestContext
{
    public CheckboxTests()
    {
        Services.AddSingleton<TwMerge>();
    }

    [Fact]
    public void Checkbox_ShouldRenderCorrectly()
    {
        var action = () => RenderComponent<LumexCheckbox>( p => p
            .Add( p => p.ValueExpression, () => true )
        );

        action.Should().NotThrow();
    }

    [Fact]
    public void Checkbox_WithChildContent_ShouldRenderCorrectly()
    {
        var cut = RenderComponent<LumexCheckbox>( p => p
            .Add( p => p.ValueExpression, () => false )
            .AddChildContent( "checkbox" )
        );

        cut.Markup.Should().Contain( "checkbox" );
    }

    [Fact]
    public void Checkbox_WithCheckIcon_ShouldRenderCustomIcon()
    {
        var cut = RenderComponent<LumexCheckbox>( p => p
            .Add( p => p.ValueExpression, () => true )
            .Add( p => p.CheckIcon, Icons.Rounded.Headphones )
        );

        cut.FindComponent<LumexIcon>().Should().NotBeNull();
    }

    [Fact]
    public void Checkbox_OnChange_ShouldChangeValue()
    {
        var cut = RenderComponent<LumexCheckbox>( p => p
            .Add( p => p.ValueExpression, () => false )
        );

        cut.Instance.Value.Should().BeFalse();

        var checkbox = cut.Find( "input" );
        checkbox.Change( true );

        cut.Instance.Value.Should().BeTrue();
    }

    [Theory]
    [InlineData( true, false )]
    [InlineData( false, true )]
    public void Checkbox_DisabledOrReadOnly_ShouldNotTriggerChange( bool disabled, bool readOnly )
    {
        var cut = RenderComponent<LumexCheckbox>( p => p
            .Add( p => p.ValueExpression, () => false )
            .Add( p => p.Disabled, disabled )
            .Add( p => p.ReadOnly, readOnly )
        );

        cut.Instance.Value.Should().BeFalse();

        var checkbox = cut.Find( "input" );
        checkbox.Change( true );

        cut.Instance.Value.Should().BeFalse();
    }

    [Fact]
    public async Task Checkbox_SetCurrentValueAsString_ShouldThrowNotSupported()
    {
        var cut = RenderComponent<LumexCheckbox>( p => p
            .Add( p => p.ValueExpression, () => false )
        );

        var action = async () => await cut.Instance.SetCurrentValueAsStringAsync( "true" );

        await action.Should().ThrowAsync<NotSupportedException>();
    }
}