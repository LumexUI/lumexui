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

		if( color is Colors.White )
		{
			return Colors.Black;
		}
		else if( color is Colors.Black )
		{
			return Colors.White;
		}

		return Luminance( color.Trim() ) < .65 ? Colors.White : Colors.Black;
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

		return 0;
	}

	private static double GetOklchLuminance( string color )
	{
		var match = Oklch().Match( color );
		if( match.Success )
		{
			return double.Parse( match.Groups[1].Value, CultureInfo.InvariantCulture );
		}

		throw new ArgumentException( $"Color '{color}' is not in the correct format.", nameof( color ) );
	}

	[GeneratedRegex( @"oklch\(([\d.]+)\s([\d.]+)\s([\d.]+)\)" )]
	private static partial Regex Oklch();
}
