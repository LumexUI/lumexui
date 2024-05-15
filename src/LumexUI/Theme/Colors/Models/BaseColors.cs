// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

namespace LumexUI.Theme;

public record BaseColors
{
    public ColorScale Background { get; set; }
    public ColorScale Foreground { get; set; }
    public ColorScale Overlay { get; set; }
    public ColorScale Divider { get; set; }
    public ColorScale Focus { get; set; }
}
