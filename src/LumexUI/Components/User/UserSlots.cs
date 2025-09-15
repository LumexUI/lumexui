// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

namespace LumexUI;

/// <summary>
/// Represents the set of customizable slots for the <see cref="LumexUser"/> component.
/// </summary>
[ExcludeFromCodeCoverage]
public class UserSlots : SlotBase
{
	/// <summary>
	/// Gets or sets the CSS class for the wrapper slot.
	/// </summary>
	public string? Wrapper { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the name slot.
	/// </summary>
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the description slot.
	/// </summary>
	public string? Description { get; set; }
}
