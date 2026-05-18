// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using TailwindMerge;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal static class Progress
{
	private static ComponentVariant? _variant;

	public static ComponentVariant Style( TwMerge twMerge )
	{
		var twVariants = new TwVariants( twMerge );

		return _variant ??= twVariants.Create( new VariantConfig()
		{
			Slots = new SlotCollection
			{
				[nameof( ProgressSlots.Base )] = new ElementClass()
					.Add( "flex" )
					.Add( "flex-col" )
					.Add( "gap-2" )
					.Add( "w-full" ),

				[nameof( ProgressSlots.LabelWrapper )] = new ElementClass()
					.Add( "flex" )
					.Add( "justify-between" ),

				[nameof( ProgressSlots.Label )] = "",

				[nameof( ProgressSlots.Value )] = "",

				[nameof( ProgressSlots.Track )] = new ElementClass()
					.Add( "z-0" )
					.Add( "relative" )
					.Add( "bg-default-300/50" )
					.Add( "overflow-hidden" )
					.Add( "rtl:rotate-180" ),

				[nameof( ProgressSlots.Indicator )] = new ElementClass()
					.Add( "h-full" ),
			},

			Variants = new VariantCollection
			{
				[nameof( LumexProgress.Size )] = new VariantValueCollection
				{
					[nameof( Size.Small )] = new SlotCollection
					{
						[nameof( ProgressSlots.Track )] = "h-1",
						[nameof( ProgressSlots.Label )] = "text-small",
						[nameof( ProgressSlots.Value )] = "text-small",
					},
					[nameof( Size.Medium )] = new SlotCollection
					{
						[nameof( ProgressSlots.Track )] = "h-3",
						[nameof( ProgressSlots.Label )] = "text-medium",
						[nameof( ProgressSlots.Value )] = "text-medium",
					},
					[nameof( Size.Large )] = new SlotCollection
					{
						[nameof( ProgressSlots.Track )] = "h-5",
						[nameof( ProgressSlots.Label )] = "text-large",
						[nameof( ProgressSlots.Value )] = "text-large",
					},
				},

				[nameof( LumexProgress.Radius )] = new VariantValueCollection
				{
					[nameof( Radius.None )] = new SlotCollection
					{
						[nameof( ProgressSlots.Track )] = "rounded-none",
						[nameof( ProgressSlots.Indicator )] = "rounded-none",
					},
					[nameof( Radius.Small )] = new SlotCollection
					{
						[nameof( ProgressSlots.Track )] = "rounded-small",
						[nameof( ProgressSlots.Indicator )] = "rounded-small",
					},
					[nameof( Radius.Medium )] = new SlotCollection
					{
						[nameof( ProgressSlots.Track )] = "rounded-medium",
						[nameof( ProgressSlots.Indicator )] = "rounded-medium",
					},
					[nameof( Radius.Large )] = new SlotCollection
					{
						[nameof( ProgressSlots.Track )] = "rounded-large",
						[nameof( ProgressSlots.Indicator )] = "rounded-large",
					},
					[nameof( Radius.Full )] = new SlotCollection
					{
						[nameof( ProgressSlots.Track )] = "rounded-full",
						[nameof( ProgressSlots.Indicator )] = "rounded-full",
					},
				},

				[nameof( LumexProgress.Color )] = new VariantValueCollection
				{
					[nameof( ThemeColor.Default )] = new SlotCollection
					{
						[nameof( ProgressSlots.Indicator )] = "bg-default-400",
					},
					[nameof( ThemeColor.Primary )] = new SlotCollection
					{
						[nameof( ProgressSlots.Indicator )] = "bg-primary",
					},
					[nameof( ThemeColor.Secondary )] = new SlotCollection
					{
						[nameof( ProgressSlots.Indicator )] = "bg-secondary",
					},
					[nameof( ThemeColor.Success )] = new SlotCollection
					{
						[nameof( ProgressSlots.Indicator )] = "bg-success",
					},
					[nameof( ThemeColor.Warning )] = new SlotCollection
					{
						[nameof( ProgressSlots.Indicator )] = "bg-warning",
					},
					[nameof( ThemeColor.Danger )] = new SlotCollection
					{
						[nameof( ProgressSlots.Indicator )] = "bg-danger",
					},
					[nameof( ThemeColor.Info )] = new SlotCollection
					{
						[nameof( ProgressSlots.Indicator )] = "bg-info",
					},
				},

				[nameof( LumexProgress.Indeterminate )] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof( ProgressSlots.Indicator )] = "absolute w-full origin-left animate-indeterminate-bar",
					},
				},

				[nameof( LumexProgress.Disabled )] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof( ProgressSlots.Base )] = "opacity-disabled cursor-not-allowed",
					},
				},
			},

			CompoundVariants =
			[
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexProgress.Striped )] = bool.TrueString
					},
					Classes = new SlotCollection()
					{
						[nameof( ProgressSlots.Indicator )] = "bg-stripe-gradient",
					}
				}
			]
		} );
	}
}

