// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using TailwindMerge;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal static class Code
{
	private readonly static string _base = ElementClass.Empty()
		.Add( "inline-block" )
		.Add( "whitespace-nowrap" )
		.Add( "font-mono" )
		.Add( "font-normal" )
		.Add( "h-fit" )
		.Add( "px-2" )
		.Add( "py-1" )
		.ToString();

	private static ElementClass GetSizeStyles( Size size )
	{
		return ElementClass.Empty()
			.Add( "text-tiny", when: size is Size.Small )
			.Add( "text-small", when: size is Size.Medium )
			.Add( "text-medium", when: size is Size.Large );
	}

	private static ElementClass GetRadiusStyles( Radius radius )
	{
		return ElementClass.Empty()
			.Add( "rounded-none", when: radius is Radius.None )
			.Add( "rounded-small", when: radius is Radius.Small )
			.Add( "rounded-medium", when: radius is Radius.Medium )
			.Add( "rounded-large", when: radius is Radius.Large )
			.Add( "rounded-full", when: radius is Radius.Full );
	}

	private static ElementClass GetColorStyles( ThemeColor color )
	{
		return ElementClass.Empty()
			.Add( ColorVariants.Flat[color], when: color is ThemeColor.Default )
			.Add( ColorVariants.Flat[color], when: color is ThemeColor.Primary )
			.Add( ColorVariants.Flat[color], when: color is ThemeColor.Secondary )
			.Add( ColorVariants.Flat[color], when: color is ThemeColor.Success )
			.Add( ColorVariants.Flat[color], when: color is ThemeColor.Warning )
			.Add( ColorVariants.Flat[color], when: color is ThemeColor.Danger );
	}

	public static string GetStyles( LumexCode code )
	{
		return ElementClass.Empty()
			.Add( _base )
			.Add( GetColorStyles( code.Color ) )
			.Add( GetSizeStyles( code.Size ) )
			.Add( GetRadiusStyles( code.Radius ) )
			.Add( code.Class )
			.ToString();
	}
}