// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Styles;
using LumexUI.Variants;

namespace LumexUI;

/// <summary>
/// A component that represents a dropdown, 
/// extending <see cref="LumexPopover"/> and inheriting its core functionalities.
/// </summary>
public partial class LumexDropdown : LumexPopover
{
	private readonly DropdownContext _context;

	private Dictionary<string, ComponentSlot> _slots = [];

	/// <summary>
	/// Initializes a new instance of the <see cref="LumexDropdown"/>.
	/// </summary>
	public LumexDropdown()
	{
		_context = new DropdownContext( this );

		Placement = PopoverPlacement.Bottom;
	}

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		base.OnParametersSet();

		var dropdown = Dropdown.Style( TwVariant );
		_slots = dropdown();

		Classes = new PopoverSlots
		{
			Content = _slots["Base"]( Classes?.Content, Class )
		};
	}
}