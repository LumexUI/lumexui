// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;

namespace LumexUI.Theme;

/// <summary>
/// Represents the configuration settings for a theme.
/// </summary>
/// <typeparam name="TColors">The type of colors for the theme.</typeparam>
public abstract record ThemeConfig<TColors> where TColors : ThemeColors, new()
{
    /// <summary>
    /// Gets the colors for the theme.
    /// </summary>
    public TColors Colors { get; init; }

    /// <summary>
    /// Gets the layout configuration for the theme.
    /// </summary>
    public LayoutConfig Layout { get; init; }

    internal ThemeType Type { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ThemeConfig{TColors}" />.
    /// </summary>
    /// <param name="type">The type of the theme (e.g., light or dark).</param>
    internal ThemeConfig( ThemeType type ) : base()
    {
        Type = type;
        Colors = new TColors();
        Layout = new LayoutConfig();
    }
}

/// <summary>
/// Represents the configuration settings for a light theme.
/// </summary>
public record ThemeConfigLight : ThemeConfig<ThemeColorsLight>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ThemeConfigLight" />.
    /// </summary>
    public ThemeConfigLight() : base( ThemeType.Light ) { }
}

/// <summary>
/// Represents the configuration settings for a dark theme.
/// </summary>
public record ThemeConfigDark : ThemeConfig<ThemeColorsDark>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ThemeConfigDark" />.
    /// </summary>
    public ThemeConfigDark() : base( ThemeType.Dark ) { }
}
