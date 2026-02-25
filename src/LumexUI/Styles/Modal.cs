// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using TailwindMerge;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal static class Modal
{
	private static ComponentVariant? _variant;

	public static ComponentVariant Style( TwMerge twMerge )
	{
		var twVariants = new TwVariants( twMerge );

		return _variant ??= twVariants.Create( new VariantConfig()
		{
			Slots = new SlotCollection
			{
				[nameof( ModalSlots.Base )] = new ElementClass()
					.Add( "max-w-[calc(100%-0.5rem)]" )
					.Add( "w-full" )
					.Add( "inset-auto" )
					.Add( "flex-col" )
					.Add( "overflow-x-auto" )
					.Add( "bg-surface1" )
					.Add( "text-surface1-foreground" )
					.Add( "outline-none" )
					.Add( "duration-150" )
					.Add( "transition-discrete" )
					// open
					.Add( "open:flex" )
					.Add( "open:animate-in" )
					.Add( "open:fade-in" )
					.Add( "open:zoom-in-105" )
					// close
					.Add( "not-open:animate-out" )
					.Add( "not-open:fade-out" )
					.Add( "not-open:zoom-out-95" )
					// backdrop
					.Add( "backdrop:duration-150" )
					.Add( "backdrop:transition-opacity" )
					.Add( "starting:backdrop:opacity-0" )
					.Add( "not-open:backdrop:opacity-0" ),

		[nameof( ModalSlots.Trigger )] = new ElementClass(),

				[nameof( ModalSlots.Header )] = new ElementClass()
					.Add( "flex" )
					.Add( "py-4" )
					.Add( "px-6" )
					.Add( "flex-initial" )
					.Add( "text-large" )
					.Add( "font-semibold" ),

				[nameof( ModalSlots.Body )] = new ElementClass()
					.Add( "flex" )
					.Add( "flex-1" )
					.Add( "flex-col" )
					.Add( "gap-3" )
					.Add( "px-6" )
					.Add( "py-2" ),

				[nameof( ModalSlots.Footer )] = new ElementClass()
					.Add( "flex" )
					.Add( "flex-row" )
					.Add( "gap-2" )
					.Add( "px-6" )
					.Add( "py-4" )
					.Add( "justify-end" ),

				[nameof( ModalSlots.CloseButton )] = new ElementClass()
					.Add( "absolute" )
					.Add( "appearance-none" )
					.Add( "select-none" )
					.Add( "top-2" )
					.Add( "end-2" )
					.Add( "p-2" )
					.Add( "text-foreground-500" )
					.Add( "rounded-full" )
					.Add( "cursor-pointer" )
					.Add( "hover:bg-default-100" )
					.Add( "active:bg-default-200" )
					.Add( Utils.FocusVisible ),
			},

			Variants = new VariantCollection
			{
				// Size
				[nameof( LumexModal.Size )] = new VariantValueCollection
				{
					[nameof( ModalSize.XSmall )] = new SlotCollection
					{
						[nameof( ModalSlots.Base )] = "sm:max-w-xs"
					},
					[nameof( ModalSize.Small )] = new SlotCollection
					{
						[nameof( ModalSlots.Base )] = "sm:max-w-sm"
					},
					[nameof( ModalSize.Medium )] = new SlotCollection
					{
						[nameof( ModalSlots.Base )] = "sm:max-w-md"
					},
					[nameof( ModalSize.Large )] = new SlotCollection
					{
						[nameof( ModalSlots.Base )] = "sm:max-w-lg"
					},
					[nameof( ModalSize.Full )] = new SlotCollection
					{
						[nameof( ModalSlots.Base )] = "max-w-full h-[100dvh] min-h-[100dvh] !rounded-none"
					},
				},

				// Radius
				[nameof( LumexModal.Radius )] = new VariantValueCollection
				{
					[nameof( Radius.None )] = new SlotCollection
					{
						[nameof( ModalSlots.Base )] = "rounded-none"
					},
					[nameof( Radius.Small )] = new SlotCollection
					{
						[nameof( ModalSlots.Base )] = "rounded-small"
					},
					[nameof( Radius.Medium )] = new SlotCollection
					{
						[nameof( ModalSlots.Base )] = "rounded-medium"
					},
					[nameof( Radius.Large )] = new SlotCollection
					{
						[nameof( ModalSlots.Base )] = "rounded-large"
					},
				},

				// Shadow
				[nameof( LumexModal.Shadow )] = new VariantValueCollection
				{
					[nameof( Shadow.None )] = new SlotCollection
					{
						[nameof( ModalSlots.Base )] = "shadow-none"
					},
					[nameof( Shadow.Small )] = new SlotCollection
					{
						[nameof( ModalSlots.Base )] = "shadow-small"
					},
					[nameof( Shadow.Medium )] = new SlotCollection
					{
						[nameof( ModalSlots.Base )] = "shadow-medium"
					},
					[nameof( Shadow.Large )] = new SlotCollection
					{
						[nameof( ModalSlots.Base )] = "shadow-large"
					},
				},

				// Backdrop
				[nameof( LumexModal.Backdrop )] = new VariantValueCollection
				{
					[nameof( Backdrop.Transparent )] = new SlotCollection
					{
						[nameof( ModalSlots.Base )] = "backdrop:opacity-0"
					},
					[nameof( Backdrop.Opaque )] = new SlotCollection
					{
						[nameof( ModalSlots.Base )] = "backdrop:bg-black/50 backdrop:backdrop-opacity-disabled"
					},
					[nameof( Backdrop.Blur )] = new SlotCollection
					{
						[nameof( ModalSlots.Base )] = "backdrop:backdrop-blur-md backdrop:backdrop-saturate-150 backdrop:bg-overlay/30"
					},
				},

				// Placement
				[nameof( LumexModal.Placement )] = new VariantValueCollection
				{
					[nameof( ModalPlacement.Auto )] = new SlotCollection
					{
						[nameof( ModalSlots.Base )] = "bottom-1 left-1/2 -translate-x-1/2 sm:top-1/2 sm:-translate-1/2"
					},
					[nameof( ModalPlacement.Center )] = new SlotCollection
					{
						[nameof( ModalSlots.Base )] = "top-1/2 left-1/2 -translate-1/2"
					},
					[nameof( ModalPlacement.Top )] = new SlotCollection
					{
						[nameof( ModalSlots.Base )] = "top-1 left-1/2 -translate-x-1/2"
					},
					[nameof( ModalPlacement.Bottom )] = new SlotCollection
					{
						[nameof( ModalSlots.Base )] = "bottom-1 left-1/2 -translate-x-1/2"
					},
				},

				// ScrollBehavior
				[nameof( LumexModal.ScrollBehavior )] = new VariantValueCollection
				{
					[nameof( ScrollBehavior.Normal )] = new SlotCollection
					{
						[nameof( ModalSlots.Base )] = "overflow-y-hidden"
					},
					[nameof( ScrollBehavior.Inside )] = new SlotCollection
					{
						[nameof( ModalSlots.Base )] = "max-h-[calc(100%_-_8rem)]",
						[nameof( ModalSlots.Body )] = "overflow-y-auto"
					},
					[nameof( ScrollBehavior.Outside )] = new SlotCollection
					{
						[nameof( ModalSlots.Base )] = "overflow-y-auto"
					},
				},
			},
		} );
	}
}
