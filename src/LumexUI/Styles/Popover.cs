// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using TailwindMerge;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal static class Popover
{
	private static ComponentVariant? _variant;

	public static ComponentVariant Style( TwMerge twMerge )
	{
		var twVariants = new TwVariants( twMerge );

		return _variant ??= twVariants.Create( new VariantConfig()
		{
			Slots = new SlotCollection
			{
				[nameof( PopoverSlots.Base )] = new ElementClass()
					.Add( "z-0" )
					.Add( "relative" )
					.Add( "bg-transparent" )
					.ToString(),

				["Wrapper"] = new ElementClass()
					.Add( "animate-enter" )
					.ToString(),

				[nameof( PopoverSlots.Content )] = new ElementClass()
					.Add( "z-10" )
					.Add( "py-1" )
					.Add( "px-2.5" )
					.Add( "w-full" )
					.Add( "inline-flex" )
					.Add( "flex-col" )
					.Add( "items-center" )
					.Add( "justify-center" )
					.ToString(),

				[nameof( PopoverSlots.Trigger )] = new ElementClass()
					.Add( "contents" )
					.Add( "*:z-10" )
					.Add( "*:cursor-pointer" )
					.Add( "*:subpixel-antialiased" )
					.Add( "aria-expanded:*:scale-[0.97]" )
					.Add( "aria-expanded:*:opacity-focus" )
					.ToString(),

				[nameof( PopoverSlots.Arrow )] = new ElementClass()
					.Add( "z-[-1]" )
					.Add( "w-2.5" )
					.Add( "h-2.5" )
					.Add( "absolute" )
					.Add( "rotate-45" )
					.Add( "rounded-xs" )
					.ToString(),
			},

			Variants = new VariantCollection
			{
				[nameof( LumexPopover.Size )] = new VariantValueCollection
				{
					[nameof( Size.Small )] = new SlotCollection()
					{
						[nameof( PopoverSlots.Content )] = "text-tiny"
					},
					[nameof( Size.Medium )] = new SlotCollection()
					{
						[nameof( PopoverSlots.Content )] = "text-small"
					},
					[nameof( Size.Large )] = new SlotCollection()
					{
						[nameof( PopoverSlots.Content )] = "text-medium"
					},
				},

				[nameof( LumexPopover.Color )] = new VariantValueCollection
				{
					[nameof( ThemeColor.Default )] = new SlotCollection()
					{
						[nameof( PopoverSlots.Arrow )] = "bg-surface1 shadow-small",
						[nameof( PopoverSlots.Content )] = "bg-surface1"
					},
					[nameof( ThemeColor.Primary )] = new SlotCollection()
					{
						[nameof( PopoverSlots.Arrow )] = "bg-primary",
						[nameof( PopoverSlots.Content )] = ColorVariants.Solid[ThemeColor.Primary]
					},
					[nameof( ThemeColor.Secondary )] = new SlotCollection()
					{
						[nameof( PopoverSlots.Arrow )] = "bg-secondary",
						[nameof( PopoverSlots.Content )] = ColorVariants.Solid[ThemeColor.Secondary]
					},
					[nameof( ThemeColor.Success )] = new SlotCollection()
					{
						[nameof( PopoverSlots.Arrow )] = "bg-success",
						[nameof( PopoverSlots.Content )] = ColorVariants.Solid[ThemeColor.Success]
					},
					[nameof( ThemeColor.Warning )] = new SlotCollection()
					{
						[nameof( PopoverSlots.Arrow )] = "bg-warning",
						[nameof( PopoverSlots.Content )] = ColorVariants.Solid[ThemeColor.Warning]
					},
					[nameof( ThemeColor.Danger )] = new SlotCollection()
					{
						[nameof( PopoverSlots.Arrow )] = "bg-danger",
						[nameof( PopoverSlots.Content )] = ColorVariants.Solid[ThemeColor.Danger]
					},
					[nameof( ThemeColor.Info )] = new SlotCollection()
					{
						[nameof( PopoverSlots.Arrow )] = "bg-info",
						[nameof( PopoverSlots.Content )] = ColorVariants.Solid[ThemeColor.Info]
					},
				},

				[nameof( LumexPopover.Radius )] = new VariantValueCollection
				{
					[nameof( Radius.None )] = new SlotCollection()
					{
						[nameof( PopoverSlots.Content )] = "rounded-none"
					},
					[nameof( Radius.Small )] = new SlotCollection()
					{
						[nameof( PopoverSlots.Content )] = "rounded-small"
					},
					[nameof( Radius.Medium )] = new SlotCollection()
					{
						[nameof( PopoverSlots.Content )] = "rounded-medium"
					},
					[nameof( Radius.Large )] = new SlotCollection()
					{
						[nameof( PopoverSlots.Content )] = "rounded-large"
					},
					[nameof( Radius.Full )] = new SlotCollection()
					{
						[nameof( PopoverSlots.Content )] = "rounded-full"
					}
				},

				[nameof( LumexPopover.Shadow )] = new VariantValueCollection
				{
					[nameof( Shadow.None )] = new SlotCollection()
					{
						[nameof( PopoverSlots.Content )] = "shadow-none"
					},
					[nameof( Shadow.Small )] = new SlotCollection()
					{
						[nameof( PopoverSlots.Content )] = "shadow-small"
					},
					[nameof( Shadow.Medium )] = new SlotCollection()
					{
						[nameof( PopoverSlots.Content )] = "shadow-medium"
					},
					[nameof( Shadow.Large )] = new SlotCollection()
					{
						[nameof( PopoverSlots.Content )] = "shadow-large"
					}
				},
			}
		} );
	}
}
