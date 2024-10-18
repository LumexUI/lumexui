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
    /// Gets or sets the border radius.
    /// </summary>
    public BaseScale Radius { get; set; }

    /// <summary>
    /// Gets or sets the shadows.
    /// </summary>
    public BaseScale Shadow { get; set; }

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

        Radius = new BaseScale()
        {
            Sm = ".375rem",
            Md = ".625rem",
            Lg = ".875rem"
        };

        Shadow = new BaseScale()
        {
            Sm = "0px 0px 5px 0px rgba(0,0,0,.02),0px 2px 10px 0px rgba(0,0,0,.06),0px 0px 1px 0px rgba(0,0,0,.15)",
            Md = "0px 0px 15px 0px rgba(0,0,0,.03),0px 2px 30px 0px rgba(0,0,0,.08),0px 0px 1px 0px rgba(0,0,0,.15)",
            Lg = "0px 0px 20px 0px rgba(0,0,0,.04),0px 2px 50px 0px rgba(0,0,0,.1),0px 0px 1px 0px rgba(0,0,0,.15)"
        };
    }
}
