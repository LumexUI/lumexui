// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Globalization;
using System.Text;
using System.Threading;

using AngleSharp.Html.Dom;

namespace LumexUI.Tests.Components;

public class ThemeProviderTests : TestContext
{
    [Fact]
    public void ThemeProvider_ShouldRenderCorrectly()
    {
        var action = () => RenderComponent<LumexThemeProvider>();

        action.Should().NotThrow();
    }

    [Theory]
    [InlineData( "en-US" )]
    [InlineData( "de-DE" )]
    [InlineData( "he-IL" )]
    [InlineData( "ar-ER" )]
    public void ThemeProvider_DifferentCultures_ShouldRenderCorrectly( string cultureName )
    {
        var culture = new CultureInfo( cultureName, false );

        CultureInfo.CurrentCulture = culture;
        CultureInfo.CurrentUICulture = culture;

        var cut = RenderComponent<LumexThemeProvider>();
        var styleNodes = cut.Nodes.OfType<IHtmlStyleElement>().ToArray();

        var expectedCssVars = new StringBuilder().AppendJoin( "\n",
            ":root, [data-theme=light] {",
			"--lumex-background: #fff;",
			"--lumex-foreground-50: oklch(0.985 0 0);",
			"--lumex-foreground-100: oklch(0.967 0.001 286.375);",
			"--lumex-foreground-200: oklch(0.92 0.004 286.32);",
			"--lumex-foreground-300: oklch(0.871 0.006 286.286);",
			"--lumex-foreground-400: oklch(0.705 0.015 286.067);",
			"--lumex-foreground-500: oklch(0.552 0.016 285.938);",
			"--lumex-foreground-600: oklch(0.442 0.017 285.786);",
			"--lumex-foreground-700: oklch(0.37 0.013 285.805);",
			"--lumex-foreground-800: oklch(0.274 0.006 286.033);",
			"--lumex-foreground-900: oklch(0.21 0.006 285.885);",
			"--lumex-foreground-950: oklch(0.141 0.005 285.823);",
			"--lumex-foreground: oklch(0.37 0.013 285.805);",
			"--lumex-overlay: #000;",
			"--lumex-focus: oklch(0.623 0.214 259.815);",
			"--lumex-divider: oklch(0.21 0.006 285.885);",
			"--lumex-surface1: #fff;",
			"--lumex-surface1-foreground: oklch(0.21 0.006 285.885);",
			"--lumex-surface2: oklch(0.967 0.001 286.375);",
			"--lumex-surface2-foreground: oklch(0.274 0.006 286.033);",
			"--lumex-surface3: oklch(0.92 0.004 286.32);",
			"--lumex-surface3-foreground: oklch(0.37 0.013 285.805);",
			"--lumex-default-50: oklch(0.985 0 0);",
			"--lumex-default-100: oklch(0.967 0.001 286.375);",
			"--lumex-default-200: oklch(0.92 0.004 286.32);",
			"--lumex-default-300: oklch(0.871 0.006 286.286);",
			"--lumex-default-400: oklch(0.705 0.015 286.067);",
			"--lumex-default-500: oklch(0.552 0.016 285.938);",
			"--lumex-default-600: oklch(0.442 0.017 285.786);",
			"--lumex-default-700: oklch(0.37 0.013 285.805);",
			"--lumex-default-800: oklch(0.274 0.006 286.033);",
			"--lumex-default-900: oklch(0.21 0.006 285.885);",
			"--lumex-default-950: oklch(0.141 0.005 285.823);",
			"--lumex-default: oklch(0.871 0.006 286.286);",
			"--lumex-default-foreground: #000;",
			"--lumex-primary-50: oklch(0.97 0.014 254.604);",
			"--lumex-primary-100: oklch(0.932 0.032 255.585);",
			"--lumex-primary-200: oklch(0.882 0.059 254.128);",
			"--lumex-primary-300: oklch(0.809 0.105 251.813);",
			"--lumex-primary-400: oklch(0.707 0.165 254.624);",
			"--lumex-primary-500: oklch(0.623 0.214 259.815);",
			"--lumex-primary-600: oklch(0.546 0.245 262.881);",
			"--lumex-primary-700: oklch(0.488 0.243 264.376);",
			"--lumex-primary-800: oklch(0.424 0.199 265.638);",
			"--lumex-primary-900: oklch(0.379 0.146 265.522);",
			"--lumex-primary-950: oklch(0.282 0.091 267.935);",
			"--lumex-primary: oklch(0.623 0.214 259.815);",
			"--lumex-primary-foreground: #fff;",
			"--lumex-secondary-50: oklch(0.969 0.016 293.756);",
			"--lumex-secondary-100: oklch(0.943 0.029 294.588);",
			"--lumex-secondary-200: oklch(0.894 0.057 293.283);",
			"--lumex-secondary-300: oklch(0.811 0.111 293.571);",
			"--lumex-secondary-400: oklch(0.702 0.183 293.541);",
			"--lumex-secondary-500: oklch(0.606 0.25 292.717);",
			"--lumex-secondary-600: oklch(0.541 0.281 293.009);",
			"--lumex-secondary-700: oklch(0.491 0.27 292.581);",
			"--lumex-secondary-800: oklch(0.432 0.232 292.759);",
			"--lumex-secondary-900: oklch(0.38 0.189 293.745);",
			"--lumex-secondary-950: oklch(0.283 0.141 291.089);",
			"--lumex-secondary: oklch(0.606 0.25 292.717);",
			"--lumex-secondary-foreground: #fff;",
			"--lumex-success-50: oklch(0.982 0.018 155.826);",
			"--lumex-success-100: oklch(0.962 0.044 156.743);",
			"--lumex-success-200: oklch(0.925 0.084 155.995);",
			"--lumex-success-300: oklch(0.871 0.15 154.449);",
			"--lumex-success-400: oklch(0.792 0.209 151.711);",
			"--lumex-success-500: oklch(0.723 0.219 149.579);",
			"--lumex-success-600: oklch(0.627 0.194 149.214);",
			"--lumex-success-700: oklch(0.527 0.154 150.069);",
			"--lumex-success-800: oklch(0.448 0.119 151.328);",
			"--lumex-success-900: oklch(0.393 0.095 152.535);",
			"--lumex-success-950: oklch(0.266 0.065 152.934);",
			"--lumex-success: oklch(0.723 0.219 149.579);",
			"--lumex-success-foreground: #000;",
			"--lumex-warning-50: oklch(0.987 0.022 95.277);",
			"--lumex-warning-100: oklch(0.962 0.059 95.617);",
			"--lumex-warning-200: oklch(0.924 0.12 95.746);",
			"--lumex-warning-300: oklch(0.879 0.169 91.605);",
			"--lumex-warning-400: oklch(0.828 0.189 84.429);",
			"--lumex-warning-500: oklch(0.769 0.188 70.08);",
			"--lumex-warning-600: oklch(0.666 0.179 58.318);",
			"--lumex-warning-700: oklch(0.555 0.163 48.998);",
			"--lumex-warning-800: oklch(0.473 0.137 46.201);",
			"--lumex-warning-900: oklch(0.414 0.112 45.904);",
			"--lumex-warning-950: oklch(0.279 0.077 45.635);",
			"--lumex-warning: oklch(0.769 0.188 70.08);",
			"--lumex-warning-foreground: #000;",
			"--lumex-danger-50: oklch(0.969 0.015 12.422);",
			"--lumex-danger-100: oklch(0.941 0.03 12.58);",
			"--lumex-danger-200: oklch(0.892 0.058 10.001);",
			"--lumex-danger-300: oklch(0.81 0.117 11.638);",
			"--lumex-danger-400: oklch(0.712 0.194 13.428);",
			"--lumex-danger-500: oklch(0.645 0.246 16.439);",
			"--lumex-danger-600: oklch(0.586 0.253 17.585);",
			"--lumex-danger-700: oklch(0.514 0.222 16.935);",
			"--lumex-danger-800: oklch(0.455 0.188 13.697);",
			"--lumex-danger-900: oklch(0.41 0.159 10.272);",
			"--lumex-danger-950: oklch(0.271 0.105 12.094);",
			"--lumex-danger: oklch(0.645 0.246 16.439);",
			"--lumex-danger-foreground: #fff;",
			"--lumex-info-50: oklch(0.977 0.013 236.62);",
			"--lumex-info-100: oklch(0.951 0.026 236.824);",
			"--lumex-info-200: oklch(0.901 0.058 230.902);",
			"--lumex-info-300: oklch(0.828 0.111 230.318);",
			"--lumex-info-400: oklch(0.746 0.16 232.661);",
			"--lumex-info-500: oklch(0.685 0.169 237.323);",
			"--lumex-info-600: oklch(0.588 0.158 241.966);",
			"--lumex-info-700: oklch(0.5 0.134 242.749);",
			"--lumex-info-800: oklch(0.443 0.11 240.79);",
			"--lumex-info-900: oklch(0.391 0.09 240.876);",
			"--lumex-info-950: oklch(0.293 0.066 243.157);",
			"--lumex-info: oklch(0.685 0.169 237.323);",
			"--lumex-info-foreground: #000;",
			"--lumex-font-sans: ;",
			"--lumex-font-mono: ;",
			"--lumex-font-size-tiny: .75rem;",
			"--lumex-font-size-small: .875rem;",
			"--lumex-font-size-medium: 1rem;",
			"--lumex-font-size-large: 1.125rem;",
			"--lumex-line-height-tiny: 1rem;",
			"--lumex-line-height-small: 1.25rem;",
			"--lumex-line-height-medium: 1.5rem;",
			"--lumex-line-height-large: 1.75rem;",
			"--lumex-radius-small: .375rem;",
			"--lumex-radius-medium: .625rem;",
			"--lumex-radius-large: .875rem;",
			"--lumex-shadow-small: 0px 0px 5px 0px rgba(0,0,0,.02),0px 2px 10px 0px rgba(0,0,0,.06),0px 0px 1px 0px rgba(0,0,0,.15);",
			"--lumex-shadow-medium: 0px 0px 15px 0px rgba(0,0,0,.03),0px 2px 30px 0px rgba(0,0,0,.08),0px 0px 1px 0px rgba(0,0,0,.15);",
			"--lumex-shadow-large: 0px 0px 20px 0px rgba(0,0,0,.04),0px 2px 50px 0px rgba(0,0,0,.1),0px 0px 1px 0px rgba(0,0,0,.15);",
			"--lumex-opacity-divider: 15%;",
			"--lumex-opacity-disabled: 60%;",
			"--lumex-opacity-focus: 70%;",
			"--lumex-opacity-hover: 80%;",
		"}"
        ).ToString();

        styleNodes[0].InnerHtml.Trim().Should().BeEquivalentTo( expectedCssVars );
    }
}