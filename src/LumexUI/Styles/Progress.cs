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

				[nameof( ProgressSlots.Label )] = new ElementClass()
					.Add( "text-small" )
					.Add( "font-medium" )
					.Add( "text-foreground" ),

				[nameof( ProgressSlots.Value )] = new ElementClass()
					.Add( "text-small" )
					.Add( "font-medium" )
					.Add( "text-foreground" ),

				[nameof( ProgressSlots.Track )] = new ElementClass()
					.Add( "relative" )
					.Add( "w-full" )
					.Add( "overflow-hidden" )
					.Add( "rounded-full" )
					.Add( "bg-default-200" )
					.Add( "dark:bg-default-100" ),

				[nameof( ProgressSlots.Indicator )] = new ElementClass()
					.Add( "h-full" )
					.Add( "rounded-full" )
					.Add( "transition-all" )
					.Add( "duration-500" )
					.Add( "ease-in-out" ),
			},

			Variants = new VariantCollection
			{
				[nameof( LumexProgress.Size )] = new VariantValueCollection
				{
					[nameof( Size.Small )] = new SlotCollection
					{
						[nameof( ProgressSlots.Track )] = "h-1",
						[nameof( ProgressSlots.Label )] = "text-tiny",
						[nameof( ProgressSlots.Value )] = "text-tiny",
					},
					[nameof( Size.Medium )] = new SlotCollection
					{
						[nameof( ProgressSlots.Track )] = "h-2",
						[nameof( ProgressSlots.Label )] = "text-small",
						[nameof( ProgressSlots.Value )] = "text-small",
					},
					[nameof( Size.Large )] = new SlotCollection
					{
						[nameof( ProgressSlots.Track )] = "h-3",
						[nameof( ProgressSlots.Label )] = "text-medium",
						[nameof( ProgressSlots.Value )] = "text-medium",
					},
				},

				[nameof( LumexProgress.Radius )] = new VariantValueCollection
				{
					[nameof( Radius.None )] = new SlotCollection
					{
						[nameof( ProgressSlots.Track )] = "rounded-none",
					},
					[nameof( Radius.Small )] = new SlotCollection
					{
						[nameof( ProgressSlots.Track )] = "rounded-sm",
					},
					[nameof( Radius.Medium )] = new SlotCollection
					{
						[nameof( ProgressSlots.Track )] = "rounded-md",
					},
					[nameof( Radius.Large )] = new SlotCollection
					{
						[nameof( ProgressSlots.Track )] = "rounded-lg",
					},
					[nameof( Radius.Full )] = new SlotCollection
					{
						[nameof( ProgressSlots.Track )] = "rounded-full",
					},
				},

				[nameof( LumexProgress.IsIndeterminate )] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof( ProgressSlots.Indicator )] = "animate-progress-loading",
					},
				},

				[nameof( LumexProgress.DisableAnimation )] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof( ProgressSlots.Indicator )] = "!transition-none",
					},
				},

				[nameof( LumexProgress.IsDisabled )] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof( ProgressSlots.Base )] = "opacity-50 cursor-not-allowed",
					},
				},
			},

			CompoundVariants =
			[
				// Color variants for indicator
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexProgress.Color )] = nameof( ThemeColor.Default )
					},
					Classes = new SlotCollection()
					{
						[nameof( ProgressSlots.Indicator )] = ColorVariants.Solid[ThemeColor.Default]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexProgress.Color )] = nameof( ThemeColor.Primary )
					},
					Classes = new SlotCollection()
					{
						[nameof( ProgressSlots.Indicator )] = ColorVariants.Solid[ThemeColor.Primary]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexProgress.Color )] = nameof( ThemeColor.Secondary )
					},
					Classes = new SlotCollection()
					{
						[nameof( ProgressSlots.Indicator )] = ColorVariants.Solid[ThemeColor.Secondary]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexProgress.Color )] = nameof( ThemeColor.Success )
					},
					Classes = new SlotCollection()
					{
						[nameof( ProgressSlots.Indicator )] = ColorVariants.Solid[ThemeColor.Success]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexProgress.Color )] = nameof( ThemeColor.Warning )
					},
					Classes = new SlotCollection()
					{
						[nameof( ProgressSlots.Indicator )] = ColorVariants.Solid[ThemeColor.Warning]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexProgress.Color )] = nameof( ThemeColor.Danger )
					},
					Classes = new SlotCollection()
					{
						[nameof( ProgressSlots.Indicator )] = ColorVariants.Solid[ThemeColor.Danger]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexProgress.Color )] = nameof( ThemeColor.Info )
					},
					Classes = new SlotCollection()
					{
						[nameof( ProgressSlots.Indicator )] = ColorVariants.Solid[ThemeColor.Info]
					}
				}
			]
		} );
	}
}

