// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

namespace LumexUI.Theme;

/// <summary>
/// Represents the font family settings.
/// </summary>
[ExcludeFromCodeCoverage]
public record FontFamily
{
    /// <summary>
    /// Gets or sets the sans-serif font family.
    /// </summary>
    public string? Sans { get; set; }

    /// <summary>
    /// Gets or sets the monospaced font family.
    /// </summary>
    public string? Mono { get; set; }
}