// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

namespace LumexUI;

/// <summary>
/// Represents the set of customizable slots for the <see cref="LumexSwitch"/> component.
/// </summary>
[ExcludeFromCodeCoverage]
public class SwitchSlots : SlotBase
{
	/// <summary>
	/// Gets or sets the CSS class for the wrapper slot.
	/// </summary>
	public string? Wrapper { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the thumb slot.
	/// </summary>
	public string? Thumb { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the label slot.
	/// </summary>
	public string? Label { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the start icon slot.
	/// </summary>
	public string? StartIcon { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the end icon slot.
	/// </summary>
	public string? EndIcon { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the thumb icon slot.
	/// </summary>
	public string? ThumbIcon { get; set; }
}
