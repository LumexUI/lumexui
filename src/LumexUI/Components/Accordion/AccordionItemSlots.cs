// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

namespace LumexUI;

/// <summary>
/// Represents the slot names for the <see cref="LumexAccordionItem"/>, 
/// used to assign CSS classes to different parts of the component.
/// </summary>
[ExcludeFromCodeCoverage]
public class AccordionItemSlots : SlotBase
{
	/// <summary>
	/// Gets or sets the CSS class for the heading slot.
	/// </summary>
	public string? Heading { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the trigger slot.
	/// </summary>
	public string? Trigger { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the title wrapper slot.
	/// </summary>
	public string? TitleWrapper { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the title slot.
	/// </summary>
	public string? Title { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the subtitle slot.
	/// </summary>
	public string? Subtitle { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the start content slot.
	/// </summary>
	public string? StartContent { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the indicator slot.
	/// </summary>
	public string? Indicator { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the content slot.
	/// </summary>
	public string? Content { get; set; }
}
