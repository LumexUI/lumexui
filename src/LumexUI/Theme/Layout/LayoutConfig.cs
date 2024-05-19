// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

namespace LumexUI.Theme;

/// <summary>
/// Represents the layout settings for a theme.
/// </summary>
public record LayoutConfig
{
    /// <summary>
    /// Gets or sets the font sizes.
    /// </summary>
    public FontScale FontSize { get; set; }

    /// <summary>
    /// Gets or sets the line heights.
    /// </summary>
    public FontScale LineHeight { get; set; }

    /// <summary>
    /// Gets or sets the font family.
    /// </summary>
    public FontFamily? FontFamily { get; set; }

    /// <summary>
    /// Gets or sets the opacity for disabled elements.
    /// </summary>
    public double DisabledOpacity { get; set; }

    /// <summary>
    /// Gets or sets the opacity for focused elements.
    /// </summary>
    public double FocusOpacity { get; set; }

    /// <summary>
    /// Gets or sets the opacity for hovered elements.
    /// </summary>
    public double HoverOpacity { get; set; }

    /// <summary>
    /// Gets or sets the opacity for dividers.
    /// </summary>
    public double DividerOpacity { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="LayoutConfig"/> with default settings.
    /// </summary>
    public LayoutConfig()
    {
        DisabledOpacity = .6;
        FocusOpacity = .7;
        HoverOpacity = .8;
        DividerOpacity = .15;

        FontSize = new FontScale()
        {
            Xs = ".75rem",
            Sm = ".875rem",
            Md = "1rem",
            Lg = "1.125rem"
        };
        LineHeight = new FontScale()
        {
            Xs = "1rem",
            Sm = "1.25rem",
            Md = "1.5rem",
            Lg = "1.75rem"
        };
    }
}
