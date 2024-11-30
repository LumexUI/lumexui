// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using Microsoft.Extensions.DependencyInjection;

using TailwindMerge;

namespace LumexUI.Tests.Components;

public class RadioGroupTests: TestContext
{
    public RadioGroupTests()
    {
        Services.AddSingleton<TwMerge>();
    }

    [Fact]
    public void RadioGroup_ShouldRenderCorrectly()
    {
        var action = () => RenderComponent<LumexRadioGroup<string>>( p => p
            .Add( p => p.Label, "Select City" )
            .Add( p => p.Description, "Select the city in which you currently live" )
            .AddChildContent<LumexRadio<string>>( p => p
                .Add( p => p.Value, "tallinn" )
                .AddChildContent( "Tallinn" ) )
            .AddChildContent<LumexRadio<string>>( p => p
                .Add( p => p.Value, "madrid" )
                .AddChildContent( "Madrid" ) )
        );

        action.Should().NotThrow();
    }
}