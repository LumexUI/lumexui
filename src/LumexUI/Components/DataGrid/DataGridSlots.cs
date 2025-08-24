using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

namespace LumexUI;

/// <summary>
/// Represents the set of customizable slots for the <see cref="LumexDataGrid{T}"/> component.
/// </summary>
[ExcludeFromCodeCoverage]
public class DataGridSlots : SlotBase
{
    /// <summary>
    /// Gets or sets the CSS class names for the wrapper 
    /// element that surrounds the data grid.
    /// </summary>
    public string? Wrapper { get; set; }

    /// <summary>
    /// Gets or sets the CSS class names for the wrapper of a content 
    /// displayed when the data grid is empty.
    /// </summary>
    public string? EmptyWrapper { get; set; }

    /// <summary>
    /// Gets or sets the CSS class names for the wrapper of a content 
    /// displayed while the data grid is loading.
    /// </summary>
    public string? LoadingWrapper { get; set; }

    /// <summary>
    /// Gets or sets the CSS class names for the table element within the data grid.
    /// </summary>
    public string? Table { get; set; }

    /// <summary>
    /// Gets or sets the CSS class names for the table header element (thead) in the data grid.
    /// </summary>
    public string? Thead { get; set; }

    /// <summary>
    /// Gets or sets the CSS class names for the table body element (tbody) in the data grid.
    /// </summary>
    public string? Tbody { get; set; }

    /// <summary>
    /// Gets or sets the CSS class names for the table footer element (tfoot) in the data grid.
    /// </summary>
    public string? Tfoot { get; set; }

    /// <summary>
    /// Gets or sets the CSS class names for the table row element (tr) in the data grid.
    /// </summary>
    public string? Tr { get; set; }

    /// <summary>
    /// Gets or sets the CSS class names for the table header cell (th) in the data grid.
    /// </summary>
    public string? Th { get; set; }

    /// <summary>
    /// Gets or sets the CSS class names for the table data cell (td) in the data grid.
    /// </summary>
    public string? Td { get; set; }

    /// <summary>
    /// Gets or sets the CSS class names for the placeholder content displayed in the virtualized data grid.
    /// </summary>
    public string? Placeholder { get; set; }

    /// <summary>
    /// Gets or sets the CSS class names for the sort icon displayed in sortable columns.
    /// </summary>
    public string? SortIcon { get; set; }
}
