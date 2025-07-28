// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Styles;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component that represents a switch input.
/// </summary>
public partial class LumexSwitch : LumexBooleanInputBase, ISlotComponent<SwitchSlots>
{
	/// <summary>
	/// Gets or sets the content to render within the thumb of the switch.
	/// </summary>
	[Parameter] public RenderFragment<bool>? ThumbContent { get; set; }

	/// <summary>
	/// Gets or sets the content to render at the start of the switch.
	/// </summary>
	[Parameter] public RenderFragment? StartContent { get; set; }

	/// <summary>
	/// Gets or sets the content to render at the end of the switch.
	/// </summary>
	[Parameter] public RenderFragment? EndContent { get; set; }

	/// <summary>
	/// Gets or sets the CSS class names for the switch slots.
	/// </summary>
	[Parameter] public SwitchSlots? Classes { get; set; }

	private protected override string? RootClass =>
		TwMerge.Merge( Switch.GetStyles( this ) );

	private string? WrapperClass =>
		TwMerge.Merge( Switch.GetWrapperStyles( this ) );

	private string? ThumbClass =>
		TwMerge.Merge( Switch.GetThumbStyles( this ) );

	private string? ThumbIconClass =>
		TwMerge.Merge( Switch.GetThumbIconStyles( this ) );

	private string? StartIconClass =>
		TwMerge.Merge( Switch.GetStartIconStyles( this ) );

	private string? EndIconClass =>
		TwMerge.Merge( Switch.GetEndIconStyles( this ) );

	private string? LabelClass =>
		TwMerge.Merge( Switch.GetLabelStyles( this ) );

	/// <summary>
	/// Initializes a new instance of the <see cref="LumexSwitch"/>.
	/// </summary>
	public LumexSwitch()
	{
		Color = ThemeColor.Primary;
	}
}
