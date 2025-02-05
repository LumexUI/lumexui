// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

namespace LumexUI;

/// <summary>
/// 
/// </summary>
public partial class LumexDropdown : LumexPopover
{
	private readonly DropdownContext _context;

	/// <summary>
	/// 
	/// </summary>
	public LumexDropdown()
	{
		_context = new DropdownContext( this );
	}
}