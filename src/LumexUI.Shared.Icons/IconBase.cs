// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using Microsoft.AspNetCore.Components;

namespace LumexUI.Shared.Icons;

public abstract class IconBase : ComponentBase
{
	[Parameter] public string? Size { get; set; }

	[Parameter( CaptureUnmatchedValues = true )]
	public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

	protected string Width => Size ?? "24";
	protected string Height => Size ?? "24";
}
