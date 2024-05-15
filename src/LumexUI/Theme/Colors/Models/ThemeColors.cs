// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

namespace LumexUI.Theme;

public record ThemeColors : BaseColors
{
    public ColorScale Default { get; set; }
    public ColorScale Primary { get; set; }
    public ColorScale Secondary { get; set; }
    public ColorScale Success { get; set; }
    public ColorScale Warning { get; set; }
    public ColorScale Danger { get; set; }
    public ColorScale Info { get; set; }
}
