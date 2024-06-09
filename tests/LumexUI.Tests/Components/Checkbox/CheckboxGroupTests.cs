// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using Microsoft.Extensions.DependencyInjection;

using TailwindMerge;

namespace LumexUI.Tests.Components;

public class CheckboxGroupTests : TestContext
{
    public CheckboxGroupTests()
    {
        Services.AddSingleton<TwMerge>();
    }

    [Fact]
    public void CheckboxGroup_ShouldRenderCorrectly()
    {
        var action = () => RenderComponent<LumexCheckboxGroup>( p => p
            .Add( p => p.Label, "Select cities" )
            .Add( p => p.Description, "Select the cities you want to visit" )
            .AddChildContent<LumexCheckbox>( p => p
                .Add( p => p.Value, true )
                .Add( p => p.ValueExpression, () => true )
                .AddChildContent( "Tallinn" ) )
            .AddChildContent<LumexCheckbox>( p => p
                .Add( p => p.Value, false )
                .Add( p => p.ValueExpression, () => false )
                .AddChildContent( "Madrid" ) )
        );

        action.Should().NotThrow();
    }

    [Theory]
    [InlineData( true, false )]
    [InlineData( false, true )]
    public void CheckboxGroup_DisabledOrReadOnly_ShouldNotTriggerChange( bool disabled, bool readOnly )
    {
        var cut = RenderComponent<LumexCheckboxGroup>( p => p
            .Add( p => p.Label, "Select cities" )
            .Add( p => p.Description, "Select the cities you want to visit" )
            .Add( p => p.Disabled, disabled )
            .Add( p => p.ReadOnly, readOnly )
            .AddChildContent<LumexCheckbox>( p => p
                .Add( p => p.Value, true )
                .Add( p => p.ValueExpression, () => true )
                .AddChildContent( "Tallinn" ) )
            .AddChildContent<LumexCheckbox>( p => p
                .Add( p => p.Value, false )
                .Add( p => p.ValueExpression, () => false )
                .AddChildContent( "Madrid" ) )
        );

        var checkboxes = cut.FindComponents<LumexCheckbox>();

        checkboxes[0].Instance.Value.Should().BeTrue();
        checkboxes[1].Instance.Value.Should().BeFalse();

        checkboxes[0].Find( "input" ).Change( false );

        checkboxes[0].Instance.Value.Should().BeTrue();
        checkboxes[1].Instance.Value.Should().BeFalse();
    }
}