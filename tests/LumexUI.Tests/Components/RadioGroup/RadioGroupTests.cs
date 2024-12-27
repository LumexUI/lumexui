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

    [Theory]
    [InlineData( "true" )]
    [InlineData( "false" )]
    [InlineData( "foobool" )]
    [InlineData( "" )]
    [InlineData( null )]
    public void RadioGroup_BooleansAreParsedProperly( string? boolString )
    {
        var action = () => RenderComponent<LumexRadioGroup<bool>>( c => c
            .AddChildContent<LumexRadio<bool>>( r => r
                .Add( p => p.Value, true )
                .AddChildContent( "Yes" )
            )
            .AddChildContent<LumexRadio<bool>>( r => r
                .Add( p => p.Value, false )
                .AddChildContent( "No" )
            )
        );

        action.Should().NotThrow();

        var cut = action.Invoke();
        var radioGroup = cut.Instance;
        var radioButtons = cut.FindComponents<LumexRadio<bool>>();

        radioButtons.Count.Should().Be( 2 );
        radioGroup.Value.Should().BeFalse();
        radioButtons[0].Instance.GetSelectedState().Should().BeFalse();
        radioButtons[1].Instance.GetSelectedState().Should().BeTrue();

        var boolEvent = new ChangeEventArgs
        {
            Value = boolString
        };

        radioButtons[0].Find( "input" ).Change( boolEvent );

        switch( boolString?.ToLower() )
        {
            case "true":
                radioGroup.Value.Should().BeTrue();
                radioButtons[0].Instance.GetSelectedState().Should().BeTrue();
                radioButtons[1].Instance.GetSelectedState().Should().BeFalse();
                break;
            case "":
            case "foobool":
            case null:
            case "false":
                radioGroup.Value.Should().BeFalse();
                radioButtons[0].Instance.GetSelectedState().Should().BeFalse();
                radioButtons[1].Instance.GetSelectedState().Should().BeTrue();
                break;
            default:
                throw new InvalidOperationException( "Invalid boolean string" );
        }
    }

    [Theory]
    [InlineData( "true" )]
    [InlineData( "false" )]
    [InlineData( "foobool" )]
    [InlineData( "" )]
    [InlineData( null )]
    public void RadioGroup_NullableBooleansAreSupported( string? boolString )
    {
        var action = () => RenderComponent<LumexRadioGroup<bool?>>( c => c
            .AddChildContent<LumexRadio<bool?>>( r => r
                .Add( p => p.Value, true )
                .AddChildContent( "Yes" )
            )
            .AddChildContent<LumexRadio<bool?>>( r => r
                .Add( p => p.Value, false )
                .AddChildContent( "No" )
            )
        );

        action.Should().NotThrow();

        var cut = action.Invoke();
        var radioGroup = cut.Instance;
        var radioButtons = cut.FindComponents<LumexRadio<bool?>>();

        radioButtons.Count.Should().Be( 2 );
        radioGroup.Value.Should().BeNull();
        radioButtons[0].Instance.GetSelectedState().Should().BeFalse();
        radioButtons[1].Instance.GetSelectedState().Should().BeFalse();

        var boolEvent = new ChangeEventArgs
        {
            Value = boolString
        };

        radioButtons[0].Find( "input" ).Change( boolEvent );

        switch( boolString?.ToLower() )
        {
            case "true":
                radioGroup.Value.Should().NotBeNull();
                radioButtons[0].Instance.GetSelectedState().Should().BeTrue();
                radioButtons[1].Instance.GetSelectedState().Should().BeFalse();
                break;
            case "false":
                radioGroup.Value.Should().NotBeNull();
                radioButtons[0].Instance.GetSelectedState().Should().BeFalse();
                radioButtons[1].Instance.GetSelectedState().Should().BeTrue();
                break;
            case "":
            case "foobool": // Special case that should return null on a nullable boolean because it can't be parsed
            case null:
                radioGroup.Value.Should().BeNull();
                radioButtons[0].Instance.GetSelectedState().Should().BeFalse();
                radioButtons[1].Instance.GetSelectedState().Should().BeFalse();
                break;
            default:
                throw new InvalidOperationException( "Invalid boolean string" );
        }
    }

    [Theory]
    [InlineData( "1" )]
    [InlineData( "3" )]
    [InlineData( "foobool" )]
    [InlineData( "" )]
    [InlineData( null )]
    public void RadioGroup_NullableValueTypesAreSupported( string? valueString )
    {
        var action = () => RenderComponent<LumexRadioGroup<int?>>( c => c
            .AddChildContent<LumexRadio<int?>>( r => r
                .Add( p => p.Value, 1 )
                .AddChildContent( "One" )
            )
            .AddChildContent<LumexRadio<int?>>( r => r
                .Add( p => p.Value, 100 )
                .AddChildContent( "One Hundred" )
            )
        );

        action.Should().NotThrow();
    }

    [Theory]
    [InlineData( "1" )]
    [InlineData( "One" )]
    [InlineData( "Two" )]
    [InlineData( "One Hundred" )]
    [InlineData( "No Answer" )]
    [InlineData( "" )]
    [InlineData( null )]
    public void RadioGroup_NullableReferenceTypesAreSupported( string? stringValue )
    {
        var action = () => RenderComponent<LumexRadioGroup<string?>>( c => c
            .AddChildContent<LumexRadio<string?>>( r => r
                .Add( p => p.Value, "One" )
                .AddChildContent( "One" )
            )
            .AddChildContent<LumexRadio<string?>>( r => r
                .Add( p => p.Value, "One Hundred" )
                .AddChildContent( "One Hundred" )
            )
            .AddChildContent<LumexRadio<string?>>( r => r
                .Add( p => p.Value, "No Answer" )
                .AddChildContent( "No Answer" )
            )
        );

        action.Should().NotThrow();

        var cut = action.Invoke();
        var radioGroup = cut.Instance;
        var radioButtons = cut.FindComponents<LumexRadio<string?>>();

        radioButtons.Count.Should().Be( 3 );
        radioGroup.Value.Should().BeNull();
        radioButtons[0].Instance.GetSelectedState().Should().BeFalse();
        radioButtons[1].Instance.GetSelectedState().Should().BeFalse();
        radioButtons[2].Instance.GetSelectedState().Should().BeFalse();

        var boolEvent = new ChangeEventArgs
        {
            Value = stringValue
        };

        radioButtons[0].Find( "input" ).Change( boolEvent );

        switch( stringValue?.ToLower() )
        {
            case "one":
                radioGroup.Value.Should().Be( "One" );
                radioButtons[0].Instance.GetSelectedState().Should().BeTrue();
                radioButtons[1].Instance.GetSelectedState().Should().BeFalse();
                radioButtons[2].Instance.GetSelectedState().Should().BeFalse();
                break;
            case "one hundred":
                radioGroup.Value.Should().Be( "One Hundred" );
                radioButtons[0].Instance.GetSelectedState().Should().BeFalse();
                radioButtons[1].Instance.GetSelectedState().Should().BeTrue();
                radioButtons[2].Instance.GetSelectedState().Should().BeFalse();
                break;
            case "no answer":
                radioGroup.Value.Should().Be( "No Answer" );
                radioButtons[0].Instance.GetSelectedState().Should().BeFalse();
                radioButtons[1].Instance.GetSelectedState().Should().BeFalse();
                radioButtons[2].Instance.GetSelectedState().Should().BeTrue();
                break;
            default:
                radioGroup.Value.Should().Be( stringValue );
                radioButtons[0].Instance.GetSelectedState().Should().BeFalse();
                radioButtons[1].Instance.GetSelectedState().Should().BeFalse();
                radioButtons[2].Instance.GetSelectedState().Should().BeFalse();
                break;
        }
    }

    private Func<IRenderedComponent<LumexRadioGroup<string>>> StarfleetOfficers( string groupName, string? selectedValue = null, bool isReadOnly = false, bool isDisabled = false )
    {
        return () => RenderComponent<LumexRadioGroup<string>>( g => g
            .Add( p => p.Label, "Select Officer" )
            .Add( p => p.Description, "Select the officer you'd prefer to lead the away mission" )
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
}