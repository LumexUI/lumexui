// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

namespace LumexUI;

/// <summary>
/// Represents the set of customizable slots for the <see cref="LumexCard"/> component.
/// </summary>
[ExcludeFromCodeCoverage]
public class CardSlots : SlotBase
{
	/// <summary>
	/// Gets or sets the CSS class for the header slot.
	/// </summary>
	public string? Header { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the body slot.
	/// </summary>
	public string? Body { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the footer slot.
	/// </summary>
	public string? Footer { get; set; }
}
