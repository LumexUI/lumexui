// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

namespace LumexUI.Theme;

/// <summary>
/// Represents a set of base colors used in a theme.
/// </summary>
public record BaseColors
{
    /// <summary>
    /// Gets or sets the color scale for the background.
    /// </summary>
    public ColorScale Background { get; set; } = [];

    /// <summary>
    /// Gets or sets the color scale for the foreground.
    /// </summary>
    public ColorScale Foreground { get; set; } = [];

    /// <summary>
    /// Gets or sets the color scale for the overlay.
    /// </summary>
    public ColorScale Overlay { get; set; } = [];

    /// <summary>
    /// Gets or sets the color scale for the divider and borders.
    /// </summary>
    public ColorScale Divider { get; set; } = [];

    /// <summary>
    /// Gets or sets the color scale for the focus state.
    /// </summary>
    public ColorScale Focus { get; set; } = [];

    /// <summary>
    /// Gets or sets the color scale for the background of components like card, accordion, popover and etc.
    /// </summary>
    public ColorScale Surface1 { get; set; } = [];

    /// <summary>
    /// Gets or sets the color scale for the background of components like card, accordion, popover and etc.
    /// </summary>
    public ColorScale Surface2 { get; set; } = [];

    /// <summary>
    /// Gets or sets the color scale for the background of components like card, accordion, popover and etc.
    /// </summary>
    public ColorScale Surface3 { get; set; } = [];
}
