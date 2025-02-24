// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

namespace LumexUI.Common;

/// <summary>
/// Specifies the border radius options for a component.
/// </summary>
public enum Radius
{
	/// <summary>
	/// No border radius.
	/// </summary>
	None,

	/// <summary>
	/// A small border radius.
	/// </summary>
	Small,

	/// <summary>
	/// A medium border radius.
	/// </summary>
	Medium,

	/// <summary>
	/// A large border radius.
	/// </summary>
	Large,

	/// <summary>
	/// A full border radius.
	/// </summary>
	/// <remarks>
	/// Not every component supports this.
	/// </remarks>
	Full
}
