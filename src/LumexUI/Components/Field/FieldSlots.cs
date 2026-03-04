// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

namespace LumexUI;

/// <summary>
/// Represents the set of customizable slots for the <see cref="LumexField"/> component.
/// </summary>
[ExcludeFromCodeCoverage]
public class FieldSlots : SlotBase
{
	/// <summary>
	/// Gets or sets the CSS class for the label slot.
	/// </summary>
	public string? Label { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the content slot.
	/// </summary>
	public string? Content { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the label wrapper slot (horizontal orientation only).
	/// </summary>
	public string? LabelWrapper { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the helper wrapper slot.
	/// </summary>
	public string? Helper { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the description slot.
	/// </summary>
	public string? Description { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the error message slot.
	/// </summary>
	public string? ErrorMessage { get; set; }
}
