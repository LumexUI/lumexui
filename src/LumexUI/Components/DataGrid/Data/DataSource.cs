namespace LumexUI;

/// <summary>
/// A callback that provides data for a <see cref="LumexDataGrid{T}"/>.
/// </summary>
/// <typeparam name="T">The type of data represented by each row in the grid.</typeparam>
/// <param name="request">Parameters describing the data being requested.</param>
/// <returns>A <see cref="ValueTask{GridItemsProviderResult}" /> that gives the data to be displayed.</returns>
public delegate ValueTask<DataSourceResult<T>> DataSource<T>( DataSourceRequest<T> request );
