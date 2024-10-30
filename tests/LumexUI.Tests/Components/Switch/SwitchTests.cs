// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;

using Microsoft.Extensions.DependencyInjection;

using TailwindMerge;

namespace LumexUI.Tests.Components;

public class SwitchTests : TestContext
{
    public SwitchTests()
    {
        Services.AddSingleton<TwMerge>();
    }

    [Fact]
    public void Switch_ShouldRenderCorrectly()
    {
        var action = () => RenderComponent<LumexSwitch>( p => p
            .Add( p => p.ValueExpression, () => true )
        );

        action.Should().NotThrow();
    }

    [Fact]
    public void Switch_WithChildContent_ShouldRenderCorrectly()
    {
        var cut = RenderComponent<LumexSwitch>( p => p
            .Add( p => p.ValueExpression, () => true )
            .AddChildContent( "switch" )
        );

        cut.Markup.Should().Contain( "switch" );
    }

    [Fact]
    public void Switch_WithThumbIcon_ShouldRenderCustomIcon()
    {
        var cut = RenderComponent<LumexSwitch>( p => p
            .Add( p => p.ValueExpression, () => true )
            .Add( p => p.ThumbIcon, ( _ ) => Icons.Rounded.Headphones )
        );

        cut.FindComponent<LumexIcon>().Should().NotBeNull();
    }

    [Fact]
    public void Switch_WithStartIcon_ShouldRenderCustomIcon()
    {
        var cut = RenderComponent<LumexSwitch>( p => p
            .Add( p => p.ValueExpression, () => true )
            .Add( p => p.StartIcon, Icons.Rounded.Headphones )
        );

        cut.FindComponent<LumexIcon>().Should().NotBeNull();
    }

    [Fact]
    public void Switch_WithEndIcon_ShouldRenderCustomIcon()
    {
        var cut = RenderComponent<LumexSwitch>( p => p
            .Add( p => p.ValueExpression, () => true )
            .Add( p => p.EndIcon, Icons.Rounded.Headphones )
        );

        cut.FindComponent<LumexIcon>().Should().NotBeNull();
    }

    [Fact]
    public void Switch_WithStartAndEndIcon_ShouldRenderCustomIcons()
    {
        var cut = RenderComponent<LumexSwitch>( p => p
            .Add( p => p.ValueExpression, () => true )
            .Add( p => p.StartIcon, Icons.Rounded.HeadphonesBattery )
            .Add( p => p.EndIcon, Icons.Rounded.Headphones )
        );

        cut.FindComponents<LumexIcon>().Should().NotBeNull();
        cut.FindComponents<LumexIcon>().Should().HaveCount( 2 );
    }

    [Fact]
    public void Switch_OnChange_ShouldChangeValue()
    {
        var cut = RenderComponent<LumexSwitch>( p => p
            .Add( p => p.Value, false )
            .Add( p => p.ValueExpression, () => true )
        );

        cut.Instance.Value.Should().BeFalse();

        var @switch = cut.Find( "input" );
        @switch.Change( true );

        cut.Instance.Value.Should().BeTrue();
    }

    [Theory]
    [InlineData( true, false )]
    [InlineData( false, true )]
    public void Switch_DisabledOrReadOnly_ShouldNotTriggerChange( bool disabled, bool readOnly )
    {
        var cut = RenderComponent<LumexSwitch>( p => p
            .Add( p => p.Value, true )
            .Add( p => p.ValueExpression, () => true )
            .Add( p => p.Disabled, disabled )
            .Add( p => p.ReadOnly, readOnly )
        );

        cut.Instance.Value.Should().BeTrue();

        var @switch = cut.Find( "input" );
        @switch.Change( false );

        cut.Instance.Value.Should().BeTrue();
    }

    [Fact]
    public async Task Switch_SetCurrentValueAsString_ShouldThrowNotSupported()
    {
        var cut = RenderComponent<LumexSwitch>( p => p
            .Add( p => p.Value, false )
            .Add( p => p.ValueExpression, () => true )
        );

        var action = async () => await cut.Instance.SetCurrentValueAsStringAsync( "true" );

        await action.Should().ThrowAsync<NotSupportedException>();
    }
}