// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

namespace LumexUI;

[ExcludeFromCodeCoverage]
public class InputFieldSlots : ISlot
{
	public string? Root { get; set; }
	public string? Label { get; set; }
	public string? MainWrapper { get; set; }
	public string? InputWrapper { get; set; }
	public string? InnerWrapper { get; set; }
	public string? Input { get; set; }
	public string? ClearButton { get; set; }
	public string? HelperWrapper { get; set; }
	public string? Description { get; set; }
	public string? ErrorMessage { get; set; }
}
