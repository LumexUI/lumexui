using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component representing a <see cref="LumexDataGrid{T}"/> column whose cells render a supplied template.
/// </summary>
/// <typeparam name="T">The type of data represented by each row in the grid.</typeparam>
public partial class TemplateColumn<T> : LumexColumnBase<T>
{
    /// <summary>
    /// Gets or sets the content to be rendered for each row in the column.
    /// </summary>
    [Parameter] public RenderFragment<T>? ChildContent { get; set; }

    /// <inheritdoc/>
    [Parameter] public override SortBuilder<T>? SortBy { get; set; }
}
