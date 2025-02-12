// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace LumexUI;

/// <summary>
/// 
/// </summary>
public partial class LumexDropdownMenu : Internal.Menu
{
	[CascadingParameter] internal DropdownContext Context { get; set; } = default!;

	private LumexDropdown Dropdown => Context.Owner;

	/// <inheritdoc />
	protected override void OnInitialized()
	{
		ContextNullException.ThrowIfNull( Context, nameof( LumexDropdownMenu ) );
	}

	/// <inheritdoc />
	protected override void BuildRenderTree( RenderTreeBuilder builder )
	{
		builder.OpenComponent<LumexPopoverContent>( 0 );
		builder.AddComponentParameter( 1, nameof( Class ), Class );
		builder.AddComponentParameter( 2, nameof( Style ), Style );
		builder.AddComponentParameter( 3, nameof( ChildContent ), (RenderFragment)base.BuildRenderTree );
		builder.AddMultipleAttributes( 4, AdditionalAttributes );
		builder.CloseComponent();
	}
}