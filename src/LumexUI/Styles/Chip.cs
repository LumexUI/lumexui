// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
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
					.Add( "relative" )
					.Add( "group" )
					.Add( "max-w-fit" )
					.Add( "max-w-min" )
					.Add( "inline-flex" )
					.Add( "items-center" )
					.Add( "justify-between" )
					.Add( "whitespace-nowrap" ),

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
					// focus ring
					.Add( Utils.FocusVisible )
			},

			Variants = new VariantCollection
			{
				[nameof( LumexChip.Variant )] = new VariantValueCollection
				{
					[nameof( ChipVariant.Solid )] = new SlotCollection { },
					[nameof( ChipVariant.Outlined )] = new SlotCollection
					{
						[nameof( ChipSlots.Base )] = "border-2 bg-transparent"
					},
					[nameof( ChipVariant.Light )] = new SlotCollection
					{
						[nameof( ChipSlots.Base )] = "bg-transparent"
					},
					[nameof( ChipVariant.Flat )] = new SlotCollection { },
					[nameof( ChipVariant.Shadow )] = new SlotCollection { },
					[nameof( ChipVariant.Dot )] = new SlotCollection
					{
						[nameof( ChipSlots.Base )] = "border-2 border-default text-foreground bg-transparent"
					}
				},

				[nameof( LumexChip.Color )] = new VariantValueCollection
				{
					[nameof( ThemeColor.Default )] = new SlotCollection
					{
						[nameof( ChipSlots.Dot )] = "bg-default-400"
					},
					[nameof( ThemeColor.Primary )] = new SlotCollection
					{
						[nameof( ChipSlots.Dot )] = "bg-primary"
					},
					[nameof( ThemeColor.Secondary )] = new SlotCollection
					{
						[nameof( ChipSlots.Dot )] = "bg-secondary"
					},
					[nameof( ThemeColor.Success )] = new SlotCollection
					{
						[nameof( ChipSlots.Dot )] = "bg-success"
					},
					[nameof( ThemeColor.Warning )] = new SlotCollection
					{
						[nameof( ChipSlots.Dot )] = "bg-warning"
					},
					[nameof( ThemeColor.Danger )] = new SlotCollection
					{
						[nameof( ChipSlots.Dot )] = "bg-danger"
					},
					[nameof( ThemeColor.Info )] = new SlotCollection
					{
						[nameof( ChipSlots.Dot )] = "bg-info"
					}
				},

				[nameof( LumexChip.Size )] = new VariantValueCollection
				{
					[nameof( Size.Small )] = new SlotCollection
					{
						[nameof( ChipSlots.Base )] = "px-1 h-6 text-tiny *:data-[component=avatar]:size-4",
						[nameof( ChipSlots.Content )] = new ElementClass()
							.Add( "px-1" )
							.Add( "group-data-[has-start-content=true]:pl-0.5" )
							.Add( "group-data-[has-end-content=true]:pr-0.5" ),
						[nameof( ChipSlots.CloseButton )] = "text-medium"
					},
					[nameof( Size.Medium )] = new SlotCollection
					{
						[nameof( ChipSlots.Base )] = "px-1 h-7 text-small *:data-[component=avatar]:size-5",
						[nameof( ChipSlots.Content )] = new ElementClass()
							.Add( "px-2" )
							.Add( "group-data-[has-start-content=true]:pl-1" )
							.Add( "group-data-[has-end-content=true]:pr-1" ),
						[nameof( ChipSlots.CloseButton )] = "text-large"
					},
					[nameof( Size.Large )] = new SlotCollection
					{
						[nameof( ChipSlots.Base )] = "px-2 h-8 text-medium *:data-[component=avatar]:size-6",
						[nameof( ChipSlots.Content )] = new ElementClass()
							.Add( "px-2" )
							.Add( "group-data-[has-start-content=true]:pl-1" )
							.Add( "group-data-[has-end-content=true]:pr-1" ),
						[nameof( ChipSlots.CloseButton )] = "text-xl"
					}
				},

				[nameof( LumexChip.Radius )] = new VariantValueCollection
				{
					[nameof( Radius.None )] = new SlotCollection
					{
						[nameof( ChipSlots.Base )] = "rounded-none"
					},
					[nameof( Radius.Small )] = new SlotCollection
					{
						[nameof( ChipSlots.Base )] = "rounded-small"
					},
					[nameof( Radius.Medium )] = new SlotCollection
					{
						[nameof( ChipSlots.Base )] = "rounded-medium"
					},
					[nameof( Radius.Large )] = new SlotCollection
					{
						[nameof( ChipSlots.Base )] = "rounded-large"
					},
					[nameof( Radius.Full )] = new SlotCollection
					{
						[nameof( ChipSlots.Base )] = "rounded-full"
					}
				},

				[nameof( LumexChip.Disabled )] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof( ChipSlots.Base )] = Utils.Disabled
					}
				},
			},

			CompoundVariants =
			[
				// solid & color
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexChip.Variant )] = nameof( ChipVariant.Solid ),
						[nameof( LumexChip.Color )] = nameof( ThemeColor.Default )
					},
					Classes = new SlotCollection()
					{
						[nameof( ChipSlots.Base )] = ColorVariants.Solid[ThemeColor.Default]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexChip.Variant )] = nameof( ChipVariant.Solid ),
						[nameof( LumexChip.Color )] = nameof( ThemeColor.Primary )
					},
					Classes = new SlotCollection()
					{
						[nameof( ChipSlots.Base )] = ColorVariants.Solid[ThemeColor.Primary]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexChip.Variant )] = nameof( ChipVariant.Solid ),
						[nameof( LumexChip.Color )] = nameof( ThemeColor.Secondary )
					},
					Classes = new SlotCollection()
					{
						[nameof( ChipSlots.Base )] = ColorVariants.Solid[ThemeColor.Secondary]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexChip.Variant )] = nameof( ChipVariant.Solid ),
						[nameof( LumexChip.Color )] = nameof( ThemeColor.Success )
					},
					Classes = new SlotCollection()
					{
						[nameof( ChipSlots.Base )] = ColorVariants.Solid[ThemeColor.Success]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexChip.Variant )] = nameof( ChipVariant.Solid ),
						[nameof( LumexChip.Color )] = nameof( ThemeColor.Warning )
					},
					Classes = new SlotCollection()
					{
						[nameof( ChipSlots.Base )] = ColorVariants.Solid[ThemeColor.Warning]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexChip.Variant )] = nameof( ChipVariant.Solid ),
						[nameof( LumexChip.Color )] = nameof( ThemeColor.Danger )
					},
					Classes = new SlotCollection()
					{
						[nameof( ChipSlots.Base )] = ColorVariants.Solid[ThemeColor.Danger]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexChip.Variant )] = nameof( ChipVariant.Solid ),
						[nameof( LumexChip.Color )] = nameof( ThemeColor.Info )
					},
					Classes = new SlotCollection()
					{
						[nameof( ChipSlots.Base )] = ColorVariants.Solid[ThemeColor.Info]
					}
				},

				// shadow & color
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexChip.Variant )] = nameof( ChipVariant.Shadow ),
						[nameof( LumexChip.Color )] = nameof( ThemeColor.Default )
					},
					Classes = new SlotCollection()
					{
						[nameof( ChipSlots.Base )] = ColorVariants.Shadow[ThemeColor.Default]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexChip.Variant )] = nameof( ChipVariant.Shadow ),
						[nameof( LumexChip.Color )] = nameof( ThemeColor.Primary )
					},
					Classes = new SlotCollection()
					{
						[nameof( ChipSlots.Base )] = ColorVariants.Shadow[ThemeColor.Primary]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexChip.Variant )] = nameof( ChipVariant.Shadow ),
						[nameof( LumexChip.Color )] = nameof( ThemeColor.Secondary )
					},
					Classes = new SlotCollection()
					{
						[nameof( ChipSlots.Base )] = ColorVariants.Shadow[ThemeColor.Secondary]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexChip.Variant )] = nameof( ChipVariant.Shadow ),
						[nameof( LumexChip.Color )] = nameof( ThemeColor.Success )
					},
					Classes = new SlotCollection()
					{
						[nameof( ChipSlots.Base )] = ColorVariants.Shadow[ThemeColor.Success]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexChip.Variant )] = nameof( ChipVariant.Shadow ),
						[nameof( LumexChip.Color )] = nameof( ThemeColor.Warning )
					},
					Classes = new SlotCollection()
					{
						[nameof( ChipSlots.Base )] = ColorVariants.Shadow[ThemeColor.Warning]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexChip.Variant )] = nameof( ChipVariant.Shadow ),
						[nameof( LumexChip.Color )] = nameof( ThemeColor.Danger )
					},
					Classes = new SlotCollection()
					{
						[nameof( ChipSlots.Base )] = ColorVariants.Shadow[ThemeColor.Danger]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexChip.Variant )] = nameof( ChipVariant.Shadow ),
						[nameof( LumexChip.Color )] = nameof( ThemeColor.Info )
					},
					Classes = new SlotCollection()
					{
						[nameof( ChipSlots.Base )] = ColorVariants.Shadow[ThemeColor.Info]
					}
				},

				// outlined & color
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexChip.Variant )] = nameof( ChipVariant.Outlined ),
						[nameof( LumexChip.Color )] = nameof( ThemeColor.Default )
					},
					Classes = new SlotCollection()
					{
						[nameof( ChipSlots.Base )] = ColorVariants.Outlined[ThemeColor.Default]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexChip.Variant )] = nameof( ChipVariant.Outlined ),
						[nameof( LumexChip.Color )] = nameof( ThemeColor.Primary )
					},
					Classes = new SlotCollection()
					{
						[nameof( ChipSlots.Base )] = ColorVariants.Outlined[ThemeColor.Primary]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexChip.Variant )] = nameof( ChipVariant.Outlined ),
						[nameof( LumexChip.Color )] = nameof( ThemeColor.Secondary )
					},
					Classes = new SlotCollection()
					{
						[nameof( ChipSlots.Base )] = ColorVariants.Outlined[ThemeColor.Secondary]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexChip.Variant )] = nameof( ChipVariant.Outlined ),
						[nameof( LumexChip.Color )] = nameof( ThemeColor.Success )
					},
					Classes = new SlotCollection()
					{
						[nameof( ChipSlots.Base )] = ColorVariants.Outlined[ThemeColor.Success]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexChip.Variant )] = nameof( ChipVariant.Outlined ),
						[nameof( LumexChip.Color )] = nameof( ThemeColor.Warning )
					},
					Classes = new SlotCollection()
					{
						[nameof( ChipSlots.Base )] = ColorVariants.Outlined[ThemeColor.Warning]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexChip.Variant )] = nameof( ChipVariant.Outlined ),
						[nameof( LumexChip.Color )] = nameof( ThemeColor.Danger )
					},
					Classes = new SlotCollection()
					{
						[nameof( ChipSlots.Base )] = ColorVariants.Outlined[ThemeColor.Danger]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexChip.Variant )] = nameof( ChipVariant.Outlined ),
						[nameof( LumexChip.Color )] = nameof( ThemeColor.Info )
					},
					Classes = new SlotCollection()
					{
						[nameof( ChipSlots.Base )] = ColorVariants.Outlined[ThemeColor.Info]
					}
				},

				// flat & color
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexChip.Variant )] = nameof( ChipVariant.Flat ),
						[nameof( LumexChip.Color )] = nameof( ThemeColor.Default )
					},
					Classes = new SlotCollection()
					{
						[nameof( ChipSlots.Base )] = ColorVariants.Flat[ThemeColor.Default]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexChip.Variant )] = nameof( ChipVariant.Flat ),
						[nameof( LumexChip.Color )] = nameof( ThemeColor.Primary )
					},
					Classes = new SlotCollection()
					{
						[nameof( ChipSlots.Base )] = ColorVariants.Flat[ThemeColor.Primary]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexChip.Variant )] = nameof( ChipVariant.Flat ),
						[nameof( LumexChip.Color )] = nameof( ThemeColor.Secondary )
					},
					Classes = new SlotCollection()
					{
						[nameof( ChipSlots.Base )] = ColorVariants.Flat[ThemeColor.Secondary]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexChip.Variant )] = nameof( ChipVariant.Flat ),
						[nameof( LumexChip.Color )] = nameof( ThemeColor.Success )
					},
					Classes = new SlotCollection()
					{
						[nameof( ChipSlots.Base )] = ColorVariants.Flat[ThemeColor.Success]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexChip.Variant )] = nameof( ChipVariant.Flat ),
						[nameof( LumexChip.Color )] = nameof( ThemeColor.Warning )
					},
					Classes = new SlotCollection()
					{
						[nameof( ChipSlots.Base )] = ColorVariants.Flat[ThemeColor.Warning]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexChip.Variant )] = nameof( ChipVariant.Flat ),
						[nameof( LumexChip.Color )] = nameof( ThemeColor.Danger )
					},
					Classes = new SlotCollection()
					{
						[nameof( ChipSlots.Base )] = ColorVariants.Flat[ThemeColor.Danger]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexChip.Variant )] = nameof( ChipVariant.Flat ),
						[nameof( LumexChip.Color )] = nameof( ThemeColor.Info )
					},
					Classes = new SlotCollection()
					{
						[nameof( ChipSlots.Base )] = ColorVariants.Flat[ThemeColor.Info]
					}
				},

				// light & color
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexChip.Variant )] = nameof( ChipVariant.Light ),
						[nameof( LumexChip.Color )] = nameof( ThemeColor.Default )
					},
					Classes = new SlotCollection()
					{
						[nameof( ChipSlots.Base )] = ColorVariants.Light[ThemeColor.Default]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexChip.Variant )] = nameof( ChipVariant.Light ),
						[nameof( LumexChip.Color )] = nameof( ThemeColor.Primary )
					},
					Classes = new SlotCollection()
					{
						[nameof( ChipSlots.Base )] = ColorVariants.Light[ThemeColor.Primary]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexChip.Variant )] = nameof( ChipVariant.Light ),
						[nameof( LumexChip.Color )] = nameof( ThemeColor.Secondary )
					},
					Classes = new SlotCollection()
					{
						[nameof( ChipSlots.Base )] = ColorVariants.Light[ThemeColor.Secondary]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexChip.Variant )] = nameof( ChipVariant.Light ),
						[nameof( LumexChip.Color )] = nameof( ThemeColor.Success )
					},
					Classes = new SlotCollection()
					{
						[nameof( ChipSlots.Base )] = ColorVariants.Light[ThemeColor.Success]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexChip.Variant )] = nameof( ChipVariant.Light ),
						[nameof( LumexChip.Color )] = nameof( ThemeColor.Warning )
					},
					Classes = new SlotCollection()
					{
						[nameof( ChipSlots.Base )] = ColorVariants.Light[ThemeColor.Warning]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexChip.Variant )] = nameof( ChipVariant.Light ),
						[nameof( LumexChip.Color )] = nameof( ThemeColor.Danger )
					},
					Classes = new SlotCollection()
					{
						[nameof( ChipSlots.Base )] = ColorVariants.Light[ThemeColor.Danger]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexChip.Variant )] = nameof( ChipVariant.Light ),
						[nameof( LumexChip.Color )] = nameof( ThemeColor.Info )
					},
					Classes = new SlotCollection()
					{
						[nameof( ChipSlots.Base )] = ColorVariants.Light[ThemeColor.Info]
					}
				}
			]
		} );
	}
}