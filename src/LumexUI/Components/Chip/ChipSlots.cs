// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

namespace LumexUI;

/// <summary>
/// Represents the set of customizable slots for the <see cref="LumexChip"/> component.
/// </summary>
[ExcludeFromCodeCoverage]
public class ChipSlots : SlotBase
{
	/// <summary>
	/// Gets or sets the CSS class for the content slot.
	/// </summary>
	public string? Content { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the dot slot.
	/// </summary>
	public string? Dot { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the close button slot.
	/// </summary>
	public string? CloseButton { get; set; }
}
