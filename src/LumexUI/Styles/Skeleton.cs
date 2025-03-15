// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Utilities;

using TailwindMerge;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal static class Skeleton
{
	private static ComponentVariant? _variant;

	public static ComponentVariant Style( TwMerge twMerge )
	{
		var twVariants = new TwVariants( twMerge );

		return _variant ??= twVariants.Create( new VariantConfig()
		{
			Slots = new SlotCollection
			{
				[nameof( SkeletonSlots.Base )] = new ElementClass()
					.Add( "group" )
					.Add( "relative" )
					.Add( "bg-surface3" )
					.Add( "overflow-hidden" )
					.Add( "pointer-events-none" )
					// before
					.Add( "before:absolute" )
					.Add( "before:inset-0" )
					.Add( "before:opacity-100" )
					.Add( "before:-translate-x-full" )
					.Add( "before:bg-gradient-to-r" )
					.Add( "before:from-transparent" )
					.Add( "before:via-default-300" )
					.Add( "before:to-transparent" )
					.Add( "before:animate-shimmer" )
					  //after
					.Add( "after:-z-10" )
					.Add( "after:absolute" )
					.Add( "after:inset-0" )
					.Add( "after:opacity-100" )
					.Add( "after:bg-surface3" )
					// state
					.Add( "data-[loading=false]:pointer-events-auto" )
					.Add( "data-[loading=false]:overflow-visible" )
					.Add( "data-[loading=false]:bg-transparent" )
					.Add( "data-[loading=false]:before:animate-none" )
					.Add( "data-[loading=false]:before:opacity-0" )
					.Add( "data-[loading=false]:after:opacity-0" )
					// transition
					.Add( "duration-300" )
					.Add( "transition-background" ),

				[nameof( SkeletonSlots.Content )] = new ElementClass()
					.Add( "opacity-0" )
					.Add( "group-data-[loading=false]:opacity-100" )
					// transition
					.Add( "duration-300" )
					.Add( "transition-opacity" )
					.Add( "motion-reduce:transition-none" )
			}
		} );
	}
}