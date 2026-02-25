// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

namespace LumexUI.Common;

/// <summary>
/// Specifies the placement options for a <see cref="LumexModal"/>.
/// </summary>
public enum ModalPlacement
{
	/// <summary>
	/// Automatically positions the modal based on the viewport.
	/// </summary>
	Auto,

	/// <summary>
	/// Centers the modal vertically and horizontally.
	/// </summary>
	Center,

	/// <summary>
	/// Positions the modal at the top of the viewport.
	/// </summary>
	Top,

	/// <summary>
	/// Positions the modal at the bottom of the viewport.
	/// </summary>
	Bottom
}
