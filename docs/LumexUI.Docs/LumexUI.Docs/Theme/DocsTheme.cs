using LumexUI.Common;
using LumexUI.Theme;

namespace LumexUI.Docs.Theme;

internal record DocsTheme : LumexTheme
{
    internal DocsTheme()
    {
        DefaultTheme = ThemeType.Light;

        // Typography
        var fontFamily = new FontFamily()
        {
            Sans = "Inter var",
            Mono = "Fira Code var"
        };

        // Light theme
        Light = new ThemeConfigLight()
        {
            Layout = new LayoutConfig()
            {
                FontFamily = fontFamily,
            }
        };
    }
}
