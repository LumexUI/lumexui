// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// 
/// </summary>
public partial class LumexDropdownItem : LumexComponentBase
{
	[CascadingParameter] internal DropdownContext Context { get; set; } = default!;

	/// <inheritdoc />
	protected override void OnInitialized()
	{
		ContextNullException.ThrowIfNull( Context, nameof( LumexDropdownItem ) );
	}
}