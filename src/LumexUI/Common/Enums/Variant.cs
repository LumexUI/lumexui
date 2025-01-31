// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

namespace LumexUI.Common;

/// <summary>
/// Specifies the visual variants for a component.
/// </summary>
public enum Variant
{
	/// <summary>
	/// A variant with a filled background.
	/// </summary>
	Solid,

	/// <summary>
	/// A variant with an outlined border.
	/// </summary>
	Outlined,

	/// <summary>
	/// A variant with a subtle background.
	/// </summary>
	Flat,

	/// <summary>
	/// A variant with a shadow effect.
	/// </summary>
	Shadow,

	/// <summary>
	/// A variant with an outlined border; with a filled background on hover.
	/// </summary>
	Ghost,

	/// <summary>
	/// A variant without any styling.
	/// </summary>
	Light
}
