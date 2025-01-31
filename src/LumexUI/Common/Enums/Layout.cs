// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

namespace LumexUI.Common;

/// <summary>
/// Specifies the table layout algorithm used for rendering.
/// </summary>
/// <remarks>
/// See <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/table-layout">table-layout</see> for details.
/// </remarks>
public enum Layout
{
	/// <summary>
	/// The table layout is determined automatically based on the content of the cells.
	/// </summary>
	Auto,

	/// <summary>
	/// The table layout is fixed, meaning column widths are determined by the table's first row and do not change based on content.
	/// </summary>
	Fixed
}
