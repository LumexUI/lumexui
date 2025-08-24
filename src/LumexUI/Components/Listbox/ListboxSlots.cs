using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

namespace LumexUI;

/// <summary>
/// Represents the set of customizable slots for the <see cref="LumexListbox{TValue}"/> component.
/// </summary>
[ExcludeFromCodeCoverage]
public class ListboxSlots : SlotBase
{
    /// <summary>
    /// Gets or sets the CSS class for the list slot.
    /// </summary>
    public string? List { get; set; }

    /// <summary>
    /// Gets or sets the CSS class for the content slot displayed when the listbox is empty.
    /// </summary>
    public string? EmptyContent { get; set; }
}
