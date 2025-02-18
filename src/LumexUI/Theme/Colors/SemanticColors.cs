// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using static LumexUI.Utilities.ColorUtils;

namespace LumexUI.Theme;

/// <summary>
/// Provides semantic color definitions used across themes.
/// </summary>
public static class SemanticColors
{
    private const string Default = "default";
    private const string Foreground = "foreground";

    /// <summary>
    /// Represents the theme colors for the light theme.
    /// </summary>
    public readonly static ThemeColors Light = new()
    {
        Background = [
            new( Default, Colors.White )
        ],
        Foreground = [
            .. Colors.Zinc,
            new( Default, Colors.Zinc["700"] ),
        ],
        Overlay = [
            new( Default, Colors.Black )
        ],
        Focus = [
            new( Default, Colors.Blue["500"] )
        ],
        Divider = [
            new( Default, Colors.Zinc["900"] )
        ],
        Surface1 = [
            new( Default, Colors.White ),
            new( Foreground, Colors.Zinc["900"] )
        ],
        Surface2 = [
            new( Default, Colors.Zinc["100"] ),
            new( Foreground, Colors.Zinc["800"] )
        ],
        Surface3 = [
            new( Default, Colors.Zinc["200"] ),
            new( Foreground, Colors.Zinc["700"] )
        ],
        Default = [
            .. Colors.Zinc,
            new( Default, Colors.Zinc["300"] ),
            new( Foreground, GetReadableColor( Colors.Zinc["300"] ) )
        ],
        Primary = [
            .. Colors.Blue,
            new( Default, Colors.Blue["500"] ),
            new( Foreground, GetReadableColor( Colors.Blue["500"] ) )
        ],
        Secondary = [
            .. Colors.Violet,
            new( Default, Colors.Violet["500"] ),
            new( Foreground, GetReadableColor( Colors.Violet["500"] ) )
        ],
        Success = [
            .. Colors.Green,
            new( Default, Colors.Green["500"] ),
            new( Foreground, GetReadableColor( Colors.Green["500"] ) )
        ],
        Warning = [
            .. Colors.Amber,
            new( Default, Colors.Amber["500"] ),
            new( Foreground, GetReadableColor( Colors.Amber["500"] ) )
        ],
        Danger = [
            .. Colors.Rose,
            new( Default, Colors.Rose["500"] ),
            new( Foreground, GetReadableColor( Colors.Rose["500"] ) )
        ],
        Info = [
            .. Colors.Sky,
            new( Default, Colors.Sky["500"] ),
            new( Foreground, GetReadableColor( Colors.Sky["500"] ) )
        ]
    };

    /// <summary>
    /// Represents the theme colors for the dark theme.
    /// </summary>
    public readonly static ThemeColors Dark = new()
    {
        Background = [
            new( Default, Colors.Black )
        ],
        Foreground = [
            .. Colors.ReverseColorValues( Colors.Zinc ),
            new( Default, Colors.Zinc["200"] ),
        ],                              
        Overlay = [
            new( Default, Colors.Black )
        ],
        Focus = [
            new( Default, Colors.Blue["500"] )
        ],
        Divider = [
            new( Default, Colors.Zinc["50"] )
        ],
        Surface1 = [
            new( Default, Colors.Zinc["900"] ),
            new( Foreground, Colors.Zinc["50"] )
        ],
        Surface2 = [
            new( Default, Colors.Zinc["800"] ),
            new( Foreground, Colors.Zinc["100"] )
        ],
        Surface3 = [
            new( Default, Colors.Zinc["700"] ),
            new( Foreground, Colors.Zinc["200"] )
        ],
        Default = [
            .. Colors.ReverseColorValues( Colors.Zinc ),
            new( Default, Colors.Zinc["300"] ),
            new( Foreground, GetReadableColor( Colors.Zinc["300"] ) )
        ],
        Primary = [
            .. Colors.ReverseColorValues( Colors.Blue ),
            new( Default, Colors.Blue["500"] ),
            new( Foreground, GetReadableColor( Colors.Blue["500"] ) )
        ],
        Secondary = [
            .. Colors.ReverseColorValues( Colors.Violet ),
            new( Default, Colors.Violet["500"] ),
            new( Foreground, GetReadableColor( Colors.Violet["500"] ) )
        ],
        Success = [
            .. Colors.ReverseColorValues( Colors.Green ),
            new( Default, Colors.Green["500"] ),
            new( Foreground, GetReadableColor( Colors.Green["500"] ) )
        ],
        Warning = [
            .. Colors.ReverseColorValues( Colors.Amber ),
            new( Default, Colors.Amber["500"] ),
            new( Foreground, GetReadableColor( Colors.Amber["500"] ) )
        ],
        Danger = [
            .. Colors.ReverseColorValues( Colors.Rose ),
            new( Default, Colors.Rose["500"] ),
            new( Foreground, GetReadableColor( Colors.Rose["500"] ) )
        ],
        Info = [
            .. Colors.ReverseColorValues( Colors.Sky ),
            new( Default, Colors.Sky["500"] ),
            new( Foreground, GetReadableColor( Colors.Sky["500"] ) )
        ]
    };
}
