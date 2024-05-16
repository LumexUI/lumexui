// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;

namespace LumexUI.Theme;

/// <summary>
/// Represents the configuration settings for themes.
/// </summary>
public record LumexThemeConfig
{
    /// <summary>
    /// Gets or sets the configuration for the light theme.
    /// </summary>
    public ThemeConfig LightTheme { get; set; }

    /// <summary>
    /// Gets or sets the configuration for the dark theme.
    /// </summary>
    public ThemeConfig DarkTheme { get; set; }

    /// <summary>
    /// Gets or sets the default theme type.
    /// </summary>
    public ThemeType DefaultTheme { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="LumexThemeConfig" />.
    /// </summary>
    public LumexThemeConfig()
    {
        LightTheme = new( ThemeType.Light, SemanticColors.Light, Layout: new() );
        DarkTheme = new( ThemeType.Dark, SemanticColors.Dark, Layout: new() );
    }
}
