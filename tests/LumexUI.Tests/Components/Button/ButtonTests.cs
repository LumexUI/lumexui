// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using Bunit;

using FluentAssertions;

using LumexUI.Common;
using LumexUI.Utilities;

using Microsoft.Extensions.DependencyInjection;

using TailwindMerge;

namespace LumexUI.Tests;

public class ButtonTests : TestContext
{
	public ButtonTests()
	{
		Services.AddSingleton<TwMerge>();
	}

	[Fact]
	public void Button_ChildContent_ShouldRenderDisabledAttribute()
	{
		// Arrange
		var content = "Button";

		// Act
		var cut = RenderComponent<LumexButton>( p => p
			.AddChildContent( content )
		);

		// Assert
		cut.Markup.Should().Contain( content );
	}

	[Fact]
	public void Button_Disabled_ShouldRenderDisabledAttribute()
	{
		// Arrange
		var cut = RenderComponent<LumexButton>( p => p
			.Add( p => p.Disabled, true )
		);

		// Act
		var button = cut.Find( "button" );

		// Assert
		button.HasAttribute( "disabled" ).Should().BeTrue();
	}

	[Fact]
	public void Button_Disabled_ShouldNotClick()
	{
		// Arrange
		var counter = 0;
		var cut = RenderComponent<LumexButton>( p => p
			.Add( p => p.Disabled, true )
			.Add( p => p.OnClick, () => counter++ )
		);

		// Act
		var button = cut.Find( "button" );
		button.Click();

		// Assert
		counter.Should().Be( 0 );
	}

	[Fact]
	public void Button_Type_ShouldRenderCorrectTypeAttribute()
	{
		// Arrange
		var cut = RenderComponent<LumexButton>( p => p
			.Add( p => p.Type, ButtonType.Submit )
		);

		// Act
		var button = cut.Find( "button" );

		// Assert
		button.GetAttribute( "type" ).Should().Be( ButtonType.Submit.ToDescription() );
	}
}