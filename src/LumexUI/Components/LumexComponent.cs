// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace LumexUI;

public class LumexComponent : LumexComponentBase
{
	/// <summary>
	/// Gets or sets content to be rendered inside the component.
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	protected override void BuildRenderTree( RenderTreeBuilder builder )
	{
		builder.OpenElement( 0, As );
		builder.AddAttribute( 1, "class", Class );
		builder.AddAttribute( 2, "style", Style );
		builder.AddMultipleAttributes( 3, AdditionalAttributes );
        builder.AddElementReferenceCapture( 4, elementReference => ElementReference = elementReference );
		builder.AddContent( 5, ChildContent );
        builder.CloseElement();
	}
}
