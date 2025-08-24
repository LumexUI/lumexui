using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

namespace LumexUI;

/// <summary>
/// Represents the set of customizable slots for the <see cref="LumexListboxItem{TValue}"/> component.
/// </summary>
[ExcludeFromCodeCoverage]
public class ListboxItemSlots : SlotBase
{
    /// <summary>
    /// Gets or sets the CSS class for the wrapper slot.
    /// </summary>
    public string? Wrapper { get; set; }

    /// <summary>
    /// Gets or sets the CSS class for the title slot.
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Gets or sets the CSS class for the description slot.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the CSS class for the icon slot displayed when the listbox item is selected.
    /// </summary>
    public string? SelectedIcon { get; set; }
}
