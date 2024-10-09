// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

namespace LumexUI.Theme;

/// <summary>
/// Represents a base class for defining size scale settings.
/// </summary>
public record BaseScale
{
    /// <summary>
    /// Gets or sets the small size value.
    /// </summary>
    public string? Sm { get; set; }

    /// <summary>
    /// Gets or sets the medium size value.
    /// </summary>
    public string? Md { get; set; }

    /// <summary>
    /// Gets or sets the large size value.
    /// </summary>
    public string? Lg { get; set; }
}
