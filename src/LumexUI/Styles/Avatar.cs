// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Utilities;

using TailwindMerge;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal static class Avatar
{
	private static ComponentVariant? _variant;

	public static ComponentVariant Style( TwMerge twMerge )
	{
		var twVariants = new TwVariants( twMerge );

		return _variant ??= twVariants.Create( new VariantConfig()
		{
			Slots = new SlotCollection
			{
				[nameof( AvatarSlots.Base )] = new ElementClass()
					.Add( "z-0" )
					.Add( "flex" )
					.Add( "relative" )
					.Add( "justify-center" )
					.Add( "items-center" )
					.Add( "overflow-hidden" )
					.Add( "align-middle" )
					.Add( "text-white" )
					// focus ring
					.Add( Utils.FocusVisible )
					.ToString(),

				[nameof( AvatarSlots.Img )] = new ElementClass()
					.Add( "flex" )
					.Add( "object-cover" )
					.Add( "w-full" )
					.Add( "h-full" )
					.Add( "opacity-0" )
					.Add( "transition-opacity" )
					.Add( "!duration-500" )
					.Add( "data-[loaded=true]:opacity-100" )
					.ToString(),

				[nameof( AvatarSlots.Fallback )] = new ElementClass()
					.Add( "absolute" )
					.Add( "top-1/2" )
					.Add( "left-1/2" )
					.Add( "-translate-x-1/2" )
					.Add( "-translate-y-1/2" )
					.Add( "flex" )
					.Add( "items-center" )
					.Add( "justify-center" )
					.ToString(),

				[nameof( AvatarSlots.Name )] = new ElementClass()
					.Add( "absolute" )
					.Add( "top-1/2" )
					.Add( "left-1/2" )
					.Add( "-translate-x-1/2" )
					.Add( "-translate-y-1/2" )
					.Add( "flex" )
					.Add( "items-center" )
					.Add( "justify-center" )
					.ToString(),

				[nameof( AvatarSlots.Icon )] = new ElementClass()
					.Add( "absolute" )
					.Add( "top-1/2" )
					.Add( "left-1/2" )
					.Add( "-translate-x-1/2" )
					.Add( "-translate-y-1/2" )
					.Add( "flex" )
					.Add( "items-center" )
					.Add( "justify-center" )
					.Add( "text-inherit" )
					.Add( "w-full" )
					.Add( "h-full" )
					.ToString()
			}
		} );
	}
}
