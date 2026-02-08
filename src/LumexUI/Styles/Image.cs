// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal class Image
{
	private readonly static string _base = ElementClass.Empty()
		.ToString();

	private readonly static string _fullWidth = ElementClass.Empty()
		.Add( "w-full" )
		.ToString();

	private readonly static string _fullHeight = ElementClass.Empty()
		.Add( "h-full" )
		.ToString();

	private static ElementClass GetRadiusStyles( Radius radius )
	{
		return ElementClass.Empty()
			.Add( "rounded-none", when: radius is Radius.None )
			.Add( "rounded-small", when: radius is Radius.Small )
			.Add( "rounded-medium", when: radius is Radius.Medium )
			.Add( "rounded-large", when: radius is Radius.Large )
			.Add( "rounded-full", when: radius is Radius.Full );
	}

	private static ElementClass GetShadowStyles( Shadow shadow )
	{
		return ElementClass.Empty()
			.Add( "drop-shadow-none", when: shadow is Shadow.None )
			.Add( "drop-shadow-sm", when: shadow is Shadow.Small )
			.Add( "drop-shadow-md", when: shadow is Shadow.Medium )
			.Add( "drop-shadow-lg", when: shadow is Shadow.Large );
	}

	private static ElementClass GetBlurStyles( Blur blur )
	{
		return ElementClass.Empty()
			.Add( "blur-none", when: blur is Blur.None )
			.Add( "blur-sm", when: blur is Blur.Small )
			.Add( "blur-lg", when: blur is Blur.Medium )
			.Add( "blur-2xl", when: blur is Blur.Large );
	}

	private static ElementClass GetObjectFitStyles( ObjectFit fit )
	{
		return ElementClass.Empty()
			.Add( "object-none", when: fit is ObjectFit.None )
			.Add( "object-cover", when: fit is ObjectFit.Cover )
			.Add( "object-contain", when: fit is ObjectFit.Contain )
			.Add( "object-fill", when: fit is ObjectFit.Fill )
			.Add( "object-scale-down", when: fit is ObjectFit.ScaleDown );
	}

	private static ElementClass GetGrayScaleStyles()
	{
		return ElementClass.Empty()
			.Add( "grayscale" );
	}

	private static ElementClass GetOnClickStyles()
	{
		return ElementClass.Empty()
			.Add( "cursor-pointer" )
			.Add( "transition" )
			.Add( "hover:opacity-80" );
	}

	public static string GetStyles( LumexImage image )
	{
		return ElementClass.Empty()
			.Add( _base )
			.Add( _fullWidth, when: image.FullWidth )
			.Add( _fullHeight, when: image.FullHeight )
			.Add( GetBlurStyles( image.Blur ) )
			.Add( GetRadiusStyles( image.Radius ) )
			.Add( GetShadowStyles( image.Shadow ) )
			.Add( GetObjectFitStyles( image.Fit ) )
			.Add( GetGrayScaleStyles(), when: image.GrayScale )
			.Add( GetOnClickStyles(), when: image.OnClick.HasDelegate )
			.Add( image.Class )
			.ToString();
	}
}
