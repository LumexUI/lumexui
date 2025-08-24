// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

namespace LumexUI;

/// <summary>
/// Represents the set of customizable slots for the <see cref="LumexTextbox"/> and <see cref="LumexNumbox{TValue}"/> components.
/// </summary>
[ExcludeFromCodeCoverage]
public class InputFieldSlots : SlotBase
{
	/// <summary>
	/// Gets or sets the CSS class for the label slot.
	/// </summary>
	public string? Label { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the main wrapper slot.
	/// </summary>
	public string? MainWrapper { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the input wrapper slot.
	/// </summary>
	public string? InputWrapper { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the inner wrapper slot.
	/// </summary>
	public string? InnerWrapper { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the input slot.
	/// </summary>
	public string? Input { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the clear button slot.
	/// </summary>
	public string? ClearButton { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the helper wrapper slot.
	/// </summary>
	public string? HelperWrapper { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the description slot.
	/// </summary>
	public string? Description { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the error message slot.
	/// </summary>
	public string? ErrorMessage { get; set; }
}
