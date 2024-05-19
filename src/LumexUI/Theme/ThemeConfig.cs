// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;

namespace LumexUI.Theme;

/// <summary>
/// Represents the configuration settings for a theme.
/// </summary>
/// <param name="Colors">The colors associated with the theme.</param>
/// <param name="Layout">The layout settings for the theme.</param>
public abstract record ThemeConfig( ThemeColors Colors, LayoutConfig Layout )
{
    internal ThemeType Type { get; init; }
}

/// <summary>
/// Represents the configuration settings for a light theme.
/// </summary>
public record ThemeConfigLight : ThemeConfig
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ThemeConfigLight" />.
    /// </summary>
    public ThemeConfigLight() : base( new ThemeColorsLight(), new LayoutConfig() ) 
    {
        Type = ThemeType.Light;
    }
}

/// <summary>
/// Represents the configuration settings for a dark theme.
/// </summary>
public record ThemeConfigDark : ThemeConfig
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ThemeConfigDark" />.
    /// </summary>
    public ThemeConfigDark() : base( new ThemeColorsDark(), new LayoutConfig() ) 
    { 
        Type = ThemeType.Dark;
    }
}
