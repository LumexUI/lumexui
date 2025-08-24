// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;

using System.Diagnostics.CodeAnalysis;

namespace LumexUI;

/// <summary>
/// Represents the set of customizable slots for the <see cref="MenuItem"/> component.
/// </summary>
[ExcludeFromCodeCoverage]
public class MenuItemSlots : SlotBase
{
	/// <summary>
	/// Gets or sets the CSS class for the wrapper slot.
	/// </summary>
	public string? Wrapper { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the title slot.
	/// </summary>
	public string? Title { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the description slot.
	/// </summary>
	public string? Description { get; set; }
}
