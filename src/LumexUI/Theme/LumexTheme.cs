// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;

namespace LumexUI.Theme;

/// <summary>
/// Represents the configuration settings for themes.
/// </summary>
public record LumexTheme
{
    /// <summary>
    /// Gets or sets the configuration for the light theme.
    /// </summary>
    public ThemeConfigLight Light { get; set; }

    /// <summary>
    /// Gets or sets the configuration for the dark theme.
    /// </summary>
    public ThemeConfigDark Dark { get; set; }

    /// <summary>
    /// Gets or sets the default theme type.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="ThemeType.Light" />.
    /// </remarks>
    public ThemeType DefaultTheme { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="LumexTheme" />.
    /// </summary>
    public LumexTheme()
    {
        Light = new();
        Dark = new();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="LumexTheme"/> with a specified default theme.
    /// </summary>
    /// <param name="defaultTheme">The default theme to be set.</param>
    public LumexTheme( ThemeType defaultTheme ) : this()
    {
        DefaultTheme = defaultTheme;
    }
}
