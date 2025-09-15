// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Utilities;

using TailwindMerge;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal static class User
{
	private static ComponentVariant? _variant;

	public static ComponentVariant Style( TwMerge twMerge )
	{
		var twVariants = new TwVariants( twMerge );

		return _variant ?? twVariants.Create( new VariantConfig()
		{
			Slots = new SlotCollection
			{
				[nameof(UserSlots.Base)] = new ElementClass()
					.Add( "inline-flex" )
					.Add( "items-center" )
					.Add( "justify-center" )
					.Add( "gap-2" )
					.Add( "rounded-small" )
					.Add( "outline-solid" )
					.Add( "outline-transparent" ),

				[nameof(UserSlots.Wrapper)] = "inline-flex flex-col items-start",

				[nameof(UserSlots.Name)] = "text-small text-inherit",

				[nameof(UserSlots.Description)] = "text-tiny text-foreground-400",
			},

			Variants = new VariantCollection
			{
				[nameof(LumexUser.IsFocusable)] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof(UserSlots.Base)] = Utils.FocusVisible,
					}
				}
			}
		} );
	}
}
