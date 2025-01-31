// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.ComponentModel;

namespace LumexUI.Common;

/// <summary>
/// Specifies the type of the <see cref="LumexTextbox"/>.
/// </summary>
public enum InputType
{
	/// <summary>
	/// A single-line text input field.
	/// </summary>
	[Description( "text" )]
	Text,

	/// <summary>
	/// A password input field that masks the entered characters.
	/// </summary>
	[Description( "password" )]
	Password,

	/// <summary>
	/// An input field for email addresses with built-in validation.
	/// </summary>
	[Description( "email" )]
	Email,

	/// <summary>
	/// A hidden input field that is not visible to the user.
	/// </summary>
	[Description( "hidden" )]
	Hidden,

	/// <summary>
	/// A search input field optimized for search queries.
	/// </summary>
	[Description( "search" )]
	Search,

	/// <summary>
	/// An input field for telephone numbers.
	/// </summary>
	[Description( "tel" )]
	Telephone,

	/// <summary>
	/// An input field for entering a URL.
	/// </summary>
	[Description( "url" )]
	Url,

	/// <summary>
	/// An input field for selecting a color.
	/// </summary>
	[Description( "color" )]
	Color
}
