// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

namespace LumexUI.Theme;

/// <summary>
/// Represents the layout settings for a theme.
/// </summary>
/// <param name="DisabledOpacity">The opacity value for disabled elements.</param>
/// <param name="FocusOpacity">The opacity value for elements in focus.</param>
/// <param name="HoverOpacity">The opacity value for elements when hovered over.</param>
public readonly record struct LayoutConfig(
    double DisabledOpacity = .6,
    double FocusOpacity = .7,
    double HoverOpacity = .8
);
