// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

namespace LumexUI;

/// <summary>
/// Represents the slot names for the <see cref="LumexCard"/>, 
/// used to assign CSS classes to different parts of the component.
/// </summary>
[ExcludeFromCodeCoverage]
public class CardSlots : ISlot
{
	/// <summary>
	/// Gets or sets the CSS class for the root slot.
	/// </summary>
	public string? Root { get; set; }

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
