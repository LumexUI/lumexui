// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

namespace LumexUI.Theme;

/// <summary>
/// Represents a set of theme colors.
/// </summary>
public record ThemeColors : BaseColors
{
    /// <summary>
    /// Gets or sets the default color scale.
    /// </summary>
    public ColorScale Default { get; set; }

    /// <summary>
    /// Gets or sets the primary color scale.
    /// </summary>
    public ColorScale Primary { get; set; }

    /// <summary>
    /// Gets or sets the secondary color scale.
    /// </summary>
    public ColorScale Secondary { get; set; }

    /// <summary>
    /// Gets or sets the success color scale.
    /// </summary>
    public ColorScale Success { get; set; }

    /// <summary>
    /// Gets or sets the warning color scale.
    /// </summary>
    public ColorScale Warning { get; set; }

    /// <summary>
    /// Gets or sets the danger color scale.
    /// </summary>
    public ColorScale Danger { get; set; }

    /// <summary>
    /// Gets or sets the info color scale.
    /// </summary>
    public ColorScale Info { get; set; }
}
