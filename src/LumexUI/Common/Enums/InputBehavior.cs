// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

namespace LumexUI.Common;

/// <summary>
/// Specifies the behavior of an input field when handling user input.
/// </summary>
public enum InputBehavior
{
	/// <summary>
	/// Triggers the input event as the user types.
	/// </summary>
	OnInput,

	/// <summary>
	/// Triggers the input event only when the field loses focus or the value changes.
	/// </summary>
	OnChange
}
