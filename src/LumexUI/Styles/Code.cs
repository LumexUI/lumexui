// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using TailwindMerge;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal static class Code
{
	private static ComponentVariant? _variant;

	public static ComponentVariant Style( TwMerge twMerge )
	{
		var twVariants = new TwVariants( twMerge );

		return _variant ??= twVariants.Create( new VariantConfig()
		{
			Base = new ElementClass()
				.Add( "px-2" )
				.Add( "py-1" )
				.Add( "h-fit" )
				.Add( "font-mono" )
				.Add( "font-normal" )
				.Add( "inline-block" )
				.Add( "whitespace-nowrap" ),

			Variants = new VariantCollection
			{
				[nameof( LumexCode.Color )] = new VariantValueCollection
				{
					[nameof( ThemeColor.Default )] = new SlotCollection
					{
						[nameof( SlotBase.Base )] = ColorVariants.Flat[ThemeColor.Default]
					},
					[nameof( ThemeColor.Primary )] = new SlotCollection
					{
						[nameof( SlotBase.Base )] = ColorVariants.Flat[ThemeColor.Primary]
					},
					[nameof( ThemeColor.Secondary )] = new SlotCollection
					{
						[nameof( SlotBase.Base )] = ColorVariants.Flat[ThemeColor.Secondary]
					},
					[nameof( ThemeColor.Success )] = new SlotCollection
					{
						[nameof( SlotBase.Base )] = ColorVariants.Flat[ThemeColor.Success]
					},
					[nameof( ThemeColor.Warning )] = new SlotCollection
					{
						[nameof( SlotBase.Base )] = ColorVariants.Flat[ThemeColor.Warning]
					},
					[nameof( ThemeColor.Danger )] = new SlotCollection
					{
						[nameof( SlotBase.Base )] = ColorVariants.Flat[ThemeColor.Danger]
					},
					[nameof( ThemeColor.Info )] = new SlotCollection
					{
						[nameof( SlotBase.Base )] = ColorVariants.Flat[ThemeColor.Info]
					},
				},

				[nameof( LumexCode.Size )] = new VariantValueCollection
				{
					[nameof( Size.Small )] = new SlotCollection
					{
						[nameof( SlotBase.Base )] = "text-tiny",
					},
					[nameof( Size.Medium )] = new SlotCollection
					{
						[nameof( SlotBase.Base )] = "text-small",
					},
					[nameof( Size.Large )] = new SlotCollection
					{
						[nameof( SlotBase.Base )] = "text-medium",
					}
				},

				[nameof( LumexCode.Radius )] = new VariantValueCollection
				{
					[nameof( Radius.None )] = new SlotCollection
					{
						[nameof( SlotBase.Base )] = "rounded-none",
					},
					[nameof( Radius.Small )] = new SlotCollection
					{
						[nameof( SlotBase.Base )] = "rounded-small",
					},
					[nameof( Radius.Medium )] = new SlotCollection
					{
						[nameof( SlotBase.Base )] = "rounded-medium",
					},
					[nameof( Radius.Large )] = new SlotCollection
					{
						[nameof( SlotBase.Base )] = "rounded-large",
					},
					[nameof( Radius.Full )] = new SlotCollection
					{
						[nameof( SlotBase.Base )] = "rounded-full",
					}
				}
			},
		} );
	}
}