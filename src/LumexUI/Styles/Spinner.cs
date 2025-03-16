// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using TailwindMerge;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal static class Spinner
{
	private static ComponentVariant? _variant;

	public static ComponentVariant Style( TwMerge twMerge )
	{
		var twVariants = new TwVariants( twMerge );

		return _variant ??= twVariants.Create( new VariantConfig()
		{
			Slots = new SlotCollection
			{
				[nameof( SpinnerSlots.Base )] = new ElementClass()
					.Add( "relative" )
					.Add( "inline-flex" )
					.Add( "flex-col" )
					.Add( "items-center" )
					.Add( "justify-center" )
					.Add( "gap-2" ),

				[nameof( SpinnerSlots.Wrapper )] = new ElementClass()
					.Add( "relative" )
					.Add( "flex" ),

				[nameof( SpinnerSlots.Label )] = new ElementClass()
					.Add( "w-max" )
					.Add( "text-foreground" ),

				[nameof( SpinnerSlots.Circle1 )] = new ElementClass()
					.Add( "absolute" )
					.Add( "w-full" )
					.Add( "h-full" )
					.Add( "rounded-full" ),

				[nameof( SpinnerSlots.Circle2 )] = new ElementClass()
					.Add( "absolute" )
					.Add( "w-full" )
					.Add( "h-full" )
					.Add( "rounded-full" ),

				[nameof( SpinnerSlots.Dots )] = new ElementClass()
					.Add( "relative" )
					.Add( "mx-auto" )
					.Add( "rounded-full" ),

				[nameof( SpinnerSlots.Bars )] = new ElementClass()
					.Add( "absolute" )
					.Add( "w-[25%]" )
					.Add( "h-[8%]" )
					.Add( "left-[37.5%]" )
					.Add( "top-[46%]" )
					.Add( "rounded-full" )
					.Add( "animate-fade-out" )
					.Add( "[animation-delay:calc(-1.2s+(0.1s*var(--index)))]" )
					.Add( "transform-[rotate(calc(30deg*var(--index)))_translate(140%)]" ),
			},

			Variants = new VariantCollection
			{
				[nameof( LumexSpinner.Size )] = new VariantValueCollection
				{
					[nameof( Size.Small )] = new SlotCollection
					{
						[nameof( SpinnerSlots.Label )] = "text-small",
						[nameof( SpinnerSlots.Wrapper )] = "size-5",
						[nameof( SpinnerSlots.Circle1 )] = "border-2",
						[nameof( SpinnerSlots.Circle2 )] = "border-2",
						[nameof( SpinnerSlots.Dots )] = "size-1"
					},
					[nameof( Size.Medium )] = new SlotCollection
					{
						[nameof( SpinnerSlots.Label )] = "text-medium",
						[nameof( SpinnerSlots.Wrapper )] = "size-8",
						[nameof( SpinnerSlots.Circle1 )] = "border-3",
						[nameof( SpinnerSlots.Circle2 )] = "border-3",
						[nameof( SpinnerSlots.Dots )] = "size-1.5"
					},
					[nameof( Size.Large )] = new SlotCollection
					{
						[nameof( SpinnerSlots.Label )] = "text-large",
						[nameof( SpinnerSlots.Wrapper )] = "size-10",
						[nameof( SpinnerSlots.Circle1 )] = "border-3",
						[nameof( SpinnerSlots.Circle2 )] = "border-3",
						[nameof( SpinnerSlots.Dots )] = "size-2"
					},
				},

				[nameof( LumexSpinner.Color )] = new VariantValueCollection
				{
					[nameof( ThemeColor.Default )] = new SlotCollection
					{
						[nameof( SpinnerSlots.Circle1 )] = "border-b-default",
						[nameof( SpinnerSlots.Circle2 )] = "border-b-default",
						[nameof( SpinnerSlots.Dots )] = "bg-default",
						[nameof( SpinnerSlots.Bars )] = "bg-default"
					},

					[nameof( ThemeColor.Primary )] = new SlotCollection
					{
						[nameof( SpinnerSlots.Circle1 )] = "border-b-primary",
						[nameof( SpinnerSlots.Circle2 )] = "border-b-primary",
						[nameof( SpinnerSlots.Dots )] = "bg-primary",
						[nameof( SpinnerSlots.Bars )] = "bg-primary"
					},

					[nameof( ThemeColor.Secondary )] = new SlotCollection
					{
						[nameof( SpinnerSlots.Circle1 )] = "border-b-secondary",
						[nameof( SpinnerSlots.Circle2 )] = "border-b-secondary",
						[nameof( SpinnerSlots.Dots )] = "bg-secondary",
						[nameof( SpinnerSlots.Bars )] = "bg-secondary"
					},

					[nameof( ThemeColor.Success )] = new SlotCollection
					{
						[nameof( SpinnerSlots.Circle1 )] = "border-b-success",
						[nameof( SpinnerSlots.Circle2 )] = "border-b-success",
						[nameof( SpinnerSlots.Dots )] = "bg-success",
						[nameof( SpinnerSlots.Bars )] = "bg-success"
					},

					[nameof( ThemeColor.Warning )] = new SlotCollection
					{
						[nameof( SpinnerSlots.Circle1 )] = "border-b-warning",
						[nameof( SpinnerSlots.Circle2 )] = "border-b-warning",
						[nameof( SpinnerSlots.Dots )] = "bg-warning",
						[nameof( SpinnerSlots.Bars )] = "bg-warning"
					},

					[nameof( ThemeColor.Danger )] = new SlotCollection
					{
						[nameof( SpinnerSlots.Circle1 )] = "border-b-danger",
						[nameof( SpinnerSlots.Circle2 )] = "border-b-danger",
						[nameof( SpinnerSlots.Dots )] = "bg-danger",
						[nameof( SpinnerSlots.Bars )] = "bg-danger"
					},

					[nameof( ThemeColor.Info )] = new SlotCollection
					{
						[nameof( SpinnerSlots.Circle1 )] = "border-b-info",
						[nameof( SpinnerSlots.Circle2 )] = "border-b-info",
						[nameof( SpinnerSlots.Dots )] = "bg-info",
						[nameof( SpinnerSlots.Bars )] = "bg-info"
					}
				},

				[nameof( LumexSpinner.LabelColor )] = new VariantValueCollection
				{
					[nameof( ThemeColor.None )] = new SlotCollection
					{
						[nameof( SpinnerSlots.Label )] = "text-foreground"
					},

					[nameof( ThemeColor.Primary )] = new SlotCollection
					{
						[nameof( SpinnerSlots.Label )] = "text-primary"
					},

					[nameof( ThemeColor.Secondary )] = new SlotCollection
					{
						[nameof( SpinnerSlots.Label )] = "text-secondary"
					},

					[nameof( ThemeColor.Success )] = new SlotCollection
					{
						[nameof( SpinnerSlots.Label )] = "text-success"
					},

					[nameof( ThemeColor.Warning )] = new SlotCollection
					{
						[nameof( SpinnerSlots.Label )] = "text-warning"
					},

					[nameof( ThemeColor.Danger )] = new SlotCollection
					{
						[nameof( SpinnerSlots.Label )] = "text-danger"
					},

					[nameof( ThemeColor.Info )] = new SlotCollection
					{
						[nameof( SpinnerSlots.Label )] = "text-info"
					}
				},

				[nameof( LumexSpinner.Variant )] = new VariantValueCollection
				{
					[nameof( SpinnerVariant.Ring )] = new SlotCollection
					{
						[nameof( SpinnerSlots.Wrapper )] = "size-5 text-foreground animate-spin",
						[nameof( SpinnerSlots.Circle1 )] = "opacity-25",
						[nameof( SpinnerSlots.Circle2 )] = "opacity-75"
					},

					[nameof( SpinnerVariant.Arc )] = new SlotCollection
					{
						[nameof( SpinnerSlots.Circle1 )] = new ElementClass()
							.Add( "border-solid" )
							.Add( "border-t-transparent" )
							.Add( "border-l-transparent" )
							.Add( "border-r-transparent" )
							.Add( "animate-spin" )
							.Add( "[animation-duration:0.8s]" )
							.Add( "[animation-timing-function:ease]" ),

						[nameof( SpinnerSlots.Circle2 )] = new ElementClass()
							.Add( "opacity-75" )
							.Add( "border-dotted" )
							.Add( "border-t-transparent" )
							.Add( "border-l-transparent" )
							.Add( "border-r-transparent" )
							.Add( "animate-spin" )
							.Add( "[animation-duration:0.8s]" )
					},

					[nameof( SpinnerVariant.ArcGradient )] = new SlotCollection
					{
						[nameof( SpinnerSlots.Circle1 )] = new ElementClass()
							.Add( "border-0" )
							.Add( "bg-gradient-to-b" )
							.Add( "from-transparent" )
							.Add( "via-transparent" )
							.Add( "to-primary" )
							.Add( "animate-spin" )
							.Add( "[-webkit-mask:radial-gradient(closest-side,rgba(0,0,0,0.0)calc(100%-3px),rgba(0,0,0,1)calc(100%-3px))]" ),

						[nameof( SpinnerSlots.Circle2 )] = "hidden"
					},

					[nameof( SpinnerVariant.DotsWave )] = new SlotCollection
					{
						[nameof( SpinnerSlots.Wrapper )] = "translate-y-3/4",
						[nameof( SpinnerSlots.Dots )] = "animate-sway [animation-delay:calc(250ms*var(--index))]"
					},

					[nameof( SpinnerVariant.DotsFade )] = new SlotCollection
					{
						[nameof( SpinnerSlots.Wrapper )] = "translate-y-2/4",
						[nameof( SpinnerSlots.Dots )] = "animate-blink [animation-delay:calc(200ms*var(--index))]"
					},

					[nameof( SpinnerVariant.Classic )] = new SlotCollection { }
				},
			},

			CompoundVariants = [
				// arc gradient && color
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexSpinner.Variant )] = nameof( SpinnerVariant.ArcGradient ),
						[nameof( LumexSpinner.Color )] = nameof( ThemeColor.Default )
					},
					Classes = new SlotCollection()
					{
						[nameof(SpinnerSlots.Circle1)] = "to-default"
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexSpinner.Variant )] = nameof( SpinnerVariant.ArcGradient ),
						[nameof( LumexSpinner.Color )] = nameof( ThemeColor.Primary )
					},
					Classes = new SlotCollection()
					{
						[nameof(SpinnerSlots.Circle1)] = "to-primary"
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexSpinner.Variant )] = nameof( SpinnerVariant.ArcGradient ),
						[nameof( LumexSpinner.Color )] = nameof( ThemeColor.Secondary )
					},
					Classes = new SlotCollection()
					{
						[nameof(SpinnerSlots.Circle1)] = "to-secondary"
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexSpinner.Variant )] = nameof( SpinnerVariant.ArcGradient ),
						[nameof( LumexSpinner.Color )] = nameof( ThemeColor.Success )
					},
					Classes = new SlotCollection()
					{
						[nameof(SpinnerSlots.Circle1)] = "to-success"
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexSpinner.Variant )] = nameof( SpinnerVariant.ArcGradient ),
						[nameof( LumexSpinner.Color )] = nameof( ThemeColor.Warning )
					},
					Classes = new SlotCollection()
					{
						[nameof(SpinnerSlots.Circle1)] = "to-warning"
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexSpinner.Variant )] = nameof( SpinnerVariant.ArcGradient ),
						[nameof( LumexSpinner.Color )] = nameof( ThemeColor.Danger )
					},
					Classes = new SlotCollection()
					{
						[nameof(SpinnerSlots.Circle1)] = "to-danger"
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexSpinner.Variant )] = nameof( SpinnerVariant.ArcGradient ),
						[nameof( LumexSpinner.Color )] = nameof( ThemeColor.Info )
					},
					Classes = new SlotCollection()
					{
						[nameof(SpinnerSlots.Circle1)] = "to-info"
					}
				},

				// dots wave && size
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexSpinner.Variant )] = nameof( SpinnerVariant.DotsWave ),
						[nameof( LumexSpinner.Size )] = nameof( Size.Small )
					},
					Classes = new SlotCollection()
					{
						[nameof(SpinnerSlots.Wrapper)] = "size-5"
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexSpinner.Variant )] = nameof( SpinnerVariant.DotsWave ),
						[nameof( LumexSpinner.Size )] = nameof( Size.Medium )
					},
					Classes = new SlotCollection()
					{
						[nameof(SpinnerSlots.Wrapper)] = "size-8"
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexSpinner.Variant )] = nameof( SpinnerVariant.DotsWave ),
						[nameof( LumexSpinner.Size )] = nameof( Size.Large )
					},
					Classes = new SlotCollection()
					{
						[nameof(SpinnerSlots.Wrapper)] = "size-12"
					}
				},

				// dots fade && size
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexSpinner.Variant )] = nameof( SpinnerVariant.DotsFade ),
						[nameof( LumexSpinner.Size )] = nameof( Size.Small )
					},
					Classes = new SlotCollection()
					{
						[nameof(SpinnerSlots.Wrapper)] = "size-5"
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexSpinner.Variant )] = nameof( SpinnerVariant.DotsFade ),
						[nameof( LumexSpinner.Size )] = nameof( Size.Medium )
					},
					Classes = new SlotCollection()
					{
						[nameof(SpinnerSlots.Wrapper)] = "size-8"
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexSpinner.Variant )] = nameof( SpinnerVariant.DotsFade ),
						[nameof( LumexSpinner.Size )] = nameof( Size.Large )
					},
					Classes = new SlotCollection()
					{
						[nameof(SpinnerSlots.Wrapper)] = "size-12"
					}
				},

				// ring compound variants
				// size
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexSpinner.Variant )] = nameof( SpinnerVariant.Ring ),
						[nameof( LumexSpinner.Size )] = nameof( Size.Small )
					},
					Classes = new SlotCollection()
					{
						[nameof(SpinnerSlots.Wrapper)] = "size-5"
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexSpinner.Variant )] = nameof( SpinnerVariant.Ring ),
						[nameof( LumexSpinner.Size )] = nameof( Size.Medium )
					},
					Classes = new SlotCollection()
					{
						[nameof(SpinnerSlots.Wrapper)] = "size-8"
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexSpinner.Variant )] = nameof( SpinnerVariant.Ring ),
						[nameof( LumexSpinner.Size )] = nameof( Size.Large )
					},
					Classes = new SlotCollection()
					{
						[nameof(SpinnerSlots.Wrapper)] = "size-12"
					}
				},

				// color
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexSpinner.Variant )] = nameof( SpinnerVariant.Ring ),
						[nameof( LumexSpinner.Color )] = nameof( ThemeColor.Default )
					},
					Classes = new SlotCollection()
					{
						[nameof(SpinnerSlots.Wrapper)] = "text-default"
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexSpinner.Variant )] = nameof( SpinnerVariant.Ring ),
						[nameof( LumexSpinner.Color )] = nameof( ThemeColor.Primary )
					},
					Classes = new SlotCollection()
					{
						[nameof(SpinnerSlots.Wrapper)] = "text-primary"
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexSpinner.Variant )] = nameof( SpinnerVariant.Ring ),
						[nameof( LumexSpinner.Color )] = nameof( ThemeColor.Secondary )
					},
					Classes = new SlotCollection()
					{
						[nameof(SpinnerSlots.Wrapper)] = "text-secondary"
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexSpinner.Variant )] = nameof( SpinnerVariant.Ring ),
						[nameof( LumexSpinner.Color )] = nameof( ThemeColor.Success )
					},
					Classes = new SlotCollection()
					{
						[nameof(SpinnerSlots.Wrapper)] = "text-success"
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexSpinner.Variant )] = nameof( SpinnerVariant.Ring ),
						[nameof( LumexSpinner.Color )] = nameof( ThemeColor.Warning )
					},
					Classes = new SlotCollection()
					{
						[nameof(SpinnerSlots.Wrapper)] = "text-warning"
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexSpinner.Variant )] = nameof( SpinnerVariant.Ring ),
						[nameof( LumexSpinner.Color )] = nameof( ThemeColor.Danger )
					},
					Classes = new SlotCollection()
					{
						[nameof(SpinnerSlots.Wrapper)] = "text-danger"
					}
				},
				new CompoundVariant()
				{
					Conditions = new()
					{
						[nameof( LumexSpinner.Variant )] = nameof( SpinnerVariant.Ring ),
						[nameof( LumexSpinner.Color )] = nameof( ThemeColor.Info )
					},
					Classes = new SlotCollection()
					{
						[nameof(SpinnerSlots.Wrapper)] = "text-info"
					}
				},
			]
		} );
	}
}