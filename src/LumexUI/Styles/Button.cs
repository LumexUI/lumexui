// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal class Button
{
	private readonly static string _base = ElementClass.Empty()
		.Add( "inline-flex" )
		.Add( "items-center" )
		.Add( "justify-center" )
		.Add( "min-w-max" )
		.Add( "text-medium" )
		.Add( "font-normal" )
		.Add( "appearance-none" )
		.Add( "outline-none" )
		.Add( "select-none" )
		.Add( "whitespace-nowrap" )
		.Add( "subpixel-antialiased" )
		.Add( "overflow-hidden" )
		.Add( "active:scale-[0.97]" )
		// transition
		.Add( "transition-transform-colors-opacity" )
		.Add( "motion-reduce:transition-none" )
		// focus ring
		.Add( Utils.FocusVisible )
		.ToString();

	private readonly static string _disabled = ElementClass.Empty()
		.Add( "opacity-disabled" )
		.Add( "pointer-events-none" )
		.ToString();

	private readonly static string _fullWidth = ElementClass.Empty()
		.Add( "w-full" )
		.ToString();

	private static ElementClass GetSizeStyles( Size size )
	{
		return ElementClass.Empty()
			.Add( "min-w-16 h-8 px-3 gap-2 text-small rounded-small", when: size is Size.Small )
			.Add( "min-w-20 h-10 px-4 gap-2 text-medium rounded-medium", when: size is Size.Medium )
			.Add( "min-w-24 h-12 px-6 gap-2 text-large rounded-large", when: size is Size.Large );
	}

	private static ElementClass GetRadiusStyles( Radius radius )
	{
		return ElementClass.Empty()
			.Add( "rounded-none", when: radius is Radius.None )
			.Add( "rounded-small", when: radius is Radius.Small )
			.Add( "rounded-medium", when: radius is Radius.Medium )
			.Add( "rounded-large", when: radius is Radius.Large );
	}

	private static ElementClass GetVariantStyles( Variant variant )
	{
		return ElementClass.Empty()
			.Add( "border-2 bg-transparent", when: variant is Variant.Outlined )
			.Add( "border-2 bg-transparent", when: variant is Variant.Ghost )
			.Add( "bg-transparent", when: variant is Variant.Light );
	}

	private static ElementClass GetColorStyles( Variant variant, ThemeColor color )
	{
		return ElementClass.Empty()
			.Add( ColorVariants.Solid[color], when: variant is Variant.Solid )
			.Add( ColorVariants.Outlined[color], when: variant is Variant.Outlined )
			.Add( ColorVariants.Flat[color], when: variant is Variant.Flat )
			.Add( ColorVariants.Shadow[color], when: variant is Variant.Shadow )
			.Add( ColorVariants.Ghost[color], when: variant is Variant.Ghost )
			.Add( ColorVariants.Light[color], when: variant is Variant.Light );
	}

	private static ElementClass GetHoverStyles( Variant variant, ThemeColor color )
	{
		return variant switch
		{
			Variant.Light => ElementClass.Empty()
				.Add( "hover:bg-default-200", when: color is ThemeColor.Default )
				.Add( "hover:bg-primary-100", when: color is ThemeColor.Primary )
				.Add( "hover:bg-secondary-100", when: color is ThemeColor.Secondary )
				.Add( "hover:bg-success-100", when: color is ThemeColor.Success )
				.Add( "hover:bg-warning-100", when: color is ThemeColor.Warning )
				.Add( "hover:bg-danger-100", when: color is ThemeColor.Danger )
				.Add( "hover:bg-info-100", when: color is ThemeColor.Info ),

			Variant.Ghost => ElementClass.Empty()
				.Add( "hover:!bg-default hover:!text-default-foreground", when: color is ThemeColor.Default )
				.Add( "hover:!bg-primary hover:!text-primary-foreground", when: color is ThemeColor.Primary )
				.Add( "hover:!bg-secondary hover:!text-secondary-foreground", when: color is ThemeColor.Secondary )
				.Add( "hover:!bg-success hover:!text-success-foreground", when: color is ThemeColor.Success )
				.Add( "hover:!bg-warning hover:!text-warning-foreground", when: color is ThemeColor.Warning )
				.Add( "hover:!bg-danger hover:!text-danger-foreground", when: color is ThemeColor.Danger )
				.Add( "hover:!bg-info hover:!text-info-foreground", when: color is ThemeColor.Info ),

			_ => ElementClass.Empty()
				.Add( "hover:opacity-hover" )
		};
	}

	public static string GetStyles( LumexButton button )
	{
		return ElementClass.Empty()
			.Add( _base )
			.Add( _disabled, when: button.Disabled )
			.Add( _fullWidth, when: button.FullWidth )
			.Add( GetSizeStyles( button.Size ) )
			.Add( GetRadiusStyles( button.Radius ) )
			.Add( GetVariantStyles( button.Variant ) )
			.Add( GetColorStyles( button.Variant, button.Color ) )
			.Add( GetHoverStyles( button.Variant, button.Color ) )
			.Add( button.Class )
			.ToString();
	}
}
