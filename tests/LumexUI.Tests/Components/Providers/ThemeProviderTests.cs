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
            "--lumex-foreground-50: 0 0% 98%;",
            "--lumex-foreground-100: 240 5% 96%;",
            "--lumex-foreground-200: 240 6% 90%;",
            "--lumex-foreground-300: 240 4% 80%;",
            "--lumex-foreground-400: 240 5% 63%;",
            "--lumex-foreground-500: 240 5% 34%;",
            "--lumex-foreground-600: 240 5% 26%;",
            "--lumex-foreground-700: 240 4% 16%;",
            "--lumex-foreground-800: 240 6% 10%;",
            "--lumex-foreground-900: 240 10% 4%;",
            "--lumex-foreground: 240 4% 16%;",
            "--lumex-overlay: 0 0% 0%;",
            "--lumex-focus: 214 84% 53%;",
            "--lumex-divider: 0 0% 0%;",
            "--lumex-default-50: 0 0% 98%;",
            "--lumex-default-100: 240 5% 96%;",
            "--lumex-default-200: 240 6% 90%;",
            "--lumex-default-300: 240 4% 80%;",
            "--lumex-default-400: 240 5% 63%;",
            "--lumex-default-500: 240 5% 34%;",
            "--lumex-default-600: 240 5% 26%;",
            "--lumex-default-700: 240 4% 16%;",
            "--lumex-default-800: 240 6% 10%;",
            "--lumex-default-900: 240 10% 4%;",
            "--lumex-default: 240 6% 90%;",
            "--lumex-default-foreground: 0 0% 0%;",
            "--lumex-primary-50: 208 100% 97%;",
            "--lumex-primary-100: 209 95% 92%;",
            "--lumex-primary-200: 210 95% 85%;",
            "--lumex-primary-300: 210 92% 74%;",
            "--lumex-primary-400: 214 89% 62%;",
            "--lumex-primary-500: 214 84% 53%;",
            "--lumex-primary-600: 220 76% 48%;",
            "--lumex-primary-700: 222 73% 36%;",
            "--lumex-primary-800: 223 70% 28%;",
            "--lumex-primary-900: 225 63% 16%;",
            "--lumex-primary: 214 84% 53%;",
            "--lumex-primary-foreground: 0 0% 100%;",
            "--lumex-secondary-50: 256 100% 97%;",
            "--lumex-secondary-100: 254 100% 94%;",
            "--lumex-secondary-200: 253 96% 90%;",
            "--lumex-secondary-300: 253 94% 81%;",
            "--lumex-secondary-400: 256 95% 74%;",
            "--lumex-secondary-500: 258 86% 63%;",
            "--lumex-secondary-600: 262 71% 51%;",
            "--lumex-secondary-700: 262 65% 44%;",
            "--lumex-secondary-800: 262 69% 33%;",
            "--lumex-secondary-900: 262 64% 23%;",
            "--lumex-secondary: 258 86% 63%;",
            "--lumex-secondary-foreground: 0 0% 100%;",
            "--lumex-success-50: 132 100% 97%;",
            "--lumex-success-100: 134 100% 91%;",
            "--lumex-success-200: 134 96% 81%;",
            "--lumex-success-300: 134 74% 70%;",
            "--lumex-success-400: 135 70% 60%;",
            "--lumex-success-500: 136 63% 44%;",
            "--lumex-success-600: 140 73% 37%;",
            "--lumex-success-700: 141 72% 27%;",
            "--lumex-success-800: 143 74% 17%;",
            "--lumex-success-900: 143 76% 10%;",
            "--lumex-success: 136 63% 44%;",
            "--lumex-success-foreground: 0 0% 0%;",
            "--lumex-warning-50: 51 100% 96%;",
            "--lumex-warning-100: 50 100% 88%;",
            "--lumex-warning-200: 49 97% 76%;",
            "--lumex-warning-300: 47 99% 71%;",
            "--lumex-warning-400: 46 96% 55%;",
            "--lumex-warning-500: 43 92% 51%;",
            "--lumex-warning-600: 40 93% 41%;",
            "--lumex-warning-700: 33 88% 35%;",
            "--lumex-warning-800: 26 74% 26%;",
            "--lumex-warning-900: 24 67% 17%;",
            "--lumex-warning: 43 92% 51%;",
            "--lumex-warning-foreground: 0 0% 0%;",
            "--lumex-danger-50: 352 100% 97%;",
            "--lumex-danger-100: 350 100% 91%;",
            "--lumex-danger-200: 352 100% 82%;",
            "--lumex-danger-300: 352 92% 71%;",
            "--lumex-danger-400: 351 90% 62%;",
            "--lumex-danger-500: 347 75% 49%;",
            "--lumex-danger-600: 346 79% 44%;",
            "--lumex-danger-700: 343 76% 35%;",
            "--lumex-danger-800: 342 73% 29%;",
            "--lumex-danger-900: 342 76% 18%;",
            "--lumex-danger: 347 75% 49%;",
            "--lumex-danger-foreground: 0 0% 100%;",
            "--lumex-info-50: 196 100% 97%;",
            "--lumex-info-100: 197 100% 93%;",
            "--lumex-info-200: 198 95% 85%;",
            "--lumex-info-300: 200 96% 73%;",
            "--lumex-info-400: 199 97% 60%;",
            "--lumex-info-500: 199 97% 46%;",
            "--lumex-info-600: 199 96% 37%;",
            "--lumex-info-700: 199 91% 31%;",
            "--lumex-info-800: 204 80% 25%;",
            "--lumex-info-900: 207 79% 15%;",
            "--lumex-info: 199 97% 46%;",
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