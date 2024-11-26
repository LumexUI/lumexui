// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.DataGrid.Core;
using LumexUI.DataGrid.Interfaces;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;

namespace LumexUI;

/// <summary>
/// A component representing a data grid, used to display and manage collections of data.
/// </summary>
/// <typeparam name="T">The type of data represented by each row in the grid.</typeparam>
[CascadingTypeParameter( nameof( T ) )]
public partial class LumexDataGrid<T> : LumexComponentBase, IAsyncDisposable, ISlotComponent<DataGridSlots>
{
    private const string JavaScriptFile = "./_content/LumexUI/js/components/data-grid.js";

    /// <summary>
    /// Gets or sets the content to be rendered inside the data grid.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the content to be rendered inside the data grid toolbar.
    /// </summary>
    [Parameter] public RenderFragment? ToolbarContent { get; set; }

    /// <summary>
    /// Gets or sets the content to be rendered inside the data grid when there is no data available.
    /// </summary>
    [Parameter] public RenderFragment? EmptyContent { get; set; }

    /// <summary>
    /// Gets or sets the content to be rendered inside the data grid while data is loading.
    /// </summary>
    [Parameter] public RenderFragment? LoadingContent { get; set; }

    /// <summary>
    /// Gets or sets a queryable source of data for the grid.
    /// <para>
    /// This could be in-memory data converted to queryable using the
    /// <see cref="Queryable.AsQueryable{IEnumerable}"/> extension method,
    /// or an EntityFramework DataSet or an <see cref="IQueryable"/> derived from it.
    /// </para>
    /// <para>
    /// You should supply either <see cref="Data"/> or <see cref="DataSource"/>, but not both.
    /// </para>
    /// </summary>
    [Parameter] public IQueryable<T>? Data { get; set; }

