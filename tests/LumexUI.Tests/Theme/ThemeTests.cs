// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Theme;

namespace LumexUI.Tests.Components;

public class ThemeTests : TestContext
{
    [Fact]
    public void Constructor_Default_ShouldInitializeBaseColorsCorrectly()
    {
        var theme = new LumexTheme();

        theme.Light.Colors.Background.Should().HaveCount( 1 );
        theme.Light.Colors.Background.Should().ContainKey( "default" );

        theme.Light.Colors.Foreground.Should().HaveCount( 11, because: "10 more shades of the foreground color." );
        theme.Light.Colors.Foreground.Should().ContainKey( "default" );
        theme.Light.Colors.Foreground.Should().NotContainKey( "foreground" );

        theme.Light.Colors.Overlay.Should().HaveCount( 1 );
        theme.Light.Colors.Overlay.Should().ContainKey( "default" );

        theme.Light.Colors.Divider.Should().HaveCount( 1 );
        theme.Light.Colors.Divider.Should().ContainKey( "default" );

        theme.Light.Colors.Focus.Should().HaveCount( 1 );
        theme.Light.Colors.Focus.Should().ContainKey( "default" );

        theme.Dark.Colors.Background.Should().HaveCount( 1 );
        theme.Dark.Colors.Background.Should().ContainKey( "default" );

        theme.Dark.Colors.Foreground.Should().HaveCount( 11, because: "10 more shades of the foreground color." );
        theme.Dark.Colors.Foreground.Should().ContainKey( "default" );
        theme.Dark.Colors.Foreground.Should().NotContainKey( "foreground" );

        theme.Dark.Colors.Overlay.Should().HaveCount( 1 );
        theme.Dark.Colors.Overlay.Should().ContainKey( "default" );

        theme.Dark.Colors.Divider.Should().HaveCount( 1 );
        theme.Dark.Colors.Divider.Should().ContainKey( "default" );

        theme.Dark.Colors.Focus.Should().HaveCount( 1 );
        theme.Dark.Colors.Focus.Should().ContainKey( "default" );
    }

    [Fact]
    public void Constructor_Default_ShouldInitializeThemeColorsCorrectly()
    {
        var theme = new LumexTheme();

        theme.Light.Colors.Default.Should().HaveCount( 12 );
        theme.Light.Colors.Default.Should().ContainKey( "default" );
        theme.Light.Colors.Default.Should().ContainKey( "foreground" );

        theme.Light.Colors.Primary.Should().HaveCount( 12 );
        theme.Light.Colors.Primary.Should().ContainKey( "default" );
        theme.Light.Colors.Primary.Should().ContainKey( "foreground" );

        theme.Light.Colors.Secondary.Should().HaveCount( 12 );
        theme.Light.Colors.Secondary.Should().ContainKey( "default" );
        theme.Light.Colors.Secondary.Should().ContainKey( "foreground" );

        theme.Light.Colors.Success.Should().HaveCount( 12 );
        theme.Light.Colors.Success.Should().ContainKey( "default" );
        theme.Light.Colors.Success.Should().ContainKey( "foreground" );

        theme.Light.Colors.Warning.Should().HaveCount( 12 );
        theme.Light.Colors.Warning.Should().ContainKey( "default" );
        theme.Light.Colors.Warning.Should().ContainKey( "foreground" );

        theme.Light.Colors.Danger.Should().HaveCount( 12 );
        theme.Light.Colors.Danger.Should().ContainKey( "default" );
        theme.Light.Colors.Danger.Should().ContainKey( "foreground" );

        theme.Light.Colors.Info.Should().HaveCount( 12 );
        theme.Light.Colors.Info.Should().ContainKey( "default" );
        theme.Light.Colors.Info.Should().ContainKey( "foreground" );

        theme.Dark.Colors.Default.Should().HaveCount( 12 );
        theme.Dark.Colors.Default.Should().ContainKey( "default" );
        theme.Dark.Colors.Default.Should().ContainKey( "foreground" );

        theme.Dark.Colors.Primary.Should().HaveCount( 12 );
        theme.Dark.Colors.Primary.Should().ContainKey( "default" );
        theme.Dark.Colors.Primary.Should().ContainKey( "foreground" );

        theme.Dark.Colors.Secondary.Should().HaveCount( 12 );
        theme.Dark.Colors.Secondary.Should().ContainKey( "default" );
        theme.Dark.Colors.Secondary.Should().ContainKey( "foreground" );

        theme.Dark.Colors.Success.Should().HaveCount( 12 );
        theme.Dark.Colors.Success.Should().ContainKey( "default" );
        theme.Dark.Colors.Success.Should().ContainKey( "foreground" );

        theme.Dark.Colors.Warning.Should().HaveCount( 12 );
        theme.Dark.Colors.Warning.Should().ContainKey( "default" );
        theme.Dark.Colors.Warning.Should().ContainKey( "foreground" );

        theme.Dark.Colors.Danger.Should().HaveCount( 12 );
        theme.Dark.Colors.Danger.Should().ContainKey( "default" );
        theme.Dark.Colors.Danger.Should().ContainKey( "foreground" );

        theme.Dark.Colors.Info.Should().HaveCount( 12 );
        theme.Dark.Colors.Info.Should().ContainKey( "default" );
        theme.Dark.Colors.Info.Should().ContainKey( "foreground" );
    }

    [Fact]
    public void Constructor_DefaultAndCustomized_ShouldInitializeCorrectly()
    {
        var theme = new LumexTheme()
        {
            Light = new ThemeConfigLight()
            {
                Colors = new ThemeColorsLight()
                {
                    Background = new ColorScale( "background" ),
                }
            }
        };

        theme.Light.Colors.Background["default"].Should().Be( "background" );
    }

    [Fact]
    public void Constructor_WithDefaultTheme_ShouldSetDefaultThemeCorrectly()
    {
        var theme = new LumexTheme( ThemeType.Dark );

        theme.DefaultTheme.Should().Be( ThemeType.Dark );
    }
}