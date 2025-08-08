// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using TailwindMerge;

using MenuItemComp = LumexUI.MenuItem;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal static class Menu
{
	private static ComponentVariant? _variant;

	public static ComponentVariant Style( TwMerge twMerge )
	{
		var twVariants = new TwVariants( twMerge );

		return _variant ??= twVariants.Create( new VariantConfig()
		{
			Slots = new SlotCollection
			{
				[nameof( MenuSlots.Base )] = new ElementClass()
					.Add( "relative" )
					.Add( "w-full" )
					.Add( "flex" )
					.Add( "flex-col" )
					.Add( "gap-1" )
					.Add( "p-1" )
					.ToString(),

				[nameof( MenuSlots.List )] = new ElementClass()
					.Add( "w-full" )
					.Add( "flex" )
					.Add( "flex-col" )
					.Add( "gap-0.5" )
					.Add( "outline-hidden" )
					.ToString(),

				[nameof( MenuSlots.EmptyContent )] = new ElementClass()
					.Add( "w-full" )
					.Add( "h-full" )
					.Add( "px-2" )
					.Add( "py-1.5" )
					.Add( "text-foreground-400" )
					.Add( "text-start" )
					.ToString()
			}
		} );
	}
}

[ExcludeFromCodeCoverage]
internal static class MenuItem
{
	private static ComponentVariant? _variant;

