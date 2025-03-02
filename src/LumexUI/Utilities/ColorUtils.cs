// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text.RegularExpressions;

using LumexUI.Theme;

namespace LumexUI.Utilities;

[ExcludeFromCodeCoverage]
internal static partial class ColorUtils
{
	internal static string GetReadableColor( string color )
	{
		ArgumentNullException.ThrowIfNull( color, nameof( color ) );

		return Luminance( color.Trim() ) < .35 ? Colors.White : Colors.Black;
	}

	private static double Luminance( string color )
	{
		if( color == "transparent" )
		{
			return 0;
		}

		if( color.StartsWith( "oklch" ) )
		{
			return GetOklchLuminance( color );
		}

		if( color.StartsWith( '#' ) )
		{
			return GetHexLuminance( color );
		}

		return 0;
	}

	private static double GetOklchLuminance( string color )
	{
		var match = Oklch().Match( color );
		if( match.Success )
		{
			return double.Parse( match.Groups[1].Value, CultureInfo.InvariantCulture );
		}

		throw new ArgumentException( "Color is not in the correct format.", nameof( color ) );
	}

	private static double GetHexLuminance( string color )
	{
		var (r, g, b) = HexToRgb( color );
		return 0.2126 * Linear( r ) + 0.7152 * Linear( g ) + 0.0722 * Linear( b );

		static double Linear( double x )
		{
			var channel = x / 255;

			return channel <= 0.04045
				? channel / 12.92
				: Math.Pow( ( channel + 0.055 ) / 1.055, 2.4 );
		}
	}

	private static RGB HexToRgb( string color )
	{
		color = color[1..];
		if( uint.TryParse( color, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var decimalValue ) )
		{
			throw new ArgumentException( "Color is not in the correct format.", nameof( color ) );
		}

		var R = (byte)( decimalValue >> 16 );
		var G = (byte)( decimalValue >> 8 );
		var B = (byte)( decimalValue >> 0 );

		return new( R, G, B );
	}

	private record struct RGB( byte R, byte G, byte B );

	[GeneratedRegex( @"oklch\(([\d.]+)\s([\d.]+)\s([\d.]+)\)" )]
	private static partial Regex Oklch();
}
