// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BlazorApp2.Components;

public class Comp : CompBase
{
	[Parameter] public RenderFragment? ChildContent { get; set; }
	[Parameter] public string? As { get; set; }

	protected override void BuildRenderTree( RenderTreeBuilder builder )
	{
		builder.OpenElement( 0, As ?? "div" );
		builder.AddAttribute( 1, "class", Class );
		builder.AddMultipleAttributes( 2, AdditionalAttributes );
		builder.AddContent( 3, ChildContent );
		builder.CloseElement();
	}
}
