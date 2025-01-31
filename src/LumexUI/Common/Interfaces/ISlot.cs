// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

namespace LumexUI.Common;

/// <summary>
/// Defines a contract for a slot that provides styling customization through CSS class properties.
/// </summary>
public interface ISlot
{
	/// <summary>
	/// Gets the CSS class for the root element of the slot.
	/// </summary>
	string? Root { get; }
}
