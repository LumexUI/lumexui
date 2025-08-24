// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

namespace LumexUI;

/// <summary>
/// Represents the set of customizable slots for the <see cref="LumexAlert"/> component.
/// </summary>
[ExcludeFromCodeCoverage]
public class AlertSlots : SlotBase
{
	/// <summary>
	/// Gets or sets the CSS class for the main wrapper slot.
	/// </summary>
	public string? MainWrapper { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the title slot.
	/// </summary>
	public string? Title { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the description slot.
	/// </summary>
	public string? Description { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the close button slot.
	/// </summary>
	public string? CloseButton { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the icon wrapper slot.
	/// </summary>
	public string? IconWrapper { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the icon slot.
	/// </summary>
	public string? Icon { get; set; }
}
