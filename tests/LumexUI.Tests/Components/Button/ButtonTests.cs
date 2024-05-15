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
	public void Button_ChildContent_ShouldRenderCorrectly()
	{
		var content = "Button";

		var cut = RenderComponent<LumexButton>( p => p
			.AddChildContent( content )
		);

		cut.Markup.Should().Contain( content );
	}

	[Fact]
	public void Button_Disabled_ShouldHaveDisabledAttribute()
	{
		var cut = RenderComponent<LumexButton>( p => p
			.Add( p => p.Disabled, true )
		);

		var button = cut.Find( "button" );

		button.HasAttribute( "disabled" ).Should().BeTrue();
	}

	[Fact]
	public void Button_Disabled_ShouldNotTriggerClick()
	{
		var clicked = false;
		var cut = RenderComponent<LumexButton>( p => p
			.Add( p => p.Disabled, true )
			.Add( p => p.OnClick, () => clicked = true )
		);

		var button = cut.Find( "button" );
		button.Click();

        clicked.Should().BeFalse();
	}

    [Fact]
    public void Button_NotDisabled_ShouldTriggerClick()
    {
        var clicked = false;
        var cut = RenderComponent<LumexButton>( p => p
            .Add( p => p.Disabled, false )
            .Add( p => p.OnClick, () => clicked = true )
        );

        var button = cut.Find( "button" );
        button.Click();

        clicked.Should().BeTrue();
    }

    [Fact]
	public void Button_Type_ShouldHaveCorrectTypeAttribute()
	{
		var cut = RenderComponent<LumexButton>( p => p
			.Add( p => p.Type, ButtonType.Submit )
		);

		var button = cut.Find( "button" );

		button.GetAttribute( "type" ).Should().Be( ButtonType.Submit.ToDescription() );
	}
}