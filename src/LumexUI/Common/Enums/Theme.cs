// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.ComponentModel;

namespace LumexUI.Common;

/// <summary>
/// Specifies the available theme options.
/// </summary>
public enum Theme
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
	Dark,

	/// <summary>
	/// A theme that matches the system setting.
	/// </summary>
	[Description( "system" )]
	System
}
