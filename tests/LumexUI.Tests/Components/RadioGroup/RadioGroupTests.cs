// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;

using Microsoft.Extensions.DependencyInjection;

using TailwindMerge;

namespace LumexUI.Tests.Components;

public class RadioGroupTests : TestContext
{
    public RadioGroupTests()
    {
        Services.AddSingleton<TwMerge>();
    }

    [Fact]
    public void RadioGroup_ShouldRenderCorrectly()
    {
        var action = () => RenderComponent<LumexRadioGroup<string>>( g => g
            .Add( p => p.Label, "Select City" )
            .Add( p => p.Description, "Select the city in which you currently live" )
            .AddChildContent<LumexRadio<string>>( r => r
                .Add( p => p.Value, "tallinn" )
                .AddChildContent( "Tallinn" ) )
            .AddChildContent<LumexRadio<string>>( r => r
                .Add( p => p.Value, "madrid" )
                .AddChildContent( "Madrid" ) )
        );

        action.Should().NotThrow();

        var cut = action.Invoke();
        var radioButtons = cut.FindComponents<LumexRadio<string>>();

        radioButtons.Count.Should().Be( 2 );

        radioButtons[0].Instance.Value.Should().Be( "tallinn" );
        radioButtons[0].Markup.Should().Contain( "Tallinn" );
        radioButtons[1].Instance.Value.Should().Be( "madrid" );
        radioButtons[1].Markup.Should().Contain( "Madrid" );
    }
}