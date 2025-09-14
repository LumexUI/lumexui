// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// <see cref="LumexKbd"/> is a component to display which key or combination of keys performs a given action.
/// </summary>
public partial class LumexKbd : LumexComponentBase, ISlotComponent<KbdSlots>
{
	/// <summary>
	/// Gets or sets the content to be rendered inside the component.
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	/// <summary>
	/// Gets or sets the CSS class names for the kbd slots.
	/// </summary>
	[Parameter] public KbdSlots? Classes { get; set; }

	/// <summary>
	/// Gets or sets the collection of keys to be used as input for the component.
	/// </summary>
	[Parameter] public IEnumerable<KeyboardKey> Keys { get; set; } = [];

	private Dictionary<string, ComponentSlot> _slots = [];

	/// <summary>
	/// Initializes a new instance of the <see cref="LumexKbd"/> class, representing a keyboard element.
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

	private static string? GetKeySymbol( KeyboardKey key )
	{
		// It's better a dictionary?
		return key switch
		{
			KeyboardKey.Command => "⌘",
			KeyboardKey.Shift => "⇧",
			KeyboardKey.Control => "⌃",
			KeyboardKey.Option => "⌥",
			KeyboardKey.Enter => "↵",
			KeyboardKey.Delete => "⌫",
			KeyboardKey.Escape => "⎋",
			KeyboardKey.Tab => "⇥",
			KeyboardKey.CapsLock => "⇪",
			KeyboardKey.Up => "↑",
			KeyboardKey.Right => "→",
			KeyboardKey.Down => "↓",
			KeyboardKey.Left => "←",
			KeyboardKey.PageUp => "⇞",
			KeyboardKey.PageDown => "⇟",
			KeyboardKey.Home => "↖",
			KeyboardKey.End => "↘",
			KeyboardKey.Help => "?",
			KeyboardKey.Space => "␣",
			_ => null
		};
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
