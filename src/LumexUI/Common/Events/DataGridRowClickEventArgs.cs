using System.Diagnostics.CodeAnalysis;

namespace LumexUI.Common;

/// <summary>
/// Provides data for the <see cref="LumexDataGrid{T}.OnRowClick"/> event, 
/// including the clicked item and its index.
/// </summary>
/// <typeparam name="T">The type of data represented by the row.</typeparam>
[ExcludeFromCodeCoverage]
public class DataGridRowClickEventArgs<T> : EventArgs
{
    /// <summary>
    /// Gets the data item associated with the clicked row.
    /// </summary>
    public T Item { get; }

    /// <summary>
    /// Gets the index of the clicked row in the data grid.
    /// </summary>
    public int Index { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DataGridRowClickEventArgs{T}"/> class with the specified item and index.
    /// </summary>
    /// <param name="item">The data item associated with the clicked row.</param>
    /// <param name="index">The index of the clicked row.</param>
    public DataGridRowClickEventArgs( T item, int index )
    {
        Item = item;
        Index = index;
    }
}

