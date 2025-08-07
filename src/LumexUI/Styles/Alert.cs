// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using TailwindMerge;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal static class Alert
{
	private static ComponentVariant? _variant;

	public static ComponentVariant Style( TwMerge twMerge )
	{
		var twVariants = new TwVariants( twMerge );

		return _variant ??= twVariants.Create( new VariantConfig()
		{
			Slots = new SlotCollection
			{
				[nameof( AlertSlots.Base )] = new ElementClass()
					.Add( "w-full" )
					.Add( "flex" )
					.Add( "py-3" )
					.Add( "px-4" )
					.Add( "gap-x-1" )
					.Add( "items-start" ),

				[nameof( AlertSlots.MainWrapper )] = new ElementClass()
					.Add( "h-full" )
					.Add( "min-h-10" )
					.Add( "ms-2" )
					.Add( "flex" )
					.Add( "flex-col" )
					.Add( "grow" )
					.Add( "items-start" )
					.Add( "justify-center" )
					.Add( "text-small" ),

				[nameof( AlertSlots.Title )] = new ElementClass()
					.Add( "w-full" )
					.Add( "font-medium" )
					.Add( "text-small" ),

				[nameof( AlertSlots.Description )] = new ElementClass()
					.Add( "w-full" )
					.Add( "text-small" ),

				[nameof( AlertSlots.CloseButton )] = new ElementClass()
					.Add( "relative" )
					.Add( "h-8" )
					.Add( "w-8" )
					.Add( "min-w-8" )
					.Add( "p-0" )
					.Add( "translate-x-1" )
					.Add( "-translate-y-1" ),

				[nameof( AlertSlots.IconWrapper )] = new ElementClass()
					.Add( "size-9" )
					.Add( "my-0.5" )
					.Add( "flex" )
					.Add( "shrink-0" )
					.Add( "items-center" )
					.Add( "justify-center" )
					.Add( "rounded-full" ),

				[nameof( AlertSlots.Icon )] = new ElementClass()
			},

			Variants = new VariantCollection
			{
				[nameof( LumexAlert.Variant )] = new VariantValueCollection
				{
					[nameof( AlertVariant.Outlined )] = new SlotCollection
					{
						[nameof( AlertSlots.Base )] = "border bg-transparent",
						[nameof( AlertSlots.IconWrapper )] = "shadow-small",
					},
					[nameof( AlertVariant.Flat )] = new SlotCollection
					{
						[nameof( AlertSlots.IconWrapper )] = "border shadow-small",
					},
					[nameof( AlertVariant.Faded )] = new SlotCollection
					{
						[nameof( AlertSlots.Base )] = "border",
						[nameof( AlertSlots.IconWrapper )] = "border shadow-small",
					}
				},

				[nameof( LumexAlert.Radius )] = new VariantValueCollection
				{
					[nameof( Radius.None )] = new SlotCollection
					{
						[nameof( AlertSlots.Base )] = "rounded-none"
					},
					[nameof( Radius.Small )] = new SlotCollection
					{
						[nameof( AlertSlots.Base )] = "rounded-small"
					},
					[nameof( Radius.Medium )] = new SlotCollection
					{
						[nameof( AlertSlots.Base )] = "rounded-medium"
					},
					[nameof( Radius.Large )] = new SlotCollection
					{
						[nameof( AlertSlots.Base )] = "rounded-large"
					},
					[nameof( Radius.Full )] = new SlotCollection
					{
						[nameof( AlertSlots.Base )] = "rounded-full"
					}
				},

				[nameof( LumexAlert.HideIcon )] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof( AlertSlots.IconWrapper )] = "hidden"
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
						[nameof( LumexAlert.Variant )] = nameof( AlertVariant.Solid ),
						[nameof( LumexAlert.Color )] = nameof( ThemeColor.Default )
					},
					Classes = new SlotCollection
					{
						[nameof( AlertSlots.Base )] = ColorVariants.Solid[ThemeColor.Default],
						[nameof( AlertSlots.CloseButton )] = "hover:bg-default-100",
						[nameof( AlertSlots.Icon )] = "text-default-foreground",
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexAlert.Variant )] = nameof( AlertVariant.Solid ),
						[nameof( LumexAlert.Color )] = nameof( ThemeColor.Primary )
					},
					Classes = new SlotCollection
					{
						[nameof( AlertSlots.Base )] = ColorVariants.Solid[ThemeColor.Primary]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexAlert.Variant )] = nameof( AlertVariant.Solid ),
						[nameof( LumexAlert.Color )] = nameof( ThemeColor.Secondary )
					},
					Classes = new SlotCollection
					{
						[nameof( AlertSlots.Base )] = ColorVariants.Solid[ThemeColor.Secondary]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexAlert.Variant )] = nameof( AlertVariant.Solid ),
						[nameof( LumexAlert.Color )] = nameof( ThemeColor.Success )
					},
					Classes = new SlotCollection
					{
						[nameof( AlertSlots.Base )] = ColorVariants.Solid[ThemeColor.Success]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexAlert.Variant )] = nameof( AlertVariant.Solid ),
						[nameof( LumexAlert.Color )] = nameof( ThemeColor.Warning )
					},
					Classes = new SlotCollection
					{
						[nameof( AlertSlots.Base )] = ColorVariants.Solid[ThemeColor.Warning]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexAlert.Variant )] = nameof( AlertVariant.Solid ),
						[nameof( LumexAlert.Color )] = nameof( ThemeColor.Danger )
					},
					Classes = new SlotCollection
					{
						[nameof( AlertSlots.Base )] = ColorVariants.Solid[ThemeColor.Danger]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexAlert.Variant )] = nameof( AlertVariant.Solid ),
						[nameof( LumexAlert.Color )] = nameof( ThemeColor.Info )
					},
					Classes = new SlotCollection
					{
						[nameof( AlertSlots.Base )] = ColorVariants.Solid[ThemeColor.Info]
					}
				},

				// flat & color
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexAlert.Variant )] = nameof( AlertVariant.Flat ),
						[nameof( LumexAlert.Color )] = nameof( ThemeColor.Default )
					},
					Classes = new SlotCollection
					{
						[nameof( AlertSlots.Base )] = new ElementClass()
							.Add( "bg-default-100 dark:bg-default-50/50" )
							.Add( "text-default-foreground" ),
						[nameof( AlertSlots.Description )] = "text-default-600",
						[nameof( AlertSlots.CloseButton )] = "text-default-400",
						[nameof( AlertSlots.IconWrapper )] = "bg-default-50 dark:bg-default-100 border-default-200 dark:border-default-100",
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexAlert.Variant )] = nameof( AlertVariant.Flat ),
						[nameof( LumexAlert.Color )] = nameof( ThemeColor.Primary )
					},
					Classes = new SlotCollection
					{
						[nameof( AlertSlots.Base )] = new ElementClass()
							.Add( ColorVariants.Flat[ThemeColor.Primary] )
							.Add( "bg-primary-50 dark:bg-primary-50/15" ),
						[nameof( AlertSlots.CloseButton )] = "hover:bg-primary/15",
						[nameof( AlertSlots.IconWrapper )] = "bg-primary-50 dark:bg-primary-50/75 border-primary-100 dark:border-primary-50",
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexAlert.Variant )] = nameof( AlertVariant.Flat ),
						[nameof( LumexAlert.Color )] = nameof( ThemeColor.Secondary )
					},
					Classes = new SlotCollection
					{
						[nameof( AlertSlots.Base )] = new ElementClass()
							.Add( ColorVariants.Flat[ThemeColor.Secondary] )
							.Add( "bg-secondary-50 dark:bg-secondary-50/15" ),
						[nameof( AlertSlots.CloseButton )] = "hover:bg-secondary/15",
						[nameof( AlertSlots.IconWrapper )] = "bg-secondary-50 dark:bg-secondary-50/75 border-secondary-100 dark:border-secondary-50",
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexAlert.Variant )] = nameof( AlertVariant.Flat ),
						[nameof( LumexAlert.Color )] = nameof( ThemeColor.Success )
					},
					Classes = new SlotCollection
					{
						[nameof( AlertSlots.Base )] = new ElementClass()
							.Add( ColorVariants.Flat[ThemeColor.Success] )
							.Add( "bg-success-50 dark:bg-success-50/15" ),
						[nameof( AlertSlots.CloseButton )] = "hover:bg-success/15",
						[nameof( AlertSlots.IconWrapper )] = "bg-success-50 dark:bg-success-50/75 border-success-100 dark:border-success-50",
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexAlert.Variant )] = nameof( AlertVariant.Flat ),
						[nameof( LumexAlert.Color )] = nameof( ThemeColor.Warning )
					},
					Classes = new SlotCollection
					{
						[nameof( AlertSlots.Base )] = new ElementClass()
							.Add( ColorVariants.Flat[ThemeColor.Warning] )
							.Add( "bg-warning-50 dark:bg-warning-50/15" ),
						[nameof( AlertSlots.CloseButton )] = "hover:bg-warning/15",
						[nameof( AlertSlots.IconWrapper )] = "bg-warning-50 dark:bg-warning-50/75 border-warning-200 dark:border-warning-50",
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexAlert.Variant )] = nameof( AlertVariant.Flat ),
						[nameof( LumexAlert.Color )] = nameof( ThemeColor.Danger )
					},
					Classes = new SlotCollection
					{
						[nameof( AlertSlots.Base )] = new ElementClass()
							.Add( ColorVariants.Flat[ThemeColor.Danger] )
							.Add( "bg-danger-50 dark:bg-danger-50/15" ),
						[nameof( AlertSlots.CloseButton )] = "hover:bg-danger/15",
						[nameof( AlertSlots.IconWrapper )] = "bg-danger-50 dark:bg-danger-50/75 border-danger-100 dark:border-danger-50",
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexAlert.Variant )] = nameof( AlertVariant.Flat ),
						[nameof( LumexAlert.Color )] = nameof( ThemeColor.Info )
					},
					Classes = new SlotCollection
					{
						[nameof( AlertSlots.Base )] = new ElementClass()
							.Add( ColorVariants.Flat[ThemeColor.Info] )
							.Add( "bg-info-50 dark:bg-info-50/15" ),
						[nameof( AlertSlots.CloseButton )] = "hover:bg-info/15",
						[nameof( AlertSlots.IconWrapper )] = "bg-info-50 dark:bg-info-50/75 border-info-100 dark:border-info-50",
					}
				},

				// faded & color
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexAlert.Variant )] = nameof( AlertVariant.Faded ),
						[nameof( LumexAlert.Color )] = nameof( ThemeColor.Default )
					},
					Classes = new SlotCollection
					{
						[nameof( AlertSlots.Base )] = new ElementClass()
							.Add( "bg-default-100 dark:bg-default-50/50" )
							.Add( "border-default-300 dark:border-default-200" )
							.Add( "text-default-foreground" ),
						[nameof( AlertSlots.Description )] = "text-default-600",
						[nameof( AlertSlots.CloseButton )] = "text-default-400",
						[nameof( AlertSlots.IconWrapper )] = "bg-default-50 dark:bg-default-100 border-default-200 dark:border-default-100",
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexAlert.Variant )] = nameof( AlertVariant.Faded ),
						[nameof( LumexAlert.Color )] = nameof( ThemeColor.Primary )
					},
					Classes = new SlotCollection
					{
						[nameof( AlertSlots.Base )] = new ElementClass()
							.Add( ColorVariants.Flat[ThemeColor.Primary] )
							.Add( "bg-primary-50 dark:bg-primary-50/15" )
							.Add( "border-primary-200 dark:border-primary-100" ),
						[nameof( AlertSlots.CloseButton )] = "hover:bg-primary/15",
						[nameof( AlertSlots.IconWrapper )] = "bg-primary-50 dark:bg-primary-50/75 border-primary-100 dark:border-primary-50",
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexAlert.Variant )] = nameof( AlertVariant.Faded ),
						[nameof( LumexAlert.Color )] = nameof( ThemeColor.Secondary )
					},
					Classes = new SlotCollection
					{
						[nameof( AlertSlots.Base )] = new ElementClass()
							.Add( ColorVariants.Flat[ThemeColor.Secondary] )
							.Add( "bg-secondary-50 dark:bg-secondary-50/15" )
							.Add( "border-secondary-200 dark:border-secondary-100" ),
						[nameof( AlertSlots.CloseButton )] = "hover:bg-secondary/15",
						[nameof( AlertSlots.IconWrapper )] = "bg-secondary-50 dark:bg-secondary-50/75 border-secondary-100 dark:border-secondary-50",
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexAlert.Variant )] = nameof( AlertVariant.Faded ),
						[nameof( LumexAlert.Color )] = nameof( ThemeColor.Success )
					},
					Classes = new SlotCollection
					{
						[nameof( AlertSlots.Base )] = new ElementClass()
							.Add( ColorVariants.Flat[ThemeColor.Success] )
							.Add( "bg-success-50 dark:bg-success-50/15" )
							.Add( "border-success-300 dark:border-success-100" ),
						[nameof( AlertSlots.CloseButton )] = "hover:bg-success/15",
						[nameof( AlertSlots.IconWrapper )] = "bg-success-50 dark:bg-success-50/75 border-success-100 dark:border-success-50",
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexAlert.Variant )] = nameof( AlertVariant.Faded ),
						[nameof( LumexAlert.Color )] = nameof( ThemeColor.Warning )
					},
					Classes = new SlotCollection
					{
						[nameof( AlertSlots.Base )] = new ElementClass()
							.Add( ColorVariants.Flat[ThemeColor.Warning] )
							.Add( "bg-warning-50 dark:bg-warning-50/15" )
							.Add( "border-warning-300 dark:border-warning-100" ),
						[nameof( AlertSlots.CloseButton )] = "hover:bg-warning/15",
						[nameof( AlertSlots.IconWrapper )] = "bg-warning-50 dark:bg-warning-50/75 border-warning-200 dark:border-warning-50",
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexAlert.Variant )] = nameof( AlertVariant.Faded ),
						[nameof( LumexAlert.Color )] = nameof( ThemeColor.Danger )
					},
					Classes = new SlotCollection
					{
						[nameof( AlertSlots.Base )] = new ElementClass()
							.Add( ColorVariants.Flat[ThemeColor.Danger] )
							.Add( "bg-danger-50 dark:bg-danger-50/15" )
							.Add( "border-danger-200 dark:border-danger-100" ),
						[nameof( AlertSlots.CloseButton )] = "hover:bg-danger/15",
						[nameof( AlertSlots.IconWrapper )] = "bg-danger-50 dark:bg-danger-50/75 border-danger-100 dark:border-danger-50",
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexAlert.Variant )] = nameof( AlertVariant.Faded ),
						[nameof( LumexAlert.Color )] = nameof( ThemeColor.Info )
					},
					Classes = new SlotCollection
					{
						[nameof( AlertSlots.Base )] = new ElementClass()
							.Add( ColorVariants.Flat[ThemeColor.Info] )
							.Add( "bg-info-50 dark:bg-info-50/15" )
							.Add( "border-info-200 dark:border-info-100" ),
						[nameof( AlertSlots.CloseButton )] = "hover:bg-info/15",
						[nameof( AlertSlots.IconWrapper )] = "bg-info-50 dark:bg-info-50/75 border-info-100 dark:border-info-50",
					}
				},

				// outlined & color
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexAlert.Variant )] = nameof( AlertVariant.Outlined ),
						[nameof( LumexAlert.Color )] = nameof( ThemeColor.Default )
					},
					Classes = new SlotCollection
					{
						[nameof( AlertSlots.Base )] = ColorVariants.Outlined[ThemeColor.Default],
						[nameof( AlertSlots.Description )] = "text-default-600",
						[nameof( AlertSlots.CloseButton )] = "text-default-400",
						[nameof( AlertSlots.IconWrapper )] = "bg-default-200 dark:bg-default-100",
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexAlert.Variant )] = nameof( AlertVariant.Outlined ),
						[nameof( LumexAlert.Color )] = nameof( ThemeColor.Primary )
					},
					Classes = new SlotCollection
					{
						[nameof( AlertSlots.Base )] = ColorVariants.Outlined[ThemeColor.Primary],
						[nameof( AlertSlots.CloseButton )] = "hover:bg-primary-50",
						[nameof( AlertSlots.IconWrapper )] = "bg-primary-100 dark:bg-primary-50",
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexAlert.Variant )] = nameof( AlertVariant.Outlined ),
						[nameof( LumexAlert.Color )] = nameof( ThemeColor.Secondary )
					},
					Classes = new SlotCollection
					{
						[nameof( AlertSlots.Base )] = ColorVariants.Outlined[ThemeColor.Secondary],
						[nameof( AlertSlots.CloseButton )] = "hover:bg-secondary-50",
						[nameof( AlertSlots.IconWrapper )] = "bg-secondary-100 dark:bg-secondary-50",
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexAlert.Variant )] = nameof( AlertVariant.Outlined ),
						[nameof( LumexAlert.Color )] = nameof( ThemeColor.Success )
					},
					Classes = new SlotCollection
					{
						[nameof( AlertSlots.Base )] = ColorVariants.Outlined[ThemeColor.Success],
						[nameof( AlertSlots.CloseButton )] = "hover:bg-success-100",
						[nameof( AlertSlots.IconWrapper )] = "bg-success-100 dark:bg-success-50",
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexAlert.Variant )] = nameof( AlertVariant.Outlined ),
						[nameof( LumexAlert.Color )] = nameof( ThemeColor.Warning )
					},
					Classes = new SlotCollection
					{
						[nameof( AlertSlots.Base )] = ColorVariants.Outlined[ThemeColor.Warning],
						[nameof( AlertSlots.CloseButton )] = "hover:bg-warning-50",
						[nameof( AlertSlots.IconWrapper )] = "bg-warning-100 dark:bg-warning-50",
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexAlert.Variant )] = nameof( AlertVariant.Outlined ),
						[nameof( LumexAlert.Color )] = nameof( ThemeColor.Danger )
					},
					Classes = new SlotCollection
					{
						[nameof( AlertSlots.Base )] = ColorVariants.Outlined[ThemeColor.Danger],
						[nameof( AlertSlots.CloseButton )] = "hover:bg-danger-50",
						[nameof( AlertSlots.IconWrapper )] = "bg-danger-100 dark:bg-danger-50",
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexAlert.Variant )] = nameof( AlertVariant.Outlined ),
						[nameof( LumexAlert.Color )] = nameof( ThemeColor.Info )
					},
					Classes = new SlotCollection
					{
						[nameof( AlertSlots.Base )] = ColorVariants.Outlined[ThemeColor.Info],
						[nameof( AlertSlots.CloseButton )] = "hover:bg-info-50",
						[nameof( AlertSlots.IconWrapper )] = "bg-info-100 dark:bg-info-50",
					}
				},
			]
		} );
	}
}