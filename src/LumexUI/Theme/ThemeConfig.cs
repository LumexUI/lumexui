// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;

namespace LumexUI.Theme;

/// <summary>
/// Represents the configuration settings for a theme.
/// </summary>
/// <param name="Type">The type of the theme.</param>
/// <param name="Colors">The colors associated with the theme.</param>
/// <param name="Layout">The layout settings for the theme.</param>
public record ThemeConfig( ThemeType Type, ThemeColors Colors, LayoutConfig Layout );
