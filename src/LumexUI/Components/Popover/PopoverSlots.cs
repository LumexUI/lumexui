// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

namespace LumexUI;

[ExcludeFromCodeCoverage]
public class PopoverSlots : ISlot
{
	public string? Root { get; set; }
	public string? Trigger { get; set; }
	public string? Content { get; set; }
	public string? Arrow { get; set; }
}
