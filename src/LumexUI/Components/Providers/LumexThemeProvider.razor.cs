// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Text;

using LumexUI.Theme;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

public partial class LumexThemeProvider : LumexComponentBase
{
    private const string Prefix = "lumex";

    /// <summary>
    /// Gets or sets the configuration of the theme.
    /// </summary>
    [Parameter] public LumexThemeConfig? Config { get; set; }

    protected override void OnInitialized()
    {
        Config ??= new();
    }

    private string? GenerateTheme( ThemeConfig theme )
    {
        if( Config is null )
        {
            return null;
        }

        var cssSelector = $@"[data-theme=""{theme.Type.ToDescription()}""]";

        if( theme.Type == Config.DefaultTheme )
        {
            cssSelector = $":root, {cssSelector}";
        }

        var sb = new StringBuilder();
        sb.AppendLine( $"{cssSelector} {{" );

        // Colors
        var themeColors = GetThemeColorsDict( theme.Colors );

        foreach( var color in themeColors )
        {
            foreach( var scale in color.Value )
            {
                var scaleKey = scale.Key == "default" ? "" : $"-{scale.Key}";
                var scaleValue = !string.IsNullOrWhiteSpace( scale.Value ) 
                    ? ColorUtils.HexToHsl( scale.Value ) 
                    : null;

                sb.AppendLine( $"--{Prefix}-{color.Key}{scaleKey}: {scaleValue};" );
            }
        }

        // Layout
        sb.AppendLine( $"--{Prefix}-divider-opacity: {theme.Layout.DividerOpacity};" );
        sb.AppendLine( $"--{Prefix}-disabled-opacity: {theme.Layout.DisabledOpacity};" );
        sb.AppendLine( $"--{Prefix}-focus-opacity: {theme.Layout.FocusOpacity};" );
        sb.AppendLine( $"--{Prefix}-hover-opacity: {theme.Layout.HoverOpacity};" );

        sb.AppendLine( "}" );
        return sb.ToString();
    }

    private static Dictionary<string, ColorScale> GetThemeColorsDict( ThemeColors colors )
    {
        return new()
        {
            ["background"] = colors.Background,
            ["foreground"] = colors.Foreground,
            ["overlay"] = colors.Overlay,
            ["focus"] = colors.Focus,
            ["divider"] = colors.Divider,
            ["default"] = colors.Default,
            ["primary"] = colors.Primary,
            ["secondary"] = colors.Secondary,
            ["success"] = colors.Success,
            ["warning"] = colors.Warning,
            ["danger"] = colors.Danger,
            ["info"] = colors.Info,
        };
    }
}