// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

namespace LumexUI;

/// <summary>
/// Represents the set of customizable slots for the <see cref="LumexCheckbox"/> component.
/// </summary>
[ExcludeFromCodeCoverage]
public class CheckboxSlots : SlotBase
{
	/// <summary>
	/// Gets or sets the CSS class for the wrapper slot.
	/// </summary>
	public string? Wrapper { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the icon slot.
	/// </summary>
	public string? Icon { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the label slot.
	/// </summary>
	public string? Label { get; set; }
}
