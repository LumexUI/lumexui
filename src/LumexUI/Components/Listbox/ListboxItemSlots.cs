using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

namespace LumexUI;

/// <summary>
/// Represents a collection of customizable slots for styling various 
/// elements within a <see cref="LumexListboxItem{TValue}"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class ListboxItemSlots : ISlot
{
    /// <summary>
    /// Gets or sets the CSS class for the root slot.
    /// </summary>
    public string? Root { get; set; }

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
