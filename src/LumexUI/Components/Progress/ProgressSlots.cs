// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

namespace LumexUI;

/// <summary>
/// Represents the set of customizable slots for the <see cref="LumexProgress"/> component.
/// </summary>
[ExcludeFromCodeCoverage]
public class ProgressSlots : SlotBase
{
	/// <summary>
	/// Gets or sets the CSS class for the base/root slot.
	/// </summary>
	public string? Base { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the label wrapper slot.
	/// </summary>
	public string? LabelWrapper { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the label slot.
	/// </summary>
	public string? Label { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the value slot.
	/// </summary>
	public string? Value { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the track slot.
	/// </summary>
	public string? Track { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the indicator/fill slot.
	/// </summary>
	public string? Indicator { get; set; }

}
