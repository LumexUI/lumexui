// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

namespace LumexUI;

/// <summary>
/// Represents the set of customizable slots for the <see cref="LumexNavbar"/> component.
/// </summary>
[ExcludeFromCodeCoverage]
public class NavbarSlots : SlotBase
{
	/// <summary>
	/// Gets or sets the CSS class for the wrapper slot.
	/// </summary>
	public string? Wrapper { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the brand slot.
	/// </summary>
	public string? Brand { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the content slot.
	/// </summary>
	public string? Content { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the item slot.
	/// </summary>
	public string? Item { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the toggle slot.
	/// </summary>
	public string? Toggle { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the toggle icon slot.
	/// </summary>
	public string? ToggleIcon { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the menu slot.
	/// </summary>
	public string? Menu { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the menu item slot.
	/// </summary>
	public string? MenuItem { get; set; }
}
