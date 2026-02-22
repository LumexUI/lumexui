// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

namespace LumexUI;

/// <summary>
/// Represents the set of customizable slots for the <see cref="LumexProgressBar"/> component.
/// </summary>
[ExcludeFromCodeCoverage]
public class ProgressBarSlots : SlotBase
{
	/// <summary>
	/// Gets or sets the CSS class for the track/wrapper slot.
	/// </summary>
	public string? Track { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the fill/indicator slot.
	/// </summary>
	public string? Fill { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the label slot.
	/// </summary>
	public string? Label { get; set; }
}
