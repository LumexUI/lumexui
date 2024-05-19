// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;
using System.Globalization;

using LumexUI.Theme;

namespace LumexUI.Utilities;

[ExcludeFromCodeCoverage]
internal static class ColorUtils
{
    internal static string HexToHsl( string color )
    {
        HexToHsl( color, out var H, out var S, out var L );
        return $"{H} {S}% {L}%";
    }

    internal static string GetReadableColor( string color )
    {
        return Luminance( color ) < .3 ? Colors.White : Colors.Black;
    }

    private static void HexToRgb( string color, out byte R, out byte G, out byte B )
    {
        color = color[1..];

        if( color == null || !uint.TryParse( color, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var decimalValue ) )
        {
            throw new ArgumentException( $"Color hexadecimal value '{color}' is not in the correct format.", nameof( color ) );
        }

        R = (byte)( decimalValue >> 16 );
        G = (byte)( decimalValue >> 8 );
        B = (byte)( decimalValue >> 0 );
    }

    private static void HexToHsl( string color, out double H, out double S, out double L )
    {
        HexToRgb( color, out var R, out var G, out var B );

        var _R = R / 255d;
        var _G = G / 255d;
        var _B = B / 255d;

        var max = Math.Max( _R, Math.Max( _G, _B ) );
        var min = Math.Min( _R, Math.Min( _G, _B ) );
        var delta = max - min;

        H = 0;
        S = 0;
        L = ( max + min ) / 2d;

        if( delta != 0 )
        {
            S = L < 0.5
                ? delta / ( max + min )
                : delta / ( 2d - max - min );

            if( _R == max )
            {
                H = ( _G - _B ) / delta;
            }
            else if( _G == max )
            {
                H = 2d + ( ( _B - _R ) / delta );
            }
            else if( _B == max )
            {
                H = 4d + ( ( _R - _G ) / delta );
            }
        }

        H = Math.Round( H *= 60d );
        S = Math.Round( S *= 100 );
        L = Math.Round( L *= 100 );

        if( H < 0 )
        {
            H += 360;
        }
    }

    private static double Luminance( string color )
    {
        if( color == "transparent" )
        {
            return 0;
        }

        HexToRgb( color, out var R, out var G, out var B );
        return 0.2126 * Linear( R ) + 0.7152 * Linear( G ) + 0.0722 * Linear( B );

        static double Linear( double x )
        {
            var channel = x / 255;

            return channel <= 0.04045
                ? channel / 12.92
                : Math.Pow( ( channel + 0.055 ) / 1.055, 2.4 );
        }
    }
}
