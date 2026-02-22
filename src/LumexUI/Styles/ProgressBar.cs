// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using TailwindMerge;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal static class ProgressBar
{
	private static ComponentVariant? _variant;

	public static ComponentVariant Style( TwMerge twMerge )
	{
		var twVariants = new TwVariants( twMerge );

		return _variant ??= twVariants.Create( new VariantConfig()
		{
			Slots = new SlotCollection
			{
				[nameof( ProgressBarSlots.Track )] = new ElementClass()
					.Add( "relative" )
					.Add( "w-full" )
					.Add( "overflow-hidden" )
					.Add( "bg-default-200" )
					.Add( "dark:bg-default-100" ),

				[nameof( ProgressBarSlots.Fill )] = new ElementClass()
					.Add( "h-full" )
					.Add( "transition-all" )
					.Add( "duration-300" )
					.Add( "ease-out" )
					.Add( "relative" )
					.Add( "overflow-hidden" ),

				[nameof( ProgressBarSlots.Label )] = new ElementClass()
					.Add( "text-small" )
					.Add( "font-medium" )
					.Add( "text-foreground" ),
			},

			Variants = new VariantCollection
			{
				[nameof( LumexProgressBar.Size )] = new VariantValueCollection
				{
					[nameof( Size.Small )] = new SlotCollection
					{
						[nameof( ProgressBarSlots.Track )] = "h-1",
						[nameof( ProgressBarSlots.Label )] = "text-tiny",
					},
					[nameof( Size.Medium )] = new SlotCollection
					{
						[nameof( ProgressBarSlots.Track )] = "h-2",
						[nameof( ProgressBarSlots.Label )] = "text-small",
					},
					[nameof( Size.Large )] = new SlotCollection
					{
						[nameof( ProgressBarSlots.Track )] = "h-3",
						[nameof( ProgressBarSlots.Label )] = "text-medium",
					},
				},

				[nameof( LumexProgressBar.Radius )] = new VariantValueCollection
				{
					[nameof( Radius.None )] = new SlotCollection
					{
						[nameof( ProgressBarSlots.Track )] = "rounded-none",
						[nameof( ProgressBarSlots.Fill )] = "rounded-none",
					},
					[nameof( Radius.Small )] = new SlotCollection
					{
						[nameof( ProgressBarSlots.Track )] = "rounded-small",
						[nameof( ProgressBarSlots.Fill )] = "rounded-small",
					},
					[nameof( Radius.Medium )] = new SlotCollection
					{
						[nameof( ProgressBarSlots.Track )] = "rounded-medium",
						[nameof( ProgressBarSlots.Fill )] = "rounded-medium",
					},
					[nameof( Radius.Large )] = new SlotCollection
					{
						[nameof( ProgressBarSlots.Track )] = "rounded-large",
						[nameof( ProgressBarSlots.Fill )] = "rounded-large",
					},
				},

				[nameof( LumexProgressBar.IsLoadingBar )] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof( ProgressBarSlots.Fill )] = "animate-progress-loading",
					},
				},
			},

			CompoundVariants =
			[
				// Color variants for fill
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexProgressBar.Color )] = nameof( ThemeColor.Default )
					},
					Classes = new SlotCollection()
					{
						[nameof( ProgressBarSlots.Fill )] = ColorVariants.Solid[ThemeColor.Default]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexProgressBar.Color )] = nameof( ThemeColor.Primary )
					},
					Classes = new SlotCollection()
					{
						[nameof( ProgressBarSlots.Fill )] = ColorVariants.Solid[ThemeColor.Primary]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexProgressBar.Color )] = nameof( ThemeColor.Secondary )
					},
					Classes = new SlotCollection()
					{
						[nameof( ProgressBarSlots.Fill )] = ColorVariants.Solid[ThemeColor.Secondary]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexProgressBar.Color )] = nameof( ThemeColor.Success )
					},
					Classes = new SlotCollection()
					{
						[nameof( ProgressBarSlots.Fill )] = ColorVariants.Solid[ThemeColor.Success]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexProgressBar.Color )] = nameof( ThemeColor.Warning )
					},
					Classes = new SlotCollection()
					{
						[nameof( ProgressBarSlots.Fill )] = ColorVariants.Solid[ThemeColor.Warning]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexProgressBar.Color )] = nameof( ThemeColor.Danger )
					},
					Classes = new SlotCollection()
					{
						[nameof( ProgressBarSlots.Fill )] = ColorVariants.Solid[ThemeColor.Danger]
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexProgressBar.Color )] = nameof( ThemeColor.Info )
					},
					Classes = new SlotCollection()
					{
						[nameof( ProgressBarSlots.Fill )] = ColorVariants.Solid[ThemeColor.Info]
					}
				},

				// IsLabelInline variants
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexProgressBar.IsLabelInline )] = bool.TrueString
					},
					Classes = new SlotCollection()
					{
						[nameof( ProgressBarSlots.Track )] = "flex items-center",
						[nameof( ProgressBarSlots.Fill )] = "!absolute !top-0 !bottom-0 !left-0 !h-full !z-0",
						[nameof( ProgressBarSlots.Label )] = "absolute pointer-events-none whitespace-nowrap z-10 text-white drop-shadow-sm flex items-center top-1/2 -translate-y-1/2",
					}
				},

				// IsLabelInline + LabelPosition Start
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexProgressBar.IsLabelInline )] = bool.TrueString,
						[nameof( LumexProgressBar.LabelPosition )] = nameof( Align.Start )
					},
					Classes = new SlotCollection()
					{
						[nameof( ProgressBarSlots.Label )] = "left-2",
					}
				},

				// IsLabelInline + LabelPosition Center
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexProgressBar.IsLabelInline )] = bool.TrueString,
						[nameof( LumexProgressBar.LabelPosition )] = nameof( Align.Center )
					},
					Classes = new SlotCollection()
					{
						[nameof( ProgressBarSlots.Label )] = "left-1/2 -translate-x-1/2",
					}
				},

				// IsLabelInline + LabelPosition End
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexProgressBar.IsLabelInline )] = bool.TrueString,
						[nameof( LumexProgressBar.LabelPosition )] = nameof( Align.End )
					},
					Classes = new SlotCollection()
					{
						[nameof( ProgressBarSlots.Label )] = "right-2",
					}
				},

				// IsLabelInline + Size Small (increased height + text size)
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexProgressBar.IsLabelInline )] = bool.TrueString,
						[nameof( LumexProgressBar.Size )] = nameof( Size.Small )
					},
					Classes = new SlotCollection()
					{
						[nameof( ProgressBarSlots.Track )] = "!h-4",
						[nameof( ProgressBarSlots.Label )] = "text-tiny",
					}
				},

				// IsLabelInline + Size Medium (increased height + text size)
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexProgressBar.IsLabelInline )] = bool.TrueString,
						[nameof( LumexProgressBar.Size )] = nameof( Size.Medium )
					},
					Classes = new SlotCollection()
					{
						[nameof( ProgressBarSlots.Track )] = "!h-5",
						[nameof( ProgressBarSlots.Label )] = "text-small",
					}
				},

				// IsLabelInline + Size Large (increased height + text size)
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexProgressBar.IsLabelInline )] = bool.TrueString,
						[nameof( LumexProgressBar.Size )] = nameof( Size.Large )
					},
					Classes = new SlotCollection()
					{
						[nameof( ProgressBarSlots.Track )] = "!h-6",
						[nameof( ProgressBarSlots.Label )] = "text-medium",
					}
				},
			]
		} );
	}
}
