// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using TailwindMerge;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal static class Badge
{
	private static ComponentVariant? _variant;

	public static ComponentVariant Style( TwMerge twMerge )
	{
		var twVariants = new TwVariants( twMerge );

		return _variant ??= twVariants.Create( new VariantConfig()
		{
			Slots = new SlotCollection
			{
				[nameof( BadgeSlots.Base )] = new ElementClass()
					.Add( "relative" )
					.Add( "inline-flex" )
					.Add( "shrink-0" ),

				[nameof( BadgeSlots.Badge )] = new ElementClass()
					.Add( "absolute" )
					.Add( "z-10" )
					.Add( "flex" )
					.Add( "flex-wrap" )
					.Add( "rounded-full" )
					.Add( "whitespace-nowrap" )
					.Add( "place-content-center" )
					.Add( "origin-center" )
					.Add( "items-center" )
					.Add( "text-inherit" )
					.Add( "select-none" )
					.Add( "scale-100" )
					.Add( "opacity-100" )
					.Add( "data-[invisible=true]:scale-0" )
					.Add( "data-[invisible=true]:opacity-0" )
					// transition
					.Add( "transition-transform-opacity" )
					.Add( "duration-300" )
			},

			Variants = new VariantCollection
			{
				[nameof( LumexBadge.Size )] = new VariantValueCollection
				{
					[nameof( Size.Small )] = new SlotCollection
					{
						[nameof( BadgeSlots.Badge )] = "px-1 text-tiny",
					},
					[nameof( Size.Medium )] = new SlotCollection
					{
						[nameof( BadgeSlots.Badge )] = "px-1 text-small",
					},
					[nameof( Size.Large )] = new SlotCollection
					{
						[nameof( BadgeSlots.Badge )] = "px-1 text-small",
					}
				},

				[nameof( LumexBadge.ShowOutline )] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof( BadgeSlots.Badge )] = "border-2 border-background",
					},
					[bool.FalseString] = new SlotCollection
					{
						[nameof( BadgeSlots.Badge )] = "border-transparent border-0",
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
						[nameof( LumexBadge.Variant )] = nameof( BadgeVariant.Solid ),
						[nameof( LumexBadge.Color )] = nameof( ThemeColor.Default )
					},
					Classes = new SlotCollection()
					{
						[nameof( BadgeSlots.Badge )] = ColorVariants.Solid[ThemeColor.Default]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexBadge.Variant )] = nameof( BadgeVariant.Solid ),
						[nameof( LumexBadge.Color )] = nameof( ThemeColor.Primary )
					},
					Classes = new SlotCollection()
					{
						[nameof( BadgeSlots.Badge )] = ColorVariants.Solid[ThemeColor.Primary]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexBadge.Variant )] = nameof( BadgeVariant.Solid ),
						[nameof( LumexBadge.Color )] = nameof( ThemeColor.Secondary )
					},
					Classes = new SlotCollection()
					{
						[nameof( BadgeSlots.Badge )] = ColorVariants.Solid[ThemeColor.Secondary]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexBadge.Variant )] = nameof( BadgeVariant.Solid ),
						[nameof( LumexBadge.Color )] = nameof( ThemeColor.Success )
					},
					Classes = new SlotCollection()
					{
						[nameof( BadgeSlots.Badge )] = ColorVariants.Solid[ThemeColor.Success]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexBadge.Variant )] = nameof( BadgeVariant.Solid ),
						[nameof( LumexBadge.Color )] = nameof( ThemeColor.Warning )
					},
					Classes = new SlotCollection()
					{
						[nameof( BadgeSlots.Badge )] = ColorVariants.Solid[ThemeColor.Warning]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexBadge.Variant )] = nameof( BadgeVariant.Solid ),
						[nameof( LumexBadge.Color )] = nameof( ThemeColor.Danger )
					},
					Classes = new SlotCollection()
					{
						[nameof( BadgeSlots.Badge )] = ColorVariants.Solid[ThemeColor.Danger]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexBadge.Variant )] = nameof( BadgeVariant.Solid ),
						[nameof( LumexBadge.Color )] = nameof( ThemeColor.Info )
					},
					Classes = new SlotCollection()
					{
						[nameof( BadgeSlots.Badge )] = ColorVariants.Solid[ThemeColor.Info]
					}
				},

				// shadow & color
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexBadge.Variant )] = nameof( BadgeVariant.Shadow ),
						[nameof( LumexBadge.Color )] = nameof( ThemeColor.Default )
					},
					Classes = new SlotCollection()
					{
						[nameof( BadgeSlots.Badge )] = ColorVariants.Shadow[ThemeColor.Default]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexBadge.Variant )] = nameof( BadgeVariant.Shadow ),
						[nameof( LumexBadge.Color )] = nameof( ThemeColor.Primary )
					},
					Classes = new SlotCollection()
					{
						[nameof( BadgeSlots.Badge )] = ColorVariants.Shadow[ThemeColor.Primary]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexBadge.Variant )] = nameof( BadgeVariant.Shadow ),
						[nameof( LumexBadge.Color )] = nameof( ThemeColor.Secondary )
					},
					Classes = new SlotCollection()
					{
						[nameof( BadgeSlots.Badge )] = ColorVariants.Shadow[ThemeColor.Secondary]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexBadge.Variant )] = nameof( BadgeVariant.Shadow ),
						[nameof( LumexBadge.Color )] = nameof( ThemeColor.Success )
					},
					Classes = new SlotCollection()
					{
						[nameof( BadgeSlots.Badge )] = ColorVariants.Shadow[ThemeColor.Success]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexBadge.Variant )] = nameof( BadgeVariant.Shadow ),
						[nameof( LumexBadge.Color )] = nameof( ThemeColor.Warning )
					},
					Classes = new SlotCollection()
					{
						[nameof( BadgeSlots.Badge )] = ColorVariants.Shadow[ThemeColor.Warning]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexBadge.Variant )] = nameof( BadgeVariant.Shadow ),
						[nameof( LumexBadge.Color )] = nameof( ThemeColor.Danger )
					},
					Classes = new SlotCollection()
					{
						[nameof( BadgeSlots.Badge )] = ColorVariants.Shadow[ThemeColor.Danger]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexBadge.Variant )] = nameof( BadgeVariant.Shadow ),
						[nameof( LumexBadge.Color )] = nameof( ThemeColor.Info )
					},
					Classes = new SlotCollection()
					{
						[nameof( BadgeSlots.Badge )] = ColorVariants.Shadow[ThemeColor.Info]
					}
				},

				// flat & color
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexBadge.Variant )] = nameof( BadgeVariant.Flat ),
						[nameof( LumexBadge.Color )] = nameof( ThemeColor.Default )
					},
					Classes = new SlotCollection()
					{
						[nameof( BadgeSlots.Badge )] = "bg-default-300/80 text-default-700 dark:bg-default/40"
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexBadge.Variant )] = nameof( BadgeVariant.Flat ),
						[nameof( LumexBadge.Color )] = nameof( ThemeColor.Primary )
					},
					Classes = new SlotCollection()
					{
						[nameof( BadgeSlots.Badge )] = "bg-primary-200/80 text-primary-600 dark:bg-primary/20"
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexBadge.Variant )] = nameof( BadgeVariant.Flat ),
						[nameof( LumexBadge.Color )] = nameof( ThemeColor.Secondary )
					},
					Classes = new SlotCollection()
					{
						[nameof( BadgeSlots.Badge )] = "bg-secondary-200/80 text-secondary-600 dark:bg-secondary/20"
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexBadge.Variant )] = nameof( BadgeVariant.Flat ),
						[nameof( LumexBadge.Color )] = nameof( ThemeColor.Success )
					},
					Classes = new SlotCollection()
					{
						[nameof( BadgeSlots.Badge )] = "bg-success-200/80 text-success-700 dark:bg-success/20 dark:text-success-600"
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexBadge.Variant )] = nameof( BadgeVariant.Flat ),
						[nameof( LumexBadge.Color )] = nameof( ThemeColor.Warning )
					},
					Classes = new SlotCollection()
					{
						[nameof( BadgeSlots.Badge )] = "bg-warning-200/80 text-warning-800 dark:bg-warning/20 dark:text-warning-700"
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexBadge.Variant )] = nameof( BadgeVariant.Flat ),
						[nameof( LumexBadge.Color )] = nameof( ThemeColor.Danger )
					},
					Classes = new SlotCollection()
					{
						[nameof( BadgeSlots.Badge )] = "bg-danger-200/80 text-danger-600 dark:bg-danger/20"
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexBadge.Variant )] = nameof( BadgeVariant.Flat ),
						[nameof( LumexBadge.Color )] = nameof( ThemeColor.Info )
					},
					Classes = new SlotCollection()
					{
						[nameof( BadgeSlots.Badge )] = "bg-info-200/80 text-info-600 dark:bg-info/20"
					}
				},

				// isOneChar / size
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexBadge.OneChar )] = bool.TrueString,
						[nameof( LumexBadge.Size )] = nameof( Size.Small ),
					},
					Classes = new SlotCollection()
					{
						[nameof( BadgeSlots.Badge )] = "w-4 h-4 min-w-4 min-h-4"
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexBadge.OneChar )] = bool.TrueString,
						[nameof( LumexBadge.Size )] = nameof( Size.Medium ),
					},
					Classes = new SlotCollection()
					{
						[nameof( BadgeSlots.Badge )] = "w-5 h-5 min-w-5 min-h-5"
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexBadge.OneChar )] = bool.TrueString,
						[nameof( LumexBadge.Size )] = nameof( Size.Large ),
					},
					Classes = new SlotCollection()
					{
						[nameof( BadgeSlots.Badge )] = "w-6 h-6 min-w-6 min-h-6"
					}
				},

				// isDot / size
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexBadge.Dot )] = bool.TrueString,
						[nameof( LumexBadge.Size )] = nameof( Size.Small ),
					},
					Classes = new SlotCollection()
					{
						[nameof( BadgeSlots.Badge )] = "w-3 h-3 min-w-3 min-h-3"
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexBadge.Dot )] = bool.TrueString,
						[nameof( LumexBadge.Size )] = nameof( Size.Medium ),
					},
					Classes = new SlotCollection()
					{
						[nameof( BadgeSlots.Badge )] = "w-3.5 h-3.5 min-w-3.5 min-h-3.5"
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexBadge.Dot )] = bool.TrueString,
						[nameof( LumexBadge.Size )] = nameof( Size.Large ),
					},
					Classes = new SlotCollection()
					{
						[nameof( BadgeSlots.Badge )] = "w-4 h-4 min-w-4 min-h-4"
					}
				},

				// placement
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexBadge.Placement )] = nameof( BadgePlacement.TopStart ),
					},
					Classes = new SlotCollection()
					{
						[nameof( BadgeSlots.Badge )] = "top-[10%] left-[10%] -translate-x-1/2 -translate-y-1/2"
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexBadge.Placement )] = nameof( BadgePlacement.TopEnd ),
					},
					Classes = new SlotCollection()
					{
						[nameof( BadgeSlots.Badge )] = "top-[10%] right-[10%] translate-x-1/2 -translate-y-1/2"
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexBadge.Placement )] = nameof( BadgePlacement.BottomStart ),
					},
					Classes = new SlotCollection()
					{
						[nameof( BadgeSlots.Badge )] = "bottom-[10%] left-[10%] -translate-x-1/2 translate-y-1/2"
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexBadge.Placement )] = nameof( BadgePlacement.BottomEnd ),
					},
					Classes = new SlotCollection()
					{
						[nameof( BadgeSlots.Badge )] = "bottom-[10%] right-[10%] translate-x-1/2 translate-y-1/2"
					}
				},
			]
		} );
	}
}