    /// <summary>
    /// Gets or sets a callback that supplies data for the grid.
    /// <para>
    /// You should supply either <see cref="Data"/> or <see cref="DataSource"/>, but not both.
    /// </para>
    /// </summary>
    [Parameter] public DataSource<T>? DataSource { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the data grid is loading.
    /// </summary>
    [Parameter] public bool Loading { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether rows in the data grid should highlight on hover.
    /// </summary>
    [Parameter] public bool Hoverable { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether rows in the data grid are striped.
    /// </summary>
    [Parameter] public bool Striped { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the header of the data grid is sticky.
    /// </summary>
    [Parameter] public bool StickyHeader { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the grid will be rendered with virtualization. 
    /// This is normally used in conjunction with scrolling and causes the grid to 
    /// fetch and render only the data around the current scroll viewport.
    /// This can greatly improve the performance when scrolling through large data sets.
    /// <para>
    /// If you use <see cref="Virtualize"/>, you should supply a value for <see cref="ItemSize"/> 
    /// and must ensure that every row renders with the same constant height.
    /// </para>
    /// </summary>
    /// <remarks>
    /// Generally it's preferable not to use <see cref="Virtualize"/> if the amount of data being rendered
    /// is small or if you are using pagination.
    /// </remarks>
    [Parameter] public bool Virtualize { get; set; }

    /// <summary>
    /// Gets or sets an expected height for each row in pixels.
    /// <para>
    /// This is applicable only when using <see cref="Virtualize"/>, 
    /// allowing the virtualization mechanism to fetch the correct number of items to match the display
    /// size and to ensure accurate scrolling.
    /// </para>
    /// </summary>
    /// <remarks>
    /// The default value is 37
    /// </remarks>
    [Parameter] public float ItemSize { get; set; } = 37;

    /// <summary>
    /// Gets or sets a color used to style the selected rows and checkboxes in the data grid.
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="ThemeColor.Default"/>.
    /// </remarks>
    [Parameter] public ThemeColor Color { get; set; } = ThemeColor.Default;

    /// <summary>
    /// Gets or sets the radius of the data grid.
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="Radius.Large"/>
    /// </remarks>
    [Parameter] public Radius Radius { get; set; } = Radius.Large;

    /// <summary>
    /// Gets or sets the shadow of the data grid.
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="Shadow.Small"/>
    /// </remarks>
    [Parameter] public Shadow Shadow { get; set; } = Shadow.Small;

    /// <summary>
    /// Gets or sets the table layout algorithm used by the data grid, 
    /// determining how the table and its columns are sized.
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="Layout.Auto"/>
    /// <para>
    /// See <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/table-layout" />
    /// </para>
    /// </remarks>
    [Parameter] public Layout Layout { get; set; }

    /// <summary>
    /// Gets or sets a collection of items in the data grid that are disabled.
    /// </summary>
    [Parameter] public ICollection<T> DisabledItems { get; set; } = new HashSet<T>();

    /// <summary>
    /// Gets or sets the selection mode for the data grid, determining how rows can be selected.
    /// </summary>
    /// <remarks>
    /// The default is <see cref="SelectionMode.None"/>.
    /// </remarks>
    [Parameter] public SelectionMode SelectionMode { get; set; }

    /// <summary>
    /// Gets or sets the collection of items currently selected in the data grid.
    /// </summary>
    [Parameter] public ICollection<T> SelectedItems { get; set; } = new HashSet<T>();

    /// <summary>
    /// Gets or sets the callback that is invoked when the selection of items in the data grid changes.
    /// </summary>
    [Parameter] public EventCallback<ICollection<T>> SelectedItemsChanged { get; set; }

    /// <summary>
    /// Gets or sets the callback that is invoked when a row in the data grid is clicked.
    /// </summary>
    /// <remarks>
    /// The callback receives a <see cref="DataGridRowClickEventArgs{T}"/> containing the details of the clicked row.
    /// </remarks>
    [Parameter] public EventCallback<DataGridRowClickEventArgs<T>> OnRowClick { get; set; }

    /// <summary>
    /// Gets or sets the CSS class names for the data grid slots.
    /// </summary>
    [Parameter] public DataGridSlots? Classes { get; set; }

    [Inject] private IJSRuntime JSRuntime { get; set; } = default!;

    internal DataGridState<T> State { get; }
    internal DataGridSlots Slots { get; private set; }

    private string? RowStyles => ElementStyle.Empty()
        .Add( "height", $"{ItemSize}px", when: Virtualize )
        .ToString();

    private readonly DataGridContext<T> _context;
    private readonly List<LumexColumnBase<T>> _columns;
    private readonly Memoizer<Task> _refreshDataMemoizer;
    private readonly Memoizer<DataGridSlots> _slotsMemoizer;
    private readonly RenderFragment _renderEmptyContent;
    private readonly RenderFragment _renderLoadingContent;
    private readonly RenderFragment _renderColumnHeaders;
    private readonly RenderFragment _renderNonVirtualizedRows;

    private Virtualize<(int, T)>? _virtualizeRef;

    private ElementReference _ref;
    private IJSObjectReference? _jsModule;
    private IJSObjectReference? _jsEventDisposable;

    private bool _collectingColumns; // Columns might re-render themselves arbitrarily. We only want to capture them at a defined time.
    private ICollection<T> _currentNonVirtualizedItems;
    private CancellationTokenSource? _pendingDataLoadCts;

    /// <summary>
    /// Initializes a new instance of the <see cref="LumexDataGrid{T}"/>.
    /// </summary>
    public LumexDataGrid()
    {
        _context = new DataGridContext<T>( this );
        _slotsMemoizer = new Memoizer<DataGridSlots>();
        _refreshDataMemoizer = new Memoizer<Task>();

        _renderEmptyContent = RenderEmptyContent;
        _renderLoadingContent = RenderLoadingContent;
        _renderColumnHeaders = RenderColumnHeaders;
        _renderNonVirtualizedRows = RenderNonVirtualizedRows;

        _columns = [];
        _currentNonVirtualizedItems = [];

        State = new DataGridState<T>();
        Slots = new DataGridSlots();

        // As a special case, we don't issue the first data load request until we've collected the initial set of columns
        // This is so we can apply default sort order (or any future per-column options) before loading data
        // We use EventCallbackSubscriber to safely hook this async operation into the synchronous rendering flow
        var refreshData = () => _refreshDataMemoizer.Memoize( RefreshDataCoreAsync, [Data, DataSource] );
        var columnsFirstCollectedSubscriber = new EventCallbackSubscriber<object?>(
            EventCallback.Factory.Create<object?>( this, refreshData ) );
        columnsFirstCollectedSubscriber.SubscribeOrMove( _context.ColumnsFirstCollected );
    }

    /// <summary>
    /// Instructs the grid to re-fetch and render the current data from the supplied data source.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task RefreshDataAsync()
    {
        await RefreshDataCoreAsync();
        StateHasChanged();
    }

    /// <summary>
    /// Asynchronously sorts the data grid by the specified column in the given sort direction.
    /// </summary>
    /// <param name="column">The column to sort by.</param>
    /// <param name="direction">The direction of sorting. If the value is <see cref="SortDirection.Auto"/>, then it will toggle the direction on each call.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous sorting operation.</returns>
    public Task SortByColumnAsync( LumexColumnBase<T> column, SortDirection direction = SortDirection.Auto )
    {
        if( !column.Sortable ?? true )
        {
            return Task.CompletedTask;
        }

        State.Sort.Update( column, direction );

        StateHasChanged(); // We want to see the updated sort order in the header, even before the data query is completed
        return RefreshDataAsync();
    }

    /// <inheritdoc />
    public override Task SetParametersAsync( ParameterView parameters )
    {
        parameters.SetParameterProperties( this );

        // Set Hoverable to true if SelectionMode is not None and Hoverable was not set explicitly
        if( !parameters.TryGetValue<bool>( nameof( Hoverable ), out var _ )
            && parameters.TryGetValue<SelectionMode>( nameof( SelectionMode ), out var mode )
            && mode is not SelectionMode.None )
        {
            Hoverable = true;
        }

        return base.SetParametersAsync( ParameterView.Empty );
    }

    /// <inheritdoc />
    protected override Task OnParametersSetAsync()
    {
        if( Data is not null && DataSource is not null )
        {
            throw new InvalidOperationException(
                $"{GetType()} requires one of {nameof( Data )} or {nameof( DataSource )}, but both were specified." );
        }

        // Perform a re-building only if the dependencies have changed
        Slots = _slotsMemoizer.Memoize( GetSlots, [
            SelectionMode,
            StickyHeader,
            Hoverable,
            Striped,
            Shadow,
            Radius,
            Layout,
            Color,
            Class
        ] );

        // Perform a re-query only if the dependencies have changed
        //
        // We don't want to trigger the first data load until we've collected the initial set of columns,
        // because they might perform some action like setting the default sort order, so it would be wasteful
        // to have to re-query immediately.
        return ( _columns.Count > 0 ) ? _refreshDataMemoizer.Memoize( RefreshDataCoreAsync, [Data, DataSource] ) : Task.CompletedTask;
    }

    /// <inheritdoc />
    protected override async Task OnAfterRenderAsync( bool firstRender )
    {
        if( firstRender )
        {
            _jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>( "import", JavaScriptFile );
            _jsEventDisposable = await _jsModule.InvokeAsync<IJSObjectReference>( "dataGrid.initialize", _ref );
        }
    }

    internal void AddColumn( LumexColumnBase<T> column )
    {
        if( !_collectingColumns || !column.Visible )
        {
            return;
        }

        _columns.Add( column );
    }

    private void StartCollectingColumns()
    {
        _columns.Clear();
        _collectingColumns = true;
    }

    private void FinishCollectingColumns()
    {
        _collectingColumns = false;
    }

    // Same as RefreshDataAsync, except without forcing a re-render. We use this from OnParametersSetAsync
    // because in that case there's going to be a re-render anyway.
    private async Task RefreshDataCoreAsync()
    {
        // Move into a "loading" state, cancelling any earlier-but-still-pending load
        _pendingDataLoadCts?.Cancel();
        var currLoadCts = _pendingDataLoadCts = new CancellationTokenSource();

        if( _virtualizeRef is not null )
        {
            // If we're using Virtualize, we have to go through its RefreshDataAsync API otherwise:
            // (1) It won't know to update its own internal state if the provider output has changed
            // (2) We won't know what slice of data to query for
            await _virtualizeRef.RefreshDataAsync();
            _pendingDataLoadCts = null;
        }
        else
        {
            // If we're not using Virtualize, we build and execute a request against the data source directly
            var dataSourceRequest = new DataSourceRequest<T>(
                count: null,
                startIndex: 0,
                State.Sort.Ascending,
                State.Sort.Column,
                currLoadCts.Token );
            var dataSourceResult = await ResolveItemsRequestAsync( dataSourceRequest );

            if( !currLoadCts.IsCancellationRequested )
            {
                _currentNonVirtualizedItems = dataSourceResult.Items;
                _pendingDataLoadCts = null;
            }
        }
    }

    private async ValueTask<ItemsProviderResult<(int, T)>> ProvideVirtualizedItems( ItemsProviderRequest request )
    {
        // Debounce the requests. This eliminates a lot of redundant queries at the cost of slight lag after interactions.
        // TODO: Consider making this configurable, or smarter (e.g., doesn't delay on first call in a batch, then the amount
        // of delay increases if you rapidly issue repeated requests, such as when scrolling a long way)
        await Task.Delay( 100 );
        if( request.CancellationToken.IsCancellationRequested )
        {
            return default;
        }

        var dataSourceRequest = new DataSourceRequest<T>(
            request.Count,
            request.StartIndex,
            State.Sort.Ascending,
            State.Sort.Column,
            request.CancellationToken );
        var dataSourceResult = await ResolveItemsRequestAsync( dataSourceRequest );

        if( !request.CancellationToken.IsCancellationRequested )
        {
            // We're supplying the row index along with each row's data because we need it for aria-rowindex, and we have to account for
            // the virtualized start index. It might be more performant just to have some _latestQueryRowStartIndex field, but we'd have
            // to make sure it doesn't get out of sync with the rows being rendered.
            return new ItemsProviderResult<(int, T)>(
                 items: dataSourceResult.Items.Select( ( x, i ) => ValueTuple.Create( i + request.StartIndex + 2, x ) ),
                 totalItemCount: dataSourceResult.TotalItemCount );
        }

        return default;
    }

    private async ValueTask<DataSourceResult<T>> ResolveItemsRequestAsync( DataSourceRequest<T> request )
    {
        if( DataSource is not null )
        {
            return await DataSource( request );
        }
        else if( Data is not null )
        {
            var result = request.ApplySorting( Data ).Skip( request.StartIndex );

            if( request.Count.HasValue )
            {
                result = result.Take( request.Count.Value );
            }

            return DataSourceResult.From( result.ToArray(), totalItemCount: Data.Count() );
        }
        else
        {
            return DataSourceResult.From( items: Array.Empty<T>(), totalItemCount: 0 );
        }
    }

    private async Task OnRowClickedAsync( T item, int index, bool disabled )
    {
        if( disabled )
        {
            return;
        }

        await OnRowClick.InvokeAsync( new DataGridRowClickEventArgs<T>( item, index ) );

        if( SelectionMode is SelectionMode.None )
        {
            return;
        }

        var itemSelected = SelectedItems.Remove( item );
        if( !itemSelected )
        {
            if( SelectionMode is SelectionMode.Single )
            {
                SelectedItems.Clear();
                SelectedItems.Add( item );
            }
            else if( SelectionMode is SelectionMode.Multiple )
            {
                SelectedItems.Add( item );
            }
        }

        await SelectedItemsChanged.InvokeAsync( SelectedItems );
    }

    private void OnCellClicked( LumexColumnBase<T> column, T item, bool disabled )
    {
        if( disabled )
        {
            return;
        }

        if( column is IEditableColumn editColumn )
        {
            State.Edit.Update( editColumn, item );
        }
    }

    private void OnOutsideClick()
    {
        if( State.Edit.Editing )
        {
            State.Edit.Update( default, default );
        }
    }

    private DataGridSlots GetSlots()
    {
        return Styles.DataGrid.GetStyles( this, TwMerge );
    }

    /// <inheritdoc />
    [ExcludeFromCodeCoverage]
    public async ValueTask DisposeAsync()
    {
        try
        {
            if( _jsEventDisposable is not null )
            {
                await _jsEventDisposable.InvokeVoidAsync( "destroy" );
                await _jsEventDisposable.DisposeAsync();
            }

            if( _jsModule is not null )
            {
                await _jsModule.DisposeAsync();
            }
        }
        catch( JSDisconnectedException )
        {
            // The JS side may routinely be gone already if the reason we're disposing is that
            // the client disconnected. This is not an error.
        }
    }
}
