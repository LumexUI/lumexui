// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Globalization;
using System.Text;

using LumexUI.Extensions;
using LumexUI.Theme;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component that provides theme configuration.
/// </summary>
public partial class LumexThemeProvider : ComponentBase
{
	private const string Prefix = "lumex";

	/// <summary>
	/// Gets or sets the configuration of the theme.
	/// </summary>
	[Parameter] public LumexTheme Theme { get; set; }

	/// <summary>
	/// Initializes a new instance of the <see cref="LumexThemeProvider"/>.
	/// </summary>
	public LumexThemeProvider()
	{
		Theme = new();
	}

	private string GenerateTheme<TColors>( ThemeConfig<TColors> theme ) where TColors : ThemeColors, new()
	{
		var cssSelector = $"[data-theme={theme.Type.ToDescription()}]";

		if( theme.Type == Theme.DefaultTheme )
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
				var scaleKey = scale.Key != "default" 
					? $"{color.Key}-{scale.Key}"
					: $"{color.Key}";

				sb.AppendLine( $"--{Prefix}-{scaleKey}: {scale.Value};" );
			}
		}

		// Layout
		sb.AppendLine( $"--{Prefix}-font-sans: {theme.Layout.FontFamily?.Sans};" );
		sb.AppendLine( $"--{Prefix}-font-mono: {theme.Layout.FontFamily?.Mono};" );
		sb.AppendLine( $"--{Prefix}-font-size-tiny: {theme.Layout.FontSize.Xs};" );
		sb.AppendLine( $"--{Prefix}-font-size-small: {theme.Layout.FontSize.Sm};" );
		sb.AppendLine( $"--{Prefix}-font-size-medium: {theme.Layout.FontSize.Md};" );
		sb.AppendLine( $"--{Prefix}-font-size-large: {theme.Layout.FontSize.Lg};" );
		sb.AppendLine( $"--{Prefix}-line-height-tiny: {theme.Layout.LineHeight.Xs};" );
		sb.AppendLine( $"--{Prefix}-line-height-small: {theme.Layout.LineHeight.Sm};" );
		sb.AppendLine( $"--{Prefix}-line-height-medium: {theme.Layout.LineHeight.Md};" );
		sb.AppendLine( $"--{Prefix}-line-height-large: {theme.Layout.LineHeight.Lg};" );
		sb.AppendLine( $"--{Prefix}-radius-small: {theme.Layout.Radius.Sm};" );
		sb.AppendLine( $"--{Prefix}-radius-medium: {theme.Layout.Radius.Md};" );
		sb.AppendLine( $"--{Prefix}-radius-large: {theme.Layout.Radius.Lg};" );
		sb.AppendLine( $"--{Prefix}-shadow-small: {theme.Layout.Shadow.Sm};" );
		sb.AppendLine( $"--{Prefix}-shadow-medium: {theme.Layout.Shadow.Md};" );
		sb.AppendLine( $"--{Prefix}-shadow-large: {theme.Layout.Shadow.Lg};" );
		sb.AppendLine( $"--{Prefix}-opacity-divider: {theme.Layout.DividerOpacity * 100}%;" );
		sb.AppendLine( $"--{Prefix}-opacity-disabled: {theme.Layout.DisabledOpacity * 100}%;" );
		sb.AppendLine( $"--{Prefix}-opacity-focus: {theme.Layout.FocusOpacity * 100}%;" );
		sb.AppendLine( $"--{Prefix}-opacity-hover: {theme.Layout.HoverOpacity * 100}%;" );

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
			["surface1"] = colors.Surface1,
			["surface2"] = colors.Surface2,
			["surface3"] = colors.Surface3,
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