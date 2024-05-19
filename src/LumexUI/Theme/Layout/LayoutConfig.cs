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
/// <param name="DividerOpacity">The opacity value for borders and dividers.</param>
public readonly record struct LayoutConfig(
    double DisabledOpacity,
    double FocusOpacity,
    double HoverOpacity,
    double DividerOpacity
)
{
    public static LayoutConfig Default()
    {
        return new LayoutConfig(
            DisabledOpacity: .6,
            FocusOpacity: .7,
            HoverOpacity: .8,
            DividerOpacity: .15
        );
    }
}
