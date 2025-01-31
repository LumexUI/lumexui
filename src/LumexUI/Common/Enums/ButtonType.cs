// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

namespace LumexUI.Common;

/// <summary>
/// Specifies the type of the <see cref="LumexButton"/>.
/// </summary>
public enum ButtonType
{
	/// <summary>
	/// A standard button with no default behavior.
	/// </summary>
	Button,

	/// <summary>
	/// A button that submits form data.
	/// </summary>
	Submit,

	/// <summary>
	/// A button that resets all form fields to their initial values.
	/// </summary>
	Reset
}