// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Utilities;

using TailwindMerge;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal static class Chip
{
	private static ComponentVariant? _variant;

	public static ComponentVariant Style( TwMerge twMerge )
	{
		var twVariants = new TwVariants( twMerge );

		return _variant ??= twVariants.Create( new VariantConfig()
		{
			Slots = new SlotCollection
			{
				[nameof( ChipSlots.Base )] = new ElementClass()
					.Add("relative")
					.Add("max-w-fit")
					.Add("max-w-min")
					.Add("inline-flex")
					.Add("items-center")
					.Add("justify-between")
					.Add("whitespace-nowrap"),

				[nameof( ChipSlots.Content )] = new ElementClass()
					.Add( "flex-1" )
					.Add( "text-inherit" ),

				[nameof( ChipSlots.Dot )] = new ElementClass()
					.Add( "size-2" )
					.Add( "ml-1" )
					.Add( "rounded-full" ),

				[nameof( ChipSlots.CloseButton )] = new ElementClass()
					.Add( "z-10" )
					.Add( "select-none" )
					.Add( "appearance-none" )
					.Add( "outline-hidden" )
					.Add( "opacity-70" )
					.Add( "cursor-pointer" )
					.Add( "hover:opacity-100" )
					.Add( "active:opacity-disabled" )
					// transition
					.Add( "transition-opacity" )
			}
		} );
	}
}