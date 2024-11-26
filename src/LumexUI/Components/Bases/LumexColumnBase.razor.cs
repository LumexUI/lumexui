// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace LumexUI;

/// <summary>
/// Represents a base class for columns in a <see cref="LumexDataGrid{T}"/>.
/// </summary>
/// <typeparam name="T">The type of data represented by each row in the grid.</typeparam>
public abstract partial class LumexColumnBase<T> : LumexComponentBase
{
    /// <summary>
    /// Gets or sets the content to be rendered in the column header.
    /// </summary>
    [Parameter] public RenderFragment<LumexColumnBase<T>>? HeaderContent { get; set; }

    /// <summary>
    /// Gets or sets the content to be rendered in the column cells whose data has not yet been loaded.
    /// </summary>
    [Parameter] public RenderFragment<PlaceholderContext>? PlaceholderContent { get; set; }

    /// <summary>
    /// Gets or sets the title text for the column.
    /// </summary>
    [Parameter] public string? Title { get; set; }

    /// <summary>
    /// Gets or sets the alignment of the content within the grid column.
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="Align.Start"/>
    /// </remarks>
    [Parameter] public Align Align { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the column is visible.
    /// </summary>
    /// <remarks>
    /// The default value is <see langword="true"/>
    /// </remarks>
    [Parameter] public bool Visible { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether the data should be sortable by this column.
    /// </summary>
    [Parameter] public bool? Sortable { get; set; }

    [CascadingParameter] internal DataGridContext<T> Context { get; set; } = default!;

    /// <summary>
    /// Gets or sets the sorting rules for a column.
    /// </summary>
    public abstract SortBuilder<T>? SortBy { get; set; }

    /// <summary>
    /// Gets a reference to the enclosing <see cref="LumexDataGrid{T}" />.
    /// </summary>
    public LumexDataGrid<T> DataGrid => Context.Owner;

    internal DataGridState<T> State => Context.Owner.State;

    /// <inheritdoc />
    protected override void OnInitialized()
    {
        ContextNullException.ThrowIfNull( Context, nameof( LumexColumnBase<T> ) );
    }

    internal string GetAriaSortValue()
    {
        if( State.Sort.Column != this )
        {
            return "none";
        }

        return State.Sort.Ascending ? "ascending" : "descending";
    }
}
