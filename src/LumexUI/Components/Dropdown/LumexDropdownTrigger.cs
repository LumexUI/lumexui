// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// 
/// </summary>
[CompositionComponent( typeof( LumexDropdown ) )]
public class LumexDropdownTrigger : LumexPopoverTrigger
{
	[CascadingParameter] internal DropdownContext DropdownContext { get; set; } = default!;

	/// <inheritdoc />
	protected override void OnInitialized()
	{
		base.OnInitialized();
		ContextNullException.ThrowIfNull( DropdownContext, nameof( LumexDropdownItem ) );
	}
}
