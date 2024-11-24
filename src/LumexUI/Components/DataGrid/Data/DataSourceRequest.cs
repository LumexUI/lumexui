using System.Diagnostics.CodeAnalysis;

namespace LumexUI;

/// <summary>
/// Parameters for data to be supplied by a <see cref="LumexDataGrid{T}"/>'s <see cref="LumexDataGrid{T}.DataSource"/>.
/// </summary>
/// <typeparam name="T">The type of data represented by each row in the grid.</typeparam>
[ExcludeFromCodeCoverage( Justification = "Taken from the Blazor QuickGrid." )]
public readonly struct DataSourceRequest<T>
{
    /// <summary>
    /// Gets or sets the maximum number of items to be supplied.
    /// </summary>
    public int? Count { get; init; }

    /// <summary>
    /// Gets or sets the zero-based index of the first item to be supplied.
    /// </summary>
    public int StartIndex { get; init; }

    /// <summary>
    /// Gets or sets a value indicating which column represents the sort order.
    ///
    /// Rather than inferring the sort rules manually, you should normally call either <see cref="ApplySorting(IQueryable{T})"/>
    /// or <see cref="GetSortDescriptors"/>, since they also account for <see cref="SortByColumn" /> and <see cref="SortByAscending" /> automatically.
    /// </summary>
    public LumexColumnBase<T>? SortByColumn { get; init; }

    /// <summary>
    /// Specifies the current sort direction.
    ///
    /// Rather than inferring the sort rules manually, you should normally call either <see cref="ApplySorting(IQueryable{T})"/>
    /// or <see cref="GetSortDescriptors"/>, since they also account for <see cref="SortByColumn" /> and <see cref="SortByAscending" /> automatically.
    /// </summary>
    public bool SortByAscending { get; init; }

    /// <summary>
    /// Gets or sets a token that indicates if the request should be cancelled.
    /// </summary>
    public CancellationToken CancellationToken { get; init; }

    internal DataSourceRequest(
        int? count,
        int startIndex, 
        bool sortByAscending,
        LumexColumnBase<T>? sortByColumn,
        CancellationToken cancellationToken )
    {
        Count = count;
        StartIndex = startIndex;
        SortByColumn = sortByColumn;
        SortByAscending = sortByAscending;
        CancellationToken = cancellationToken;
    }

    /// <summary>
    /// Applies the request's sorting rules to the supplied <see cref="IQueryable{TGridItem}"/>.
    /// </summary>
    /// <param name="source">An <see cref="IQueryable{TGridItem}"/>.</param>
    /// <returns>A new <see cref="IQueryable{TGridItem}"/> representing the <paramref name="source"/> with sorting rules applied.</returns>
    public IQueryable<T> ApplySorting( IQueryable<T> source ) =>
        SortByColumn?.SortBy?.Apply( source, SortByAscending ) ?? source;

    /// <summary>
    /// Produces a collection of (property name, direction) pairs representing the sorting rules.
    /// </summary>
    /// <returns>A collection of (property name, direction) pairs representing the sorting rules.</returns>
    public IReadOnlyCollection<SortDescriptor> GetSortDescriptors() =>
        SortByColumn?.SortBy?.ToPropertyList( SortByAscending ) ?? [];
}
