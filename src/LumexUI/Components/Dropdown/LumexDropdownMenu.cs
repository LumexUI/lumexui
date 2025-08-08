// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace LumexUI;

/// <summary>
/// A component that represents a menu within a <see cref="LumexDropdown"/>,
/// containing one or more <see cref="LumexDropdownItem"/>.
/// </summary>
[CompositionComponent( typeof( LumexDropdown ) )]
public partial class LumexDropdownMenu : Menu, ISlotComponent<DropdownMenuSlots>
{
	/// <summary>
	/// Gets or sets the CSS class names for the dropdown menu slots.
	/// </summary>
	[Parameter] public new DropdownMenuSlots? Classes { get; set; }

	/// <summary>
	/// Gets or sets the CSS class names for the dropdown item slots.
	/// </summary>
	[Parameter] public new DropdownItemSlots? ItemClasses { get; set; }

	[CascadingParameter] internal DropdownContext Context { get; set; } = default!;

	/// <inheritdoc />
	protected override void OnInitialized()
	{
		ContextNullException.ThrowIfNull( Context, nameof( LumexDropdownMenu ) );
	}

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		base.OnParametersSet();
		base.Classes = Classes;
		base.ItemClasses = ItemClasses;
	}

	/// <inheritdoc />
	protected override void BuildRenderTree( RenderTreeBuilder builder )
	{
		builder.OpenComponent<LumexPopoverContent>( 0 );
		builder.AddComponentParameter( 1, nameof( ChildContent ), (RenderFragment)base.BuildRenderTree );
		builder.CloseComponent();
	}
}