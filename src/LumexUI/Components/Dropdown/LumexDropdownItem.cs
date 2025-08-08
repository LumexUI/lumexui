// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace LumexUI;

/// <summary>
/// A component that represents an item within a <see cref="LumexDropdown"/>.
/// </summary>
[CompositionComponent( typeof( LumexDropdown ) )]
public partial class LumexDropdownItem : MenuItem, ISlotComponent<DropdownItemSlots>
{
	/// <summary>
	/// Gets or sets the CSS class names for the dropdown item slots.
	/// </summary>
	[Parameter] public new DropdownItemSlots? Classes { get; set; }

	[CascadingParameter] internal DropdownContext DropdownContext { get; set; } = default!;

	private LumexDropdown Dropdown => DropdownContext.Owner;

	/// <inheritdoc />
	protected override void OnInitialized()
	{
		base.OnInitialized();
		ContextNullException.ThrowIfNull( DropdownContext, nameof( LumexDropdownItem ) );
	}

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		base.OnParametersSet();
		base.Classes = Classes;
	}

	private protected override async Task OnClickAsync( MouseEventArgs args )
	{
		if( _disabled || ReadOnly )
		{
			return;
		}

		await Dropdown.CloseAsync();
		await OnClick.InvokeAsync( args );

		Dropdown.Rerender();
	}
}
