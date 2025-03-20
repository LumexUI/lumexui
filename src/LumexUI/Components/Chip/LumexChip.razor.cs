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
/// 
/// </summary>
public partial class LumexChip : LumexComponentBase, ISlotComponent<ChipSlots>
{
	/// <summary>
	/// 
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[Parameter] public RenderFragment? StartContent { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[Parameter] public RenderFragment? EndContent { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[Parameter] public EventCallback<MouseEventArgs> OnClose { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[Parameter] public ChipSlots? Classes { get; set; }

	private Dictionary<string, ComponentSlot> _slots = [];

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		var chip = Styles.Chip.Style( TwMerge );
		_slots = chip( new() );
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