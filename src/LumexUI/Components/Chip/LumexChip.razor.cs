// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace LumexUI;

/// <summary>
/// A component that represents a chip, typically used to display tags.
/// </summary>
public partial class LumexChip : LumexComponentBase, ISlotComponent<ChipSlots>
{
	/// <summary>
	/// Gets or sets the content to render inside the chip.
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	/// <summary>
	/// Gets or sets the content to render at the start.
	/// </summary>
	[Parameter] public RenderFragment? StartContent { get; set; }

	/// <summary>
	/// Gets or sets the content to render at the end.
	/// </summary>
	[Parameter] public RenderFragment? EndContent { get; set; }

	/// <summary>
	/// Gets or sets the content to render as the avatar.
	/// </summary>
	[Parameter] public RenderFragment? AvatarContent { get; set; }

	/// <summary>
	/// Gets or sets the size of the chip.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Size.Medium"/>.
	/// </remarks>
	[Parameter] public Size Size { get; set; } = Size.Medium;

	/// <summary>
	/// Gets or sets the border radius of the chip.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Radius.Full"/>.
	/// </remarks>
	[Parameter] public Radius Radius { get; set; } = Radius.Full;

	/// <summary>
	/// Gets or sets the color of the chip.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="ThemeColor.Primary"/>.
	/// </remarks>
	[Parameter] public ThemeColor Color { get; set; } = ThemeColor.Default;

	/// <summary>
	/// Gets or sets the visual variant of the chip.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="ChipVariant.Solid"/>.
	/// </remarks>
	[Parameter] public ChipVariant Variant { get; set; } = ChipVariant.Solid;

	/// <summary>
	/// Gets or sets a value indicating whether the chip is disabled.
	/// </summary>
	[Parameter] public bool Disabled { get; set; }

	/// <summary>
	/// Gets or sets the callback invoked when the chip is closed.
	/// </summary>
	[Parameter] public EventCallback<MouseEventArgs> OnClose { get; set; }

	/// <summary>
	/// Gets or sets the CSS class names for the chip slots.
	/// </summary>
	[Parameter] public ChipSlots? Classes { get; set; }

	private Dictionary<string, ComponentSlot> _slots = [];

	internal bool HasStartContent => StartContent is not null;
	internal bool HasEndContent => EndContent is not null || OnClose.HasDelegate;

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		var chip = Styles.Chip.Style( TwMerge );
		_slots = chip( new()
		{
			[nameof( Size )] = Size.ToString(),
			[nameof( Color )] = Color.ToString(),
			[nameof( Radius )] = Radius.ToString(),
			[nameof( Variant )] = Variant.ToString(),
			[nameof( Disabled )] = Disabled.ToString()
		} );
	}

	private Task OnCloseAsync( MouseEventArgs args )
	{
		if( Disabled )
		{
			return Task.CompletedTask;
		}

		return OnClose.InvokeAsync( args );
	}

	[ExcludeFromCodeCoverage]
	private string? GetStyles( string slot )
	{
		if( !_slots.TryGetValue( slot, out var styles ) )
		{
			throw new NotImplementedException();
		}

		return slot switch
		{
			nameof( ChipSlots.Base ) => styles( Classes?.Base, Class ),
			nameof( ChipSlots.Content ) => styles( Classes?.Content ),
			nameof( ChipSlots.Dot ) => styles( Classes?.Dot ),
			nameof( ChipSlots.CloseButton ) => styles( Classes?.CloseButton ),
			_ => throw new NotImplementedException()
		};
	}
}