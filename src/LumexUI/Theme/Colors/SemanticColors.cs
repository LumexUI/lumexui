// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using static LumexUI.Utilities.ColorUtils;

namespace LumexUI.Theme;

internal static class SemanticColors
{
    private const string Default = "default";
    private const string Foreground = "foreground";

    public static ThemeColors Light => new()
    {
        Background = [
            new( Default, Colors.White )
        ],
        Foreground = [
            .. Colors.Gray,
            new( Default, Colors.Gray["700"] ),
        ],
        Overlay = [
            new( Default, Colors.Black )
        ],
        Focus = [
            new( Default, Colors.Blue["500"] )
        ],
        Divider = [
            new( Default, Colors.Black )
        ],
        Content1 = [
            new( Default, Colors.White ),
            new( Foreground, Colors.Gray["900"] )
        ],
        Content2 = [
            new( Default, Colors.Gray["100"] ),
            new( Foreground, Colors.Gray["800"] )
        ],
        Content3 = [
            new( Default, Colors.Gray["200"] ),
            new( Foreground, Colors.Gray["700"] )
        ],
        Default = [
            .. Colors.Gray,
            new( Default, Colors.Gray["200"] ),
            new( Foreground, GetReadableColor( Colors.Gray["200"] ) )
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
            .. Colors.Yellow,
            new( Default, Colors.Yellow["500"] ),
            new( Foreground, GetReadableColor( Colors.Yellow["500"] ) )
        ],
        Danger = [
            .. Colors.Rose,
            new( Default, Colors.Rose["500"] ),
            new( Foreground, GetReadableColor( Colors.Rose["500"] ) )
        ],
        Info = [
            .. Colors.LightBlue,
            new( Default, Colors.LightBlue["500"] ),
            new( Foreground, GetReadableColor( Colors.LightBlue["500"] ) )
        ]
    };

    public static ThemeColors Dark => new()
    {
        Background = [
            new( Default, Colors.Black )
        ],
        Foreground = [
            .. Colors.ReverseColorValues( Colors.Gray ),
            new( Default, Colors.Gray["300"] ),
        ],
        Overlay = [
            new( Default, Colors.Black )
        ],
        Focus = [
            new( Default, Colors.Blue["500"] )
        ],
        Divider = [
            new( Default, Colors.White )
        ],
        Content1 = [
            new( Default, Colors.Gray["900"] ),
            new( Foreground, Colors.Gray["50"] )
        ],
        Content2 = [
            new( Default, Colors.Gray["800"] ),
            new( Foreground, Colors.Gray["100"] )
        ],
        Content3 = [
            new( Default, Colors.Gray["700"] ),
            new( Foreground, Colors.Gray["200"] )
        ],
        Default = [
            .. Colors.ReverseColorValues( Colors.Gray ),
            new( Default, Colors.Gray["300"] ),
            new( Foreground, GetReadableColor( Colors.Gray["300"] ) )
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
            .. Colors.ReverseColorValues( Colors.Yellow ),
            new( Default, Colors.Yellow["500"] ),
            new( Foreground, GetReadableColor( Colors.Yellow["500"] ) )
        ],
        Danger = [
            .. Colors.ReverseColorValues( Colors.Rose ),
            new( Default, Colors.Rose["500"] ),
            new( Foreground, GetReadableColor( Colors.Rose["500"] ) )
        ],
        Info = [
            .. Colors.ReverseColorValues( Colors.LightBlue ),
            new( Default, Colors.LightBlue["500"] ),
            new( Foreground, GetReadableColor( Colors.LightBlue["500"] ) )
        ]
    };
}
