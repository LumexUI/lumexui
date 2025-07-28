// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Tests.Extensions;

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
			.Add( p => p.ValueExpression, () => true )
			.AddChildContent( "checkbox" )
		);

		cut.Markup.Should().Contain( "checkbox" );
	}

	[Fact]
	public void Checkbox_WithCheckIcon_ShouldRenderCustomIcon()
	{
		var cut = RenderComponent<LumexCheckbox>( p => p
			.Add( p => p.ValueExpression, () => true )
			.Add( p => p.IconContent, "check-icon" )
		);

		cut.FindBySlot( "icon" ).Should().NotBeNull();
	}

	[Fact]
	public void Checkbox_OnChange_ShouldChangeValue()
	{
		var cut = RenderComponent<LumexCheckbox>( p => p
			.Add( p => p.Value, false )
			.Add( p => p.ValueExpression, () => true )
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
			.Add( p => p.Value, true )
			.Add( p => p.ValueExpression, () => true )
			.Add( p => p.Disabled, disabled )
			.Add( p => p.ReadOnly, readOnly )
		);

		cut.Instance.Value.Should().BeTrue();

		var checkbox = cut.Find( "input" );
		checkbox.Change( false );

		cut.Instance.Value.Should().BeTrue();
	}

	[Fact]
	public void Checkbox_WithContext_ShouldPreferOwnParameterValues()
	{
		var cut = RenderComponent<LumexCheckboxGroup>( p => p
			.Add( p => p.Label, "Select cities" )
			.Add( p => p.Description, "Select the cities you want to visit" )
			.Add( p => p.Size, Size.Large )
			.Add( p => p.Radius, Radius.Small )
			.Add( p => p.Color, ThemeColor.Warning )
			.AddChildContent<LumexCheckbox>( p => p
				.Add( p => p.Value, true )
				.Add( p => p.ValueExpression, () => true )
				.Add( p => p.Size, Size.Small )
				.Add( p => p.Radius, Radius.Medium )
				.Add( p => p.Color, ThemeColor.Info )
				.AddChildContent( "Tallinn" ) )
			.AddChildContent<LumexCheckbox>( p => p
				.Add( p => p.Value, false )
				.Add( p => p.ValueExpression, () => false )
				.AddChildContent( "Madrid" ) )
		);

		var checkboxes = cut.FindComponents<LumexCheckbox>();

		checkboxes[0].Instance.Size.Should().Be( Size.Small );
		checkboxes[1].Instance.Size.Should().Be( Size.Large );

		checkboxes[0].Instance.Radius.Should().Be( Radius.Medium );
		checkboxes[1].Instance.Radius.Should().Be( Radius.Small );

		checkboxes[0].Instance.Color.Should().Be( ThemeColor.Info );
		checkboxes[1].Instance.Color.Should().Be( ThemeColor.Warning );
	}

	[Fact]
	public async Task Checkbox_SetCurrentValueAsString_ShouldThrowNotSupported()
	{
		var cut = RenderComponent<LumexCheckbox>( p => p
			.Add( p => p.Value, false )
			.Add( p => p.ValueExpression, () => true )
		);

		var action = async () => await cut.Instance.SetCurrentValueAsStringAsync( "true" );

		await action.Should().ThrowAsync<NotSupportedException>();
	}
}