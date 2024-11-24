using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

namespace LumexUI;

/// <summary>
/// Represents a descriptor for sorting.
/// </summary>
[ExcludeFromCodeCoverage( Justification = "Taken from the Blazor QuickGrid." )]
public readonly struct SortDescriptor
{
    /// <summary>
    /// Gets the name of the property to sort by.
    /// </summary>
    public string PropertyName { get; init; }

    /// <summary>
    /// Gets the direction in which to sort the property.
    /// </summary>
    public SortDirection Direction { get; init; }
}