	public static ComponentVariant Style( TwMerge twMerge )
	{
		var twVariants = new TwVariants( twMerge );

		return _variant ??= twVariants.Create( new VariantConfig()
		{
			Slots = new SlotCollection()
			{
				[nameof( DropdownItemSlots.Base )] = new ElementClass()
					.Add( "relative" )
					.Add( "group" )
					.Add( "w-full" )
					.Add( "h-full" )
					.Add( "flex" )
					.Add( "px-2" )
					.Add( "py-1.5" )
					.Add( "gap-2" )
					.Add( "items-center" )
					.Add( "justify-between" )
					.Add( "rounded-small" )
					.Add( "cursor-pointer" )
					// transition
					.Add( "hover:transition-colors-shadow" )
					// focus ring
					.Add( Utils.FocusVisible )
					.ToString(),

				[nameof( DropdownItemSlots.Wrapper )] = new ElementClass()
					.Add( "w-full" )
					.Add( "flex" )
					.Add( "flex-col" )
					.Add( "items-start" )
					.Add( "justify-center" )
					.ToString(),

				[nameof( DropdownItemSlots.Title )] = new ElementClass()
					.Add( "flex-1" )
					.Add( "text-small" )
					.Add( "font-normal" )
					.Add( "truncate" )
					.ToString(),

				[nameof( DropdownItemSlots.Description )] = new ElementClass()
					.Add( "w-full" )
					.Add( "text-tiny" )
					.Add( "text-foreground-500" )
					.Add( "truncate" )
					.Add( "group-hover:text-current" )
					.ToString()
			},

			Variants = new VariantCollection()
			{
				[nameof( MenuItemComp.Variant )] = new VariantValueCollection()
				{
					[nameof( MenuVariant.Solid )] = new SlotCollection()
					{
						[nameof( DropdownItemSlots.Base )] = ""
					},
					[nameof( MenuVariant.Outlined )] = new SlotCollection()
					{
						[nameof( DropdownItemSlots.Base )] = "border-2 border-transparent bg-transparent"
					},
					[nameof( MenuVariant.Light )] = new SlotCollection()
					{
						[nameof( DropdownItemSlots.Base )] = "bg-transparent"
					},
					[nameof( MenuVariant.Flat )] = new SlotCollection()
					{
						[nameof( DropdownItemSlots.Base )] = ""
					},
					[nameof( MenuVariant.Shadow )] = new SlotCollection()
					{
						[nameof( DropdownItemSlots.Base )] = "hover:shadow-lg"
					}
				},

				[nameof( LumexDropdownItem.ShowDivider )] = new VariantValueCollection()
				{
					[bool.TrueString] = new SlotCollection()
					{
						[nameof( DropdownItemSlots.Base )] = new ElementClass()
							.Add( "mb-1.5" )
							.Add( "after:absolute" )
							.Add( "after:left-0" )
							.Add( "after:right-0" )
							.Add( "after:-bottom-1" )
							.Add( "after:h-px" )
							.Add( "after:bg-divider" )
							.ToString()
					}
				},

				[nameof( LumexDropdownItem.ReadOnly )] = new VariantValueCollection()
				{
					[bool.TrueString] = new SlotCollection()
					{
						[nameof( DropdownItemSlots.Base )] = "cursor-default"
					}
				},

				[nameof( LumexDropdownItem.Disabled )] = new VariantValueCollection()
				{
					[bool.TrueString] = new SlotCollection()
					{
						[nameof( DropdownItemSlots.Base )] = "opacity-disabled pointer-events-none"
					}
				}
			},

			CompoundVariants =
			[
				// solid & color
				new CompoundVariant()
				{
					Conditions = new Dictionary<string, string>()
					{
						[nameof( MenuItemComp.Variant )] = nameof( MenuVariant.Solid ),
						[nameof( MenuItemComp.Color )] = nameof( ThemeColor.Default )
					},
					Classes = new SlotCollection()
					{
						[nameof(DropdownItemSlots.Base)] = "hover:bg-default hover:text-default-foreground"
					}
				},
				new CompoundVariant()
				{
					Conditions = new Dictionary<string, string>()
					{
						[nameof( MenuItemComp.Variant )] = nameof( MenuVariant.Solid ),
						[nameof( MenuItemComp.Color )] = nameof( ThemeColor.Primary )
					},
					Classes = new SlotCollection()
					{
						[nameof(DropdownItemSlots.Base)] = "hover:bg-primary hover:text-primary-foreground"
					}
				},
				new CompoundVariant()
				{
					Conditions = new Dictionary<string, string>()
					{
						[nameof( MenuItemComp.Variant )] = nameof( MenuVariant.Solid ),
						[nameof( MenuItemComp.Color )] = nameof( ThemeColor.Secondary )
					},
					Classes = new SlotCollection()
					{
						[nameof(DropdownItemSlots.Base)] = "hover:bg-secondary hover:text-secondary-foreground"
					}
				},
				new CompoundVariant()
				{
					Conditions = new Dictionary<string, string>()
					{
						[nameof( MenuItemComp.Variant )] = nameof( MenuVariant.Solid ),
						[nameof( MenuItemComp.Color )] = nameof( ThemeColor.Success )
					},
					Classes = new SlotCollection()
					{
						[nameof(DropdownItemSlots.Base)] = "hover:bg-success hover:text-success-foreground"
					}
				},
				new CompoundVariant()
				{
					Conditions = new Dictionary<string, string>()
					{
						[nameof( MenuItemComp.Variant )] = nameof( MenuVariant.Solid ),
						[nameof( MenuItemComp.Color )] = nameof( ThemeColor.Warning )
					},
					Classes = new SlotCollection()
					{
						[nameof(DropdownItemSlots.Base)] = "hover:bg-warning hover:text-warning-foreground"
					}
				},
				new CompoundVariant()
				{
					Conditions = new Dictionary<string, string>()
					{
						[nameof( MenuItemComp.Variant )] = nameof( MenuVariant.Solid ),
						[nameof( MenuItemComp.Color )] = nameof( ThemeColor.Danger )
					},
					Classes = new SlotCollection()
					{
						[nameof(DropdownItemSlots.Base)] = "hover:bg-danger hover:text-danger-foreground"
					}
				},
				new CompoundVariant()
				{
					Conditions = new Dictionary<string, string>()
					{
						[nameof( MenuItemComp.Variant )] = nameof( MenuVariant.Solid ),
						[nameof( MenuItemComp.Color )] = nameof( ThemeColor.Info )
					},
					Classes = new SlotCollection()
					{
						[nameof(DropdownItemSlots.Base)] = "hover:bg-info hover:text-info-foreground"
					}
				},

				// shadow & color
				new CompoundVariant()
				{
					Conditions = new Dictionary<string, string>()
					{
						[nameof( MenuItemComp.Variant )] = nameof( MenuVariant.Shadow ),
						[nameof( MenuItemComp.Color )] = nameof( ThemeColor.Default )
					},
					Classes = new SlotCollection()
					{
						[nameof(DropdownItemSlots.Base)] = "hover:shadow-default/40 hover:bg-default hover:text-default-foreground"
					}
				},
				new CompoundVariant()
				{
					Conditions = new Dictionary<string, string>()
					{
						[nameof( MenuItemComp.Variant )] = nameof( MenuVariant.Shadow ),
						[nameof( MenuItemComp.Color )] = nameof( ThemeColor.Primary )
					},
					Classes = new SlotCollection()
					{
						[nameof(DropdownItemSlots.Base)] = "hover:shadow-primary/40 hover:bg-primary hover:text-primary-foreground"
					}
				},
				new CompoundVariant()
				{
					Conditions = new Dictionary<string, string>()
					{
						[nameof( MenuItemComp.Variant )] = nameof( MenuVariant.Shadow ),
						[nameof( MenuItemComp.Color )] = nameof( ThemeColor.Secondary )
					},
					Classes = new SlotCollection()
					{
						[nameof(DropdownItemSlots.Base)] = "hover:shadow-secondary/40 hover:bg-secondary hover:text-secondary-foreground"
					}
				},
				new CompoundVariant()
				{
					Conditions = new Dictionary<string, string>()
					{
						[nameof( MenuItemComp.Variant )] = nameof( MenuVariant.Shadow ),
						[nameof( MenuItemComp.Color )] = nameof( ThemeColor.Success )
					},
					Classes = new SlotCollection()
					{
						[nameof(DropdownItemSlots.Base)] = "hover:shadow-success/40 hover:bg-success hover:text-success-foreground"
					}
				},
				new CompoundVariant()
				{
					Conditions = new Dictionary<string, string>()
					{
						[nameof( MenuItemComp.Variant )] = nameof( MenuVariant.Shadow ),
						[nameof( MenuItemComp.Color )] = nameof(ThemeColor.Warning)
					},
					Classes = new SlotCollection()
					{
						[nameof(DropdownItemSlots.Base)] = "hover:shadow-warning/40 hover:bg-warning hover:text-warning-foreground"
					}
				},
				new CompoundVariant()
				{
					Conditions = new Dictionary<string, string>()
					{
						[nameof( MenuItemComp.Variant )] = nameof( MenuVariant.Shadow ),
						[nameof( MenuItemComp.Color )] = nameof( ThemeColor.Danger )
					},
					Classes = new SlotCollection()
					{
						[nameof(DropdownItemSlots.Base)] = "hover:shadow-danger/40 hover:bg-danger hover:text-danger-foreground"
					}
				},
				new CompoundVariant()
				{
					Conditions = new Dictionary<string, string>()
					{
						[nameof( MenuItemComp.Variant )] = nameof( MenuVariant.Shadow ),
						[nameof( MenuItemComp.Color )] = nameof( ThemeColor.Info )
					},
					Classes = new SlotCollection()
					{
						[nameof(DropdownItemSlots.Base)] = "hover:shadow-info/40 hover:bg-info hover:text-info-foreground"
					}
				},

				// outlined & color
				new CompoundVariant()
				{
					Conditions = new Dictionary<string, string>()
					{
						[nameof( MenuItemComp.Variant )] = nameof( MenuVariant.Outlined ),
						[nameof( MenuItemComp.Color )] = nameof( ThemeColor.Default )
					},
					Classes = new SlotCollection()
					{
						[nameof(DropdownItemSlots.Base)] = "hover:border-default"
					}
				},
				new CompoundVariant()
				{
					Conditions = new Dictionary<string, string>()
					{
						[nameof( MenuItemComp.Variant )] = nameof( MenuVariant.Outlined ),
						[nameof( MenuItemComp.Color )] = nameof( ThemeColor.Primary )
					},
					Classes = new SlotCollection()
					{
						[nameof(DropdownItemSlots.Base)] = "hover:border-primary hover:text-primary"
					}
				},
				new CompoundVariant()
				{
					Conditions = new Dictionary<string, string>()
					{
						[nameof( MenuItemComp.Variant )] = nameof( MenuVariant.Outlined ),
						[nameof( MenuItemComp.Color )] = nameof( ThemeColor.Secondary )
					},
					Classes = new SlotCollection()
					{
						[nameof(DropdownItemSlots.Base)] = "hover:border-secondary hover:text-secondary"
					}
				},
				new CompoundVariant()
				{
					Conditions = new Dictionary<string, string>()
					{
						[nameof( MenuItemComp.Variant )] = nameof( MenuVariant.Outlined ),
						[nameof( MenuItemComp.Color )] = nameof( ThemeColor.Success )
					},
					Classes = new SlotCollection()
					{
						[nameof(DropdownItemSlots.Base)] = "hover:border-success hover:text-success"
					}
				},
				new CompoundVariant()
				{
					Conditions = new Dictionary<string, string>()
					{
						[nameof( MenuItemComp.Variant )] = nameof( MenuVariant.Outlined ),
						[nameof( MenuItemComp.Color )] = nameof(ThemeColor.Warning)
					},
					Classes = new SlotCollection()
					{
						[nameof(DropdownItemSlots.Base)] = "hover:border-warning hover:text-warning"
					}
				},
				new CompoundVariant()
				{
					Conditions = new Dictionary<string, string>()
					{
						[nameof( MenuItemComp.Variant )] = nameof( MenuVariant.Outlined ),
						[nameof( MenuItemComp.Color )] = nameof( ThemeColor.Danger )
					},
					Classes = new SlotCollection()
					{
						[nameof(DropdownItemSlots.Base)] = "hover:border-danger hover:text-danger"
					}
				},
				new CompoundVariant()
				{
					Conditions = new Dictionary<string, string>()
					{
						[nameof( MenuItemComp.Variant )] = nameof( MenuVariant.Outlined ),
						[nameof( MenuItemComp.Color )] = nameof( ThemeColor.Info )
					},
					Classes = new SlotCollection()
					{
						[nameof(DropdownItemSlots.Base)] = "hover:border-info hover:text-info"
					}
				},

				// flat & color
				new CompoundVariant()
				{
					Conditions = new Dictionary<string, string>()
					{
						[nameof( MenuItemComp.Variant )] = nameof( MenuVariant.Flat ),
						[nameof( MenuItemComp.Color )] = nameof( ThemeColor.Default )
					},
					Classes = new SlotCollection()
					{
						[nameof(DropdownItemSlots.Base)] = "hover:bg-default/40 hover:text-default-foreground"
					}
				},
				new CompoundVariant()
				{
					Conditions = new Dictionary<string, string>()
					{
						[nameof( MenuItemComp.Variant )] = nameof( MenuVariant.Flat ),
						[nameof( MenuItemComp.Color )] = nameof( ThemeColor.Primary )
					},
					Classes = new SlotCollection()
					{
						[nameof(DropdownItemSlots.Base)] = "hover:bg-primary/20 hover:text-primary-600"
					}
				},
				new CompoundVariant()
				{
					Conditions = new Dictionary<string, string>()
					{
						[nameof( MenuItemComp.Variant )] = nameof( MenuVariant.Flat ),
						[nameof( MenuItemComp.Color )] = nameof( ThemeColor.Secondary )
					},
					Classes = new SlotCollection()
					{
						[nameof(DropdownItemSlots.Base)] = "hover:bg-secondary/20 hover:text-secondary-600"
					}
				},
				new CompoundVariant()
				{
					Conditions = new Dictionary<string, string>()
					{
						[nameof( MenuItemComp.Variant )] = nameof( MenuVariant.Flat ),
						[nameof( MenuItemComp.Color )] = nameof( ThemeColor.Success )
					},
					Classes = new SlotCollection()
					{
						[nameof(DropdownItemSlots.Base)] = "hover:bg-success/20 hover:text-success-800 dark:hover:text-success-600"
					}
				},
				new CompoundVariant()
				{
					Conditions = new Dictionary<string, string>()
					{
						[nameof( MenuItemComp.Variant )] = nameof( MenuVariant.Flat ),
						[nameof( MenuItemComp.Color )] = nameof(ThemeColor.Warning)
					},
					Classes = new SlotCollection()
					{
						[nameof(DropdownItemSlots.Base)] = "hover:bg-warning/20 hover:text-warning-800 dark:hover:text-warning-700"
					}
				},
				new CompoundVariant()
				{
					Conditions = new Dictionary<string, string>()
					{
						[nameof( MenuItemComp.Variant )] = nameof( MenuVariant.Flat ),
						[nameof( MenuItemComp.Color )] = nameof( ThemeColor.Danger )
					},
					Classes = new SlotCollection()
					{
						[nameof(DropdownItemSlots.Base)] = "hover:bg-danger/20 hover:text-danger-600"
					}
				},
				new CompoundVariant()
				{
					Conditions = new Dictionary<string, string>()
					{
						[nameof( MenuItemComp.Variant )] = nameof( MenuVariant.Flat ),
						[nameof( MenuItemComp.Color )] = nameof( ThemeColor.Info )
					},
					Classes = new SlotCollection()
					{
						[nameof(DropdownItemSlots.Base)] = "hover:bg-info/20 hover:text-info-600"
					}
				},

				// light & color
				new CompoundVariant()
				{
					Conditions = new Dictionary<string, string>()
					{
						[nameof( MenuItemComp.Variant )] = nameof( MenuVariant.Light ),
						[nameof( MenuItemComp.Color )] = nameof( ThemeColor.Default )
					},
					Classes = new SlotCollection()
					{
						[nameof(DropdownItemSlots.Base)] = "hover:text-default-500"
					}
				},
				new CompoundVariant()
				{
					Conditions = new Dictionary<string, string>()
					{
						[nameof( MenuItemComp.Variant )] = nameof( MenuVariant.Light ),
						[nameof( MenuItemComp.Color )] = nameof( ThemeColor.Primary )
					},
					Classes = new SlotCollection()
					{
						[nameof(DropdownItemSlots.Base)] = "hover:text-primary"
					}
				},
				new CompoundVariant()
				{
					Conditions = new Dictionary<string, string>()
					{
						[nameof( MenuItemComp.Variant )] = nameof( MenuVariant.Light ),
						[nameof( MenuItemComp.Color )] = nameof( ThemeColor.Secondary )
					},
					Classes = new SlotCollection()
					{
						[nameof(DropdownItemSlots.Base)] = "hover:text-secondary"
					}
				},
				new CompoundVariant()
				{
					Conditions = new Dictionary<string, string>()
					{
						[nameof( MenuItemComp.Variant )] = nameof( MenuVariant.Light ),
						[nameof( MenuItemComp.Color )] = nameof( ThemeColor.Success )
					},
					Classes = new SlotCollection()
					{
						[nameof(DropdownItemSlots.Base)] = "hover:text-success"
					}
				},
				new CompoundVariant()
				{
					Conditions = new Dictionary<string, string>()
					{
						[nameof( MenuItemComp.Variant )] = nameof( MenuVariant.Light ),
						[nameof( MenuItemComp.Color )] = nameof(ThemeColor.Warning)
					},
					Classes = new SlotCollection()
					{
						[nameof(DropdownItemSlots.Base)] = "hover:text-warning"
					}
				},
				new CompoundVariant()
				{
					Conditions = new Dictionary<string, string>()
					{
						[nameof( MenuItemComp.Variant )] = nameof( MenuVariant.Light ),
						[nameof( MenuItemComp.Color )] = nameof( ThemeColor.Danger )
					},
					Classes = new SlotCollection()
					{
						[nameof(DropdownItemSlots.Base)] = "hover:text-danger"
					}
				},
				new CompoundVariant()
				{
					Conditions = new Dictionary<string, string>()
					{
						[nameof( MenuItemComp.Variant )] = nameof( MenuVariant.Light ),
						[nameof( MenuItemComp.Color )] = nameof( ThemeColor.Info )
					},
					Classes = new SlotCollection()
					{
						[nameof(DropdownItemSlots.Base)] = "hover:text-info"
					}
				}
			]
		} );
	}
}
