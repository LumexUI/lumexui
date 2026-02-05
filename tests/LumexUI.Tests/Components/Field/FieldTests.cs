// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Tests.Extensions;

using Microsoft.Extensions.DependencyInjection;

using TailwindMerge;

namespace LumexUI.Tests.Components;

public class FieldTests : TestContext
{
	public FieldTests()
	{
		Services.AddSingleton<TwMerge>();
	}

	[Fact]
	public void Field_ShouldRenderCorrectly()
	{
		var action = () => RenderComponent<LumexField>();

		action.Should().NotThrow();
	}

	[Fact]
	public void Field_Vertical_ShouldRenderLabelAboveContent()
	{
		var cut = RenderComponent<LumexField>( p => p
			.Add( p => p.Label, "Email" )
			.Add( p => p.Orientation, Orientation.Vertical )
			.AddChildContent( "<input type='text' />" )
		);

		var field = cut.FindBySlot( "field" );
		field.GetAttribute( "data-orientation" ).Should().Be( "vertical" );

		cut.FindBySlot( "label" ).TextContent.Should().Contain( "Email" );
		cut.FindBySlot( "content" ).Should().NotBeNull();
	}

	[Fact]
	public void Field_Horizontal_ShouldRenderLabelBesideContent()
	{
		var cut = RenderComponent<LumexField>( p => p
			.Add( p => p.Label, "Remember me" )
			.Add( p => p.Orientation, Orientation.Horizontal )
			.AddChildContent( "<input type='checkbox' />" )
		);

		var field = cut.FindBySlot( "field" );
		field.GetAttribute( "data-orientation" ).Should().Be( "horizontal" );

		cut.FindBySlot( "label-wrapper" ).Should().NotBeNull();
		cut.FindBySlot( "label" ).TextContent.Should().Contain( "Remember me" );
	}

	[Fact]
	public void Field_WithDescription_ShouldRenderDescription()
	{
		var cut = RenderComponent<LumexField>( p => p
			.Add( p => p.Label, "Email" )
			.Add( p => p.Description, "We'll never share your email" )
		);

		cut.FindBySlot( "description" ).TextContent.Should().Contain( "We'll never share your email" );
	}

	[Fact]
	public void Field_WithErrorMessage_WhenInvalid_ShouldRenderErrorInsteadOfDescription()
	{
		var cut = RenderComponent<LumexField>( p => p
			.Add( p => p.Label, "Email" )
			.Add( p => p.Description, "We'll never share your email" )
			.Add( p => p.ErrorMessage, "Email is required" )
			.Add( p => p.Invalid, true )
		);

		cut.FindBySlot( "error-message" ).TextContent.Should().Contain( "Email is required" );
		cut.FindAllBySlot( "description" ).Should().BeEmpty();
	}

	[Fact]
	public void Field_WithErrorMessage_WhenNotInvalid_ShouldRenderDescription()
	{
		var cut = RenderComponent<LumexField>( p => p
			.Add( p => p.Label, "Email" )
			.Add( p => p.Description, "We'll never share your email" )
			.Add( p => p.ErrorMessage, "Email is required" )
			.Add( p => p.Invalid, false )
		);

		cut.FindBySlot( "description" ).TextContent.Should().Contain( "We'll never share your email" );
		cut.FindAllBySlot( "error-message" ).Should().BeEmpty();
	}

	[Fact]
	public void Field_Required_ShouldHaveRequiredDataAttribute()
	{
		var cut = RenderComponent<LumexField>( p => p
			.Add( p => p.Label, "Email" )
			.Add( p => p.Required, true )
		);

		var field = cut.FindBySlot( "field" );
		field.GetAttribute( "data-required" ).Should().Be( "true" );
	}

	[Fact]
	public void Field_Disabled_ShouldHaveDisabledDataAttribute()
	{
		var cut = RenderComponent<LumexField>( p => p
			.Add( p => p.Label, "Email" )
			.Add( p => p.Disabled, true )
		);

		var field = cut.FindBySlot( "field" );
		field.GetAttribute( "data-disabled" ).Should().Be( "true" );
	}

	[Fact]
	public void Field_Invalid_ShouldHaveInvalidDataAttribute()
	{
		var cut = RenderComponent<LumexField>( p => p
			.Add( p => p.Label, "Email" )
			.Add( p => p.Invalid, true )
		);

		var field = cut.FindBySlot( "field" );
		field.GetAttribute( "data-invalid" ).Should().Be( "true" );
	}

	[Fact]
	public void Field_WithCustomClasses_ShouldApplySlotClasses()
	{
		var cut = RenderComponent<LumexField>( p => p
			.Add( p => p.Label, "Email" )
			.Add( p => p.Description, "Description" )
			.Add( p => p.Classes, new FieldSlots
			{
				Base = "custom-base",
				Label = "custom-label",
				Description = "custom-description"
			} )
		);

		cut.FindBySlot( "field" ).ClassList.Should().Contain( "custom-base" );
		cut.FindBySlot( "label" ).ClassList.Should().Contain( "custom-label" );
		cut.FindBySlot( "description" ).ClassList.Should().Contain( "custom-description" );
	}
}
