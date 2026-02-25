// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

namespace LumexUI.Common;

/// <summary>
/// Specifies the scroll behavior options for a <see cref="LumexModal"/>.
/// </summary>
public enum ScrollBehavior
{
	/// <summary>
	/// The page scroll is disabled while the overlay is open.
	/// </summary>
	Normal,

	/// <summary>
	/// The overlay content scrolls independently within its container.
	/// </summary>
	Inside,

	/// <summary>
	/// The entire overlay scrolls with the page.
	/// </summary>
	Outside
}
