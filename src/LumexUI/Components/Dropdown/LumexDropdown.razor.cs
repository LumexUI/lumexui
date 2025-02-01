// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// 
/// </summary>
public partial class LumexDropdown : LumexComponentBase
{
	/// <summary>
	/// 
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	private readonly DropdownContext _context;

	/// <summary>
	/// 
	/// </summary>
	public LumexDropdown()
	{
		_context = new DropdownContext( this );
	}
}