using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

namespace LumexUI;

/// <summary>
/// Represents the set of customizable slots for the <see cref="LumexSelect{TValue}"/> component.
/// </summary>
[ExcludeFromCodeCoverage]
public class SelectSlots : SlotBase
{
	/// <summary>
	/// Gets or sets the CSS class applied to the label slot.
	/// </summary>
	public string? Label { get; set; }

	/// <summary>
	/// Gets or sets the CSS class applied to the main wrapper slot.
	/// </summary>
	public string? MainWrapper { get; set; }

	/// <summary>
	/// Gets or sets the CSS class applied to the trigger slot.
	/// </summary>
	public string? Trigger { get; set; }

	/// <summary>
	/// Gets or sets the CSS class applied to the inner wrapper slot.
	/// </summary>
	public string? InnerWrapper { get; set; }

	/// <summary>
	/// Gets or sets the CSS class applied to the selector icon slot.
	/// </summary>
	public string? SelectorIcon { get; set; }

	/// <summary>
	/// Gets or sets the CSS class applied to the value slot.
	/// </summary>
	public string? Value { get; set; }

	/// <summary>
	/// Gets or sets the CSS class applied to the listbox slot.
	/// </summary>
	public string? Listbox { get; set; }

	/// <summary>
	/// Gets or sets the CSS class applied to the popover content slot.
	/// </summary>
	public string? PopoverContent { get; set; }

	/// <summary>
	/// Gets or sets the CSS class applied to the helper wrapper slot.
	/// </summary>
	public string? HelperWrapper { get; set; }

	/// <summary>
	/// Gets or sets the CSS class applied to the description slot.
	/// </summary>
	public string? Description { get; set; }

	/// <summary>
	/// Gets or sets the CSS class applied to the error message slot.
	/// </summary>
	public string? ErrorMessage { get; set; }
}
