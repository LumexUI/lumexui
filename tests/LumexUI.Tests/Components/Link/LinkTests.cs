// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using Microsoft.Extensions.DependencyInjection;

using TailwindMerge;

namespace LumexUI.Tests.Components;

public class LinkTests : TestContext
{
	public LinkTests()
	{
		Services.AddSingleton<TwMerge>();
	}

	[Fact]
	public void Link_ShouldRenderCorrectly()
	{
		var action = () => RenderComponent<LumexLink>();

		action.Should().NotThrow();
	}

	[Fact]
	public void Link_External_ShouldSetCorrectAttributes()
	{
		var cut = RenderComponent<LumexLink>( p => p
			.Add( p => p.External, true )
		);

		var link = cut.Find( "a" );

		link.GetAttribute( "target" ).Should().Be( "_blank" );
		link.GetAttribute( "rel" ).Should().Be( "noopener noreferrer" );
	}

	[Fact]
	public void Link_AdditionalAttributes_ShouldSetAttributes()
	{
		var attributes = new Dictionary<string, object>
		{
			["data-custom"] = "custom-attribute-value"
		};

		var cut = RenderComponent<LumexLink>( p => p
			.Add( p => p.AdditionalAttributes, attributes )
		);

		cut.Find( "a" ).GetAttribute( "data-custom" ).Should().NotBeNull();
	}
}