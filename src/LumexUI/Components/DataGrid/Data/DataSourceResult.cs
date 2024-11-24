using System.Diagnostics.CodeAnalysis;

namespace LumexUI;

/// <summary>
/// Holds data being supplied to a <see cref="LumexDataGrid{T}"/>'s <see cref="LumexDataGrid{T}.DataSource"/>.
/// </summary>
/// <typeparam name="T">The type of data represented by each row in the grid.</typeparam>
[ExcludeFromCodeCoverage( Justification = "Taken from the Blazor QuickGrid." )]
public readonly struct DataSourceResult<T>
{
    /// <summary>
    /// The items being supplied.
    /// </summary>
    public required ICollection<T> Items { get; init; }

    /// <summary>
    /// The total number of items that may be displayed in the grid. This normally means the total number of items in the
    /// underlying data source after applying any filtering that is in effect.
    ///
    /// If the grid is paginated, this should include all pages. If the grid is virtualized, this should include the entire scroll range.
    /// </summary>
    public int TotalItemCount { get; init; }
}

/// <summary>
/// Provides convenience methods for constructing <see cref="DataSourceResult{T}"/> instances.
/// </summary>
public static class DataSourceResult
{
    // This is just to provide generic type inference, so you don't have to specify T yet again.

    /// <summary>
    /// Supplies an instance of <see cref="DataSourceResult{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of data represented by each row in the grid.</typeparam>
    /// <param name="items">The items being supplied.</param>
    /// <param name="totalItemCount">The total numer of items that exist. See <see cref="DataSourceResult{T}.TotalItemCount"/> for details.</param>
    /// <returns>An instance of <see cref="DataSourceResult{T}"/>.</returns>
    public static DataSourceResult<T> From<T>( ICollection<T> items, int totalItemCount )
        => new() { Items = items, TotalItemCount = totalItemCount };
}
