using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

namespace LumexUI;

/// <summary>
/// Represents a collection of customizable slots for styling various 
/// elements within the <see cref="LumexListbox{TValue}"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class ListboxSlots : ISlot
{
    /// <summary>
    /// Gets or sets the CSS class for the root slot.
    /// </summary>
    public string? Root { get; set; }

    /// <summary>
    /// Gets or sets the CSS class for the list slot.
    /// </summary>
    public string? List { get; set; }

    /// <summary>
    /// Gets or sets the CSS class for the content slot displayed when the listbox is empty.
    /// </summary>
    public string? EmptyContent { get; set; }
}
