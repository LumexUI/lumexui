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
					.Add( Utils.FocusVisible ),

				[nameof( AvatarSlots.Img )] = new ElementClass()
					.Add( "flex" )
					.Add( "object-cover" )
					.Add( "w-full" )
					.Add( "h-full" )
					.Add( "opacity-0" )
					.Add( "duration-500" )
					.Add( "transition-opacity" )
					.Add( "data-[loaded=true]:opacity-100" ),

				[nameof( AvatarSlots.Fallback )] = new ElementClass()
					.Add( "absolute" )
					.Add( "top-1/2" )
					.Add( "left-1/2" )
					.Add( "-translate-x-1/2" )
					.Add( "-translate-y-1/2" )
					.Add( "flex" )
					.Add( "items-center" )
					.Add( "justify-center" ),

				[nameof( AvatarSlots.Name )] = new ElementClass()
					.Add( "absolute" )
					.Add( "top-1/2" )
					.Add( "left-1/2" )
					.Add( "-translate-x-1/2" )
					.Add( "-translate-y-1/2" )
					.Add( "flex" )
					.Add( "items-center" )
					.Add( "justify-center" ),

				[nameof( AvatarSlots.Icon )] = new ElementClass()
					.Add( "absolute" )
					.Add( "top-1/2" )
					.Add( "left-1/2" )
					.Add( "-translate-x-1/2" )
					.Add( "-translate-y-1/2" )
					.Add( "w-full" )
					.Add( "h-full" )
					.Add( "flex" )
					.Add( "items-center" )
					.Add( "justify-center" )
					.Add( "text-inherit" )
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

				["Group"] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof( AvatarSlots.Base )] = "-ms-2 first:ms-0 transition-transform hover:-translate-x-3 last:hover:-translate-x-0"
					}
				},

				[nameof( LumexAvatarGroup.Grid )] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof( AvatarSlots.Base )] = "m-0 hover:translate-x-0"
					}
				}
			},

			CompoundVariants = [
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexAvatar.Color )] = nameof( ThemeColor.Default ),
						[nameof( LumexAvatar.Bordered )] = bool.TrueString
					},
					Classes = new SlotCollection
					{
						[nameof( AvatarSlots.Base )] = "ring-default"
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexAvatar.Color )] = nameof( ThemeColor.Primary ),
						[nameof( LumexAvatar.Bordered )] = bool.TrueString
					},
					Classes = new SlotCollection
					{
						[nameof( AvatarSlots.Base )] = "ring-primary"
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexAvatar.Color )] = nameof( ThemeColor.Secondary ),
						[nameof( LumexAvatar.Bordered )] = bool.TrueString
					},
					Classes = new SlotCollection
					{
						[nameof( AvatarSlots.Base )] = "ring-secondary"
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexAvatar.Color )] = nameof( ThemeColor.Success ),
						[nameof( LumexAvatar.Bordered )] = bool.TrueString
					},
					Classes = new SlotCollection
					{
						[nameof( AvatarSlots.Base )] = "ring-success"
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexAvatar.Color )] = nameof( ThemeColor.Warning ),
						[nameof( LumexAvatar.Bordered )] = bool.TrueString
					},
					Classes = new SlotCollection
					{
						[nameof( AvatarSlots.Base )] = "ring-warning"
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexAvatar.Color )] = nameof( ThemeColor.Danger ),
						[nameof( LumexAvatar.Bordered )] = bool.TrueString
					},
					Classes = new SlotCollection
					{
						[nameof( AvatarSlots.Base )] = "ring-danger"
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexAvatar.Color )] = nameof( ThemeColor.Info ),
						[nameof( LumexAvatar.Bordered )] = bool.TrueString
					},
					Classes = new SlotCollection
					{
						[nameof( AvatarSlots.Base )] = "ring-info"
					}
				},
			]
		} );
	}
}

[ExcludeFromCodeCoverage]
internal static class AvatarGroup
{
	private static ComponentVariant? _variant;

	public static ComponentVariant Style( TwMerge twMerge )
	{
		var twVariants = new TwVariants( twMerge );

		return _variant ??= twVariants.Create( new VariantConfig()
		{
			Slots = new SlotCollection
			{
				[nameof( AvatarGroupSlots.Base )] = new ElementClass()
					.Add( "w-max" )
					.Add( "h-auto" )
					.Add( "flex" )
					.Add( "items-center" )
					.Add( "justify-center" )
					// focus ring
					.Add( Utils.FocusVisible ),

				[nameof( AvatarGroupSlots.Count )] = new ElementClass()
					.Add( "hover:-translate-x-0" )
			},

			Variants = new VariantCollection
			{
				[nameof( LumexAvatarGroup.Grid )] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof( AvatarGroupSlots.Base )] = "inline-grid grid-cols-4 gap-3"
					}
				}
			},

		} );
	}
}
