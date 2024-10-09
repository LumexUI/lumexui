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
    public ColorScale Default { get; set; } = [];

    /// <summary>
    /// Gets or sets the primary color scale.
    /// </summary>
    public ColorScale Primary { get; set; } = [];

    /// <summary>
    /// Gets or sets the secondary color scale.
    /// </summary>
    public ColorScale Secondary { get; set; } = [];

    /// <summary>
    /// Gets or sets the success color scale.
    /// </summary>
    public ColorScale Success { get; set; } = [];

    /// <summary>
    /// Gets or sets the warning color scale.
    /// </summary>
    public ColorScale Warning { get; set; } = [];

    /// <summary>
    /// Gets or sets the danger color scale.
    /// </summary>
    public ColorScale Danger { get; set; } = [];

    /// <summary>
    /// Gets or sets the info color scale.
    /// </summary>
    public ColorScale Info { get; set; } = [];
}

/// <summary>
/// Represents a set of light theme default colors.
/// </summary>
public record ThemeColorsLight : ThemeColors
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ThemeColorsLight" />.
    /// </summary>
    public ThemeColorsLight()
    {
        Background = SemanticColors.Light.Background;
        Foreground = SemanticColors.Light.Foreground;
        Overlay = SemanticColors.Light.Overlay;
        Divider = SemanticColors.Light.Divider;
        Focus = SemanticColors.Light.Focus;
        Content1 = SemanticColors.Light.Content1;
        Content2 = SemanticColors.Light.Content2;
        Content3 = SemanticColors.Light.Content3;
        Default = SemanticColors.Light.Default;
        Primary = SemanticColors.Light.Primary;
        Secondary = SemanticColors.Light.Secondary;
        Success = SemanticColors.Light.Success;
        Warning = SemanticColors.Light.Warning;
        Danger = SemanticColors.Light.Danger;
        Info = SemanticColors.Light.Info;
    }
}

/// <summary>
/// Represents a set of dark theme default colors.
/// </summary>
public record ThemeColorsDark : ThemeColors
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ThemeColorsDark" />.
    /// </summary>
    public ThemeColorsDark()
    {
        Background = SemanticColors.Dark.Background;
        Foreground = SemanticColors.Dark.Foreground;
        Overlay = SemanticColors.Dark.Overlay;
        Divider = SemanticColors.Dark.Divider;
        Focus = SemanticColors.Dark.Focus;
        Content1 = SemanticColors.Dark.Content1;
        Content2 = SemanticColors.Dark.Content2;
        Content3 = SemanticColors.Dark.Content3;
        Default = SemanticColors.Dark.Default;
        Primary = SemanticColors.Dark.Primary;
        Secondary = SemanticColors.Dark.Secondary;
        Success = SemanticColors.Dark.Success;
        Warning = SemanticColors.Dark.Warning;
        Danger = SemanticColors.Dark.Danger;
        Info = SemanticColors.Dark.Info;
    }
}
