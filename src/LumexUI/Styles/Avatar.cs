// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
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
			},

			Variants = new VariantCollection
			{
				[nameof( LumexAvatar.Size )] = new VariantValueCollection
				{
					[nameof( Size.Small )] = new SlotCollection
					{
						[nameof( AvatarSlots.Base )] = "w-8 h-8 text-tiny"
					},
					[nameof( Size.Medium )] = new SlotCollection
					{
						[nameof( AvatarSlots.Base )] = "w-10 h-10 text-tiny"
					},
					[nameof( Size.Large )] = new SlotCollection
					{
						[nameof( AvatarSlots.Base )] = "w-14 h-14 text-small"
					}
				},

				[nameof( LumexAvatar.Color )] = new VariantValueCollection
				{
					[nameof( ThemeColor.Default )] = new SlotCollection
					{
						[nameof( AvatarSlots.Base )] = ColorVariants.Solid[ThemeColor.Default]
					},
					[nameof( ThemeColor.Primary )] = new SlotCollection
					{
						[nameof( AvatarSlots.Base )] = ColorVariants.Solid[ThemeColor.Primary]
					},
					[nameof( ThemeColor.Secondary )] = new SlotCollection
					{
						[nameof( AvatarSlots.Base )] = ColorVariants.Solid[ThemeColor.Secondary]
					},
					[nameof( ThemeColor.Success )] = new SlotCollection
					{
						[nameof( AvatarSlots.Base )] = ColorVariants.Solid[ThemeColor.Success]
					},
					[nameof( ThemeColor.Warning )] = new SlotCollection
					{
						[nameof( AvatarSlots.Base )] = ColorVariants.Solid[ThemeColor.Warning]
					},
					[nameof( ThemeColor.Danger )] = new SlotCollection
					{
						[nameof( AvatarSlots.Base )] = ColorVariants.Solid[ThemeColor.Danger]
					},
					[nameof( ThemeColor.Info )] = new SlotCollection
					{
						[nameof( AvatarSlots.Base )] = ColorVariants.Solid[ThemeColor.Info]
					}
				},

				[nameof( LumexAvatar.Radius )] = new VariantValueCollection
				{
					[nameof( Radius.None )] = new SlotCollection
					{
						[nameof( AvatarSlots.Base )] = "rounded-none"
					},
					[nameof( Radius.Small )] = new SlotCollection
					{
						[nameof( AvatarSlots.Base )] = "rounded-small"
					},
					[nameof( Radius.Medium )] = new SlotCollection
					{
						[nameof( AvatarSlots.Base )] = "rounded-medium"
					},
					[nameof( Radius.Large )] = new SlotCollection
					{
						[nameof( AvatarSlots.Base )] = "rounded-large"
					},
					[nameof( Radius.Full )] = new SlotCollection
					{
						[nameof( AvatarSlots.Base )] = "rounded-full"
					}
				},

				[nameof( LumexAvatar.Bordered )] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof( AvatarSlots.Base )] = "ring-2 ring-offset-2 ring-offset-background"
					}
				},

				[nameof( LumexAvatar.Disabled )] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof( AvatarSlots.Base )] = "opacity-disabled"
					}
				}
			}
		} );
	}
}
