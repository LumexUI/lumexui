// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Globalization;
using System.Text;

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
            "--lumex-background: 0 0% 100%;",
            "--lumex-foreground-50: 0 0% 98.04%;",
            "--lumex-foreground-100: 240 4.76% 95.88%;",
            "--lumex-foreground-200: 240 5.88% 90%;",
            "--lumex-foreground-300: 240 4.88% 83.92%;",
            "--lumex-foreground-400: 240 5.03% 64.9%;",
            "--lumex-foreground-500: 240 3.83% 46.08%;",
            "--lumex-foreground-600: 240 5.2% 33.92%;",
            "--lumex-foreground-700: 240 5.26% 26.08%;",
            "--lumex-foreground-800: 240 3.7% 15.88%;",
            "--lumex-foreground-900: 240 5.88% 10%;",
            "--lumex-foreground-950: 240 10% 3.92%;",
            "--lumex-foreground: 240 5.26% 26.08%;",
            "--lumex-overlay: 0 0% 0%;",
            "--lumex-focus: 217.22 91.22% 59.8%;",
            "--lumex-divider: 240 5.88% 10%;",
            "--lumex-surface1: 0 0% 100%;",
			"--lumex-surface1-foreground: 240 5.88% 10%;",
            "--lumex-surface2: 240 4.76% 95.88%;",
            "--lumex-surface2-foreground: 240 3.7% 15.88%;",
            "--lumex-surface3: 240 5.88% 90%;",
            "--lumex-surface3-foreground: 240 5.26% 26.08%;",
            "--lumex-default-50: 0 0% 98.04%;",
            "--lumex-default-100: 240 4.76% 95.88%;",
            "--lumex-default-200: 240 5.88% 90%;",
            "--lumex-default-300: 240 4.88% 83.92%;",
            "--lumex-default-400: 240 5.03% 64.9%;",
            "--lumex-default-500: 240 3.83% 46.08%;",
            "--lumex-default-600: 240 5.2% 33.92%;",
            "--lumex-default-700: 240 5.26% 26.08%;",
            "--lumex-default-800: 240 3.7% 15.88%;",
            "--lumex-default-900: 240 5.88% 10%;",
            "--lumex-default-950: 240 10% 3.92%;",
            "--lumex-default: 240 4.88% 83.92%;",
            "--lumex-default-foreground: 0 0% 0%;",
            "--lumex-primary-50: 213.75 100% 96.86%;",
            "--lumex-primary-100: 214.29 94.59% 92.75%;",
            "--lumex-primary-200: 213.33 96.92% 87.25%;",
            "--lumex-primary-300: 211.7 96.36% 78.43%;",
            "--lumex-primary-400: 213.12 93.9% 67.84%;",
            "--lumex-primary-500: 217.22 91.22% 59.8%;",
            "--lumex-primary-600: 221.21 83.19% 53.33%;",
            "--lumex-primary-700: 224.28 76.33% 48.04%;",
            "--lumex-primary-800: 225.93 70.73% 40.2%;",
            "--lumex-primary-900: 224.44 64.29% 32.94%;",
            "--lumex-primary-950: 226.23 57.01% 20.98%;",
            "--lumex-primary: 217.22 91.22% 59.8%;",
            "--lumex-primary-foreground: 0 0% 100%;",
            "--lumex-secondary-50: 250 100% 97.65%;",
            "--lumex-secondary-100: 251.43 91.3% 95.49%;",
            "--lumex-secondary-200: 250.5 95.24% 91.76%;",
            "--lumex-secondary-300: 252.5 94.74% 85.1%;",
            "--lumex-secondary-400: 255.14 91.74% 76.27%;",
            "--lumex-secondary-500: 258.31 89.53% 66.27%;",
            "--lumex-secondary-600: 262.12 83.26% 57.84%;",
            "--lumex-secondary-700: 263.39 69.96% 50.39%;",
            "--lumex-secondary-800: 263.36 69.3% 42.16%;",
            "--lumex-secondary-900: 263.5 67.42% 34.9%;",
            "--lumex-secondary-950: 261.18 72.65% 22.94%;",
            "--lumex-secondary: 258.31 89.53% 66.27%;",
            "--lumex-secondary-foreground: 0 0% 100%;",
            "--lumex-success-50: 138.46 76.47% 96.67%;",
            "--lumex-success-100: 140.62 84.21% 92.55%;",
            "--lumex-success-200: 141 78.95% 85.1%;",
            "--lumex-success-300: 141.71 76.64% 73.14%;",
            "--lumex-success-400: 141.89 69.16% 58.04%;",
            "--lumex-success-500: 142.09 70.56% 45.29%;",
            "--lumex-success-600: 142.13 76.22% 36.27%;",
            "--lumex-success-700: 142.43 71.81% 29.22%;",
            "--lumex-success-800: 142.78 64.23% 24.12%;",
            "--lumex-success-900: 143.81 61.17% 20.2%;",
            "--lumex-success-950: 144.88 80.39% 10%;",
            "--lumex-success: 142.09 70.56% 45.29%;",
            "--lumex-success-foreground: 0 0% 0%;",
            "--lumex-warning-50: 48 100% 96.08%;",
            "--lumex-warning-100: 48 96.49% 88.82%;",
            "--lumex-warning-200: 48 96.64% 76.67%;",
            "--lumex-warning-300: 45.94 96.69% 64.51%;",
            "--lumex-warning-400: 43.26 96.41% 56.27%;",
            "--lumex-warning-500: 37.69 92.13% 50.2%;",
            "--lumex-warning-600: 32.13 94.62% 43.73%;",
            "--lumex-warning-700: 25.96 90.48% 37.06%;",
            "--lumex-warning-800: 22.73 82.5% 31.37%;",
            "--lumex-warning-900: 21.71 77.78% 26.47%;",
            "--lumex-warning-950: 20.91 91.67% 14.12%;",
            "--lumex-warning: 37.69 92.13% 50.2%;",
            "--lumex-warning-foreground: 0 0% 0%;",
            "--lumex-danger-50: 355.71 100% 97.25%;",
            "--lumex-danger-100: 355.56 100% 94.71%;",
            "--lumex-danger-200: 352.65 96.08% 90%;",
            "--lumex-danger-300: 352.58 95.7% 81.76%;",
            "--lumex-danger-400: 351.3 94.52% 71.37%;",
            "--lumex-danger-500: 349.72 89.16% 60.2%;",
            "--lumex-danger-600: 346.84 77.17% 49.8%;",
            "--lumex-danger-700: 345.35 82.69% 40.78%;",
            "--lumex-danger-800: 343.4 79.66% 34.71%;",
            "--lumex-danger-900: 341.54 75.48% 30.39%;",
            "--lumex-danger-950: 343.1 87.65% 15.88%;",
            "--lumex-danger: 349.72 89.16% 60.2%;",
            "--lumex-danger-foreground: 0 0% 100%;",
            "--lumex-info-50: 204 100% 97.06%;",
            "--lumex-info-100: 204 93.75% 93.73%;",
            "--lumex-info-200: 200.6 94.37% 86.08%;",
            "--lumex-info-300: 199.37 95.49% 73.92%;",
            "--lumex-info-400: 198.44 93.2% 59.61%;",
            "--lumex-info-500: 198.63 88.66% 48.43%;",
            "--lumex-info-600: 200.41 98.01% 39.41%;",
            "--lumex-info-700: 201.27 96.34% 32.16%;",
            "--lumex-info-800: 200.95 90% 27.45%;",
            "--lumex-info-900: 202.04 80.33% 23.92%;",
            "--lumex-info-950: 204 80.25% 15.88%;",
            "--lumex-info: 198.63 88.66% 48.43%;",
            "--lumex-info-foreground: 0 0% 0%;",
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
            "--lumex-box-shadow-small: 0px 0px 5px 0px rgba(0,0,0,.02),0px 2px 10px 0px rgba(0,0,0,.06),0px 0px 1px 0px rgba(0,0,0,.15);",
            "--lumex-box-shadow-medium: 0px 0px 15px 0px rgba(0,0,0,.03),0px 2px 30px 0px rgba(0,0,0,.08),0px 0px 1px 0px rgba(0,0,0,.15);",
            "--lumex-box-shadow-large: 0px 0px 20px 0px rgba(0,0,0,.04),0px 2px 50px 0px rgba(0,0,0,.1),0px 0px 1px 0px rgba(0,0,0,.15);",
            "--lumex-divider-opacity: 0.15;",
            "--lumex-disabled-opacity: 0.6;",
            "--lumex-focus-opacity: 0.7;",
            "--lumex-hover-opacity: 0.8;",
            "}"
        ).ToString();

        styleNodes[0].InnerHtml.Trim().Should().BeEquivalentTo( expectedCssVars );
    }
}