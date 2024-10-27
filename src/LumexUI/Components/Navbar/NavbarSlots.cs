// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

namespace LumexUI;

[ExcludeFromCodeCoverage]
public class NavbarSlots : ISlot
{
	public string? Root { get; set; }
	public string? Wrapper { get; set; }
	public string? Brand { get; set; }
	public string? Content { get; set; }
	public string? Item { get; set; }
	public string? Toggle { get; set; }
	public string? ToggleIcon { get; set; }
	public string? Menu { get; set; }
	public string? MenuItem { get; set; }
}
