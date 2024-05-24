// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using Microsoft.AspNetCore.Components;

using TailwindMerge;

namespace LumexUI;

public abstract class LumexComponentBase : ComponentBase
{
	/// <summary>
	/// Gets or sets an HTML tag of the component.
	/// </summary>
	[Parameter] public string As { get; set; } = "div";

	/// <summary>
	/// Gets or sets CSS class names that will be applied to the component.
	/// </summary>
	[Parameter] public string? Class { get; set; }

	/// <summary>
	/// Gets or sets styles that will be applied to the component.
	/// </summary>
	[Parameter] public string? Style { get; set; }

	/// <summary>
	/// Gets or sets a collection of additional attributes that will be applied to the component.
	/// </summary>
	[Parameter( CaptureUnmatchedValues = true )]
	public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

	[Inject] protected TwMerge TwMerge { get; set; } = default!;

	private protected virtual string? RootClass => Class;
	private protected virtual string? RootStyle => Style;
}
