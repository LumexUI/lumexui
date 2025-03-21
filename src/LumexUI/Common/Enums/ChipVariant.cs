// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

namespace LumexUI.Common;

/// <summary>
/// Specifies the visual variants for the <see cref="LumexChip"/>.
/// </summary>
public enum ChipVariant
{
	/// <summary>
	/// A solid chip with a filled background.
	/// </summary>
	Solid,

	/// <summary>
	/// A chip with an outlined border.
	/// </summary>
	Outlined,

	/// <summary>
	/// A chip with a flat background.
	/// </summary>
	Flat,

	/// <summary>
	/// A chip with a shadow.
	/// </summary>
	Shadow,

	/// <summary>
	/// A chip without a background, just text.
	/// </summary>
	Light,

	/// <summary>
	/// A chip with a dot at the start.
	/// </summary>
	Dot
}
