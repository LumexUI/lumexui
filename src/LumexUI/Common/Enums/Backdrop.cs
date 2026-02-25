// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

namespace LumexUI.Common;

/// <summary>
/// Specifies the backdrop style options for a <see cref="LumexModal"/>.
/// </summary>
public enum Backdrop
{
	/// <summary>
	/// A transparent backdrop with no visible background.
	/// </summary>
	Transparent,

	/// <summary>
	/// An opaque backdrop with a semi-transparent overlay.
	/// </summary>
	Opaque,

	/// <summary>
	/// A blurred backdrop with a frosted glass effect.
	/// </summary>
	Blur
}
