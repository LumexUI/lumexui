// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using Microsoft.Extensions.DependencyInjection;

using TailwindMerge;

namespace LumexUI.Tests.Components;
public class ImageTests : TestContext
{
	public ImageTests()
	{
		Services.AddSingleton<TwMerge>();
	}

	[Fact]
	public void Button_ShouldRenderCorrectly()
	{
		var action = () => RenderComponent<LumexImage>();

		action.Should().NotThrow();
	}
}
