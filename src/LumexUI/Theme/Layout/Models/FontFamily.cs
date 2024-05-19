// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

namespace LumexUI.Theme;

[ExcludeFromCodeCoverage]
public record FontFamily
{
    public string? Sans { get; set; }
    public string? Mono { get; set; }
}