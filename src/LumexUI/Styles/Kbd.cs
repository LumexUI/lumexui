// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Utilities;

using TailwindMerge;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal static class Kbd
{
	private static ComponentVariant? _variant;

	public static ComponentVariant Style( TwMerge twMerge )
	{
		var twVariants = new TwVariants( twMerge );

		return _variant ??= twVariants.Create( new VariantConfig()
		{
			Slots = new SlotCollection
			{
				[nameof( KbdSlots.Base )] = new ElementClass()
					.Add( "px-1.5" )
					.Add( "py-0.5" )
					.Add( "inline-flex" )
					.Add( "space-x-0.5" )
					.Add( "rtl:space-x-reverse" )
					.Add( "items-center" )
					.Add( "font-sans" )
					.Add( "font-normal" )
					.Add( "text-center" )
					.Add( "text-small" )
					.Add( "shadow-small" )
					.Add( "bg-default-100" )
					.Add( "text-foreground-600" )
					.Add( "rounded-small" ),

				[nameof( KbdSlots.Abbr )] = "no-underline",
			}
		} );
	}
}
