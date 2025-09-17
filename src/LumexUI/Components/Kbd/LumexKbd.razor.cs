// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component that represents a keyboard key or combination of keys used to perform a specific action.
/// </summary>
public partial class LumexKbd : LumexComponentBase, ISlotComponent<KbdSlots>
{
	/// <summary>
	/// Gets or sets the content to be rendered inside the component.
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	/// <summary>
	/// Gets or sets the collection of keys to be used as input for the component.
	/// </summary>
	[Parameter] public IEnumerable<KeyboardKey> Keys { get; set; } = [];

	/// <summary>
	/// Gets or sets the CSS class names for the kbd slots.
	/// </summary>
	[Parameter] public KbdSlots? Classes { get; set; }

	private Dictionary<string, ComponentSlot> _slots = [];

	/// <summary>
	/// Initializes a new instance of the <see cref="LumexKbd"/>.
	/// </summary>
	public LumexKbd()
	{
		As = "kbd";
	}

	/// <inheritdoc/>
	protected override void OnParametersSet()
	{
		var kbd = Styles.Kbd.Style( TwMerge );
		_slots = kbd();
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
			nameof( KbdSlots.Base ) => styles( Classes?.Base, Class ),
			nameof( KbdSlots.Abbr ) => styles( Classes?.Abbr ),
			nameof( KbdSlots.Content ) => styles( Classes?.Content ),
			_ => throw new NotImplementedException()
		};
	}
}
