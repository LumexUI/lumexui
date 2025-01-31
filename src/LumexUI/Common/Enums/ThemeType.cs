// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.ComponentModel;

using LumexUI.Theme;

namespace LumexUI.Common;

/// <summary>
/// Specifies theme type options for the <see cref="LumexTheme"/>.
/// </summary>
public enum ThemeType
{
	/// <summary>
	/// A light theme.
	/// </summary>
	[Description( "light" )]
	Light,

	/// <summary>
	/// A dark theme.
	/// </summary>
	[Description( "dark" )]
	Dark
}
