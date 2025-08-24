// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;

using System.Diagnostics.CodeAnalysis;

namespace LumexUI;

/// <summary>
/// Represents the set of customizable slots for the <see cref="Menu"/> component.
/// </summary>
[ExcludeFromCodeCoverage]
public class MenuSlots : SlotBase
{
	/// <summary>
	/// Gets or sets the CSS class for the list slot.
	/// </summary>
	public string? List { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the empty content slot.
	/// </summary>
	public string? EmptyContent { get; set; }
}
