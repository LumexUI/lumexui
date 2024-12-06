// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;

using Microsoft.AspNetCore.Components;
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
        const string groupName = "OfficerChoice";

        var action = StarfleetOfficers( groupName );

        action.Should().NotThrow();

        var cut = action.Invoke();
        var radioButtons = cut.FindComponents<LumexRadio<string>>();

        radioButtons.Count.Should().Be( 4 );

        radioButtons[0].Instance.Value.Should().Be( "Freeman" );
        radioButtons[0].Instance.Context.GroupName.Should().Be( groupName );
        radioButtons[0].Markup.Should().Contain( "Beckett Mariner" );

        radioButtons[1].Instance.Value.Should().Be( "Boims" );
        radioButtons[1].Instance.Context.GroupName.Should().Be( groupName );
        radioButtons[1].Markup.Should().Contain( "Brad Boimler" );

        radioButtons[2].Instance.Value.Should().Be( "Mistress" );
        radioButtons[2].Instance.Context.GroupName.Should().Be( groupName );
        radioButtons[2].Markup.Should().Contain( "D'Vana Tendi" );

        radioButtons[3].Instance.Value.Should().Be( "Samanthan" );
        radioButtons[3].Instance.Context.GroupName.Should().Be( groupName );
        radioButtons[3].Markup.Should().Contain( "Sam Rutherford" );
    }

    private Func<IRenderedComponent<LumexRadioGroup<string>>> StarfleetOfficers( string groupName, string? selectedValue = null, bool isReadOnly = false, bool isDisabled = false )
    {
        return () => RenderComponent<LumexRadioGroup<string>>( g => g
            .Add( p => p.Label, "Select Officer" )
            .Add( p => p.Description, "Select the officer you'd to lead the away mission" )
            .Add( p => p.Name, groupName )
            .Add( p => p.Disabled, isDisabled )
            .Add( p => p.ReadOnly, isReadOnly )
            .Add( p => p.Value, selectedValue )
            .AddChildContent<LumexRadio<string>>( r => r
                .Add( p => p.Value, "Freeman" )
                .AddChildContent( "Beckett Mariner" ) )
            .AddChildContent<LumexRadio<string>>( r => r
                .Add( p => p.Value, "Boims" )
                .AddChildContent( "Brad Boimler" ) )
            .AddChildContent<LumexRadio<string>>( r => r
                .Add( p => p.Value, "Mistress" )
                .AddChildContent( "D'Vana Tendi" ) )
            .AddChildContent<LumexRadio<string>>( r => r
                .Add( p => p.Value, "Samanthan" )
                .AddChildContent( "Sam Rutherford" ) )
        );
    }

    [Fact]
    public void RadioGroup_ValueGetsSetOnRadioSelection()
    {
        var action = StarfleetOfficers( "StarfleetOfficers", "Freeman" );

        action.Should().NotThrow();

        var cut = action.Invoke();
        var radioGroup = cut.Instance;
        var radioButtons = cut.FindComponents<LumexRadio<string>>();

        radioButtons.Count.Should().Be( 4 );
        radioGroup.Value.Should().NotBe( "Mistress" );
        radioButtons[0].Instance.GetSelectedState().Should().BeTrue();

        var eventArgs = new ChangeEventArgs
        {
            Value = "Mistress"
        };

        radioButtons[2].Find( "input" ).Change( eventArgs );

        radioGroup.Value.Should().Be( "Mistress" );
        radioButtons[2].Instance.GetSelectedState().Should().BeTrue();
        radioButtons[1].Instance.GetSelectedState().Should().BeFalse();
    }

    [Theory]
    [InlineData( true, false )]
    [InlineData( false, true )]
    public void RadioGroup_ValueDoesNotChangeWhenReadOnlyOrDisabled( bool isReadOnly, bool isDisabled )
    {
        var action = StarfleetOfficers( groupName: "StarfleetOfficers", selectedValue: "Boims", isReadOnly, isDisabled );

        action.Should().NotThrow();

        var cut = action.Invoke();
        var radioGroup = cut.Instance;
        var radioButtons = cut.FindComponents<LumexRadio<string>>();

        radioButtons.Count.Should().Be( 4 );

        var eventArgs = new ChangeEventArgs
        {
            Value = "Mistress"
        };

        radioButtons[2].Find( "input" ).Change( eventArgs );

        radioGroup.Value.Should().NotBe( "Mistress" );
        radioButtons[0].Instance.GetSelectedState().Should().BeFalse();
        radioButtons[1].Instance.GetSelectedState().Should().BeTrue();
        radioButtons[2].Instance.GetSelectedState().Should().BeFalse();
        radioButtons[3].Instance.GetSelectedState().Should().BeFalse();
    }
}