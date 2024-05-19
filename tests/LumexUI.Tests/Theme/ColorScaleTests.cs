// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Theme;

namespace LumexUI.Tests.Components;

public class ColorScaleTests : TestContext
{
    [Fact]
    public void Constructor_DefaultColor_ShouldSetDefaultKey()
    {
        var scale = new ColorScale( Colors.Black );

        scale.Should().ContainKey( "default" );
        scale["default"].Should().Be( Colors.Black );
    }

    [Fact]
    public void Constructor_NullDictionary_ShouldThrowArgumentNull()
    {
        var action = () => new ColorScale( null!, "500" );

        action.Should().Throw<ArgumentNullException>();
    }

    [Theory]
    [InlineData( null )]
    [InlineData( "" )]
    public void Constructor_NullOrEmptyDefaultColorKey_ShouldThrowArgumentNull( string? key )
    {
        var action = () => new ColorScale( Colors.Orange, key! );

        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void Constructor_InvalidDefaultColorKey_ShouldThrowArgumentNull()
    {
        var action = () => new ColorScale( Colors.Orange, "0" );

        action.Should().Throw<KeyNotFoundException>();
    }

    [Fact]
    public void Constructor_DictionaryAndColorKey_ShouldInitializeCorrectly()
    {
        var scale = new ColorScale( Colors.Orange, "500" );

        scale.Should().HaveCount( 12 );
        scale.Should().ContainKey( "default" );
        scale.Should().ContainKey( "foreground" );
        scale["default"].Should().Be( Colors.Orange["500"] );
    }

    [Theory]
    [InlineData( null )]
    [InlineData( "" )]
    public void IndexerGet_NullOrEmptyKey_ShouldThrowArgumentNull( string? key )
    {
        var scale = new ColorScale( Colors.Orange, "500" );

        var action = () => scale[key!];

        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void IndexerGet_InvalidKey_ShouldThrowKeyNotFound()
    {
        var scale = new ColorScale( Colors.Orange, "500" );

        var action = () => scale["0"];

        action.Should().Throw<KeyNotFoundException>();
    }

    [Theory]
    [InlineData( null )]
    [InlineData( "" )]
    public void IndexerSet_NullOrEmptyKey_ShouldThrowArgumentNull( string? key )
    {
        var scale = new ColorScale( Colors.Orange, "500" );

        var action = () => scale[key!] = Colors.Black;

        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void IndexerSet_NullValue_ShouldThrowArgumentNull()
    {
        var scale = new ColorScale( Colors.Orange, "500" );

        var action = () => scale["500"] = null!;

        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void IndexerSet_ValidValue_ShouldSetNewValue()
    {
        var scale = new ColorScale( Colors.Orange, "500" )
        {
            ["500"] = "value"
        };

        scale["500"].Should().Be( "value" );
    }

    [Theory]
    [InlineData( null )]
    [InlineData( "" )]
    public void SetAsDefault_NullOrEmptyKey_ShouldThrowArgumentNull( string? key )
    {
        var scale = new ColorScale( Colors.Orange, "500" );
        var action = () => scale.SetAsDefault( key! );

        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void SetAsDefault_InvalidKey_ShouldThrowKeyNotFound()
    {
        var scale = new ColorScale( Colors.Orange, "500" );
        var action = () => scale.SetAsDefault( "0" );

        action.Should().Throw<KeyNotFoundException>();
    }

    [Fact]
    public void SetAsDefault_ValidKey_ShouldUpdateDefaultKey()
    {
        var scale = new ColorScale( Colors.Orange, "500" );

        scale.SetAsDefault( "300" );

        scale["default"].Should().Be( Colors.Orange["300"] );
    }
}