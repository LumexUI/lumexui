// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Styles;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component representing a listbox component, used to display a selectable list of items.
/// </summary>
/// <typeparam name="T">The type of the values associated with the items in the listbox.</typeparam>
[CascadingTypeParameter( nameof( T ) )]
public partial class LumexListbox<T> : LumexComponentBase
{
    /// <summary>
    /// Gets or sets content to be rendered inside the listbox.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets content to be rendered inside the listbox when there is no items.
    /// </summary>
    [Parameter] public RenderFragment? EmptyContent { get; set; }

    /// <summary>
    /// Gets or sets an appearance style of the listbox.
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="ListboxVariant.Solid"/>
    /// </remarks>
    [Parameter] public ListboxVariant Variant { get; set; }

    /// <summary>
    /// Gets or sets a color of the listbox.
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="ThemeColor.Default"/>
    /// </remarks>
    [Parameter] public ThemeColor Color { get; set; } = ThemeColor.Default;

    /// <summary>
    /// Gets or sets the selection mode for the listbox, determining how items can be selected.
    /// </summary>
    /// <remarks>
    /// The default is <see cref="SelectionMode.None"/>
    /// </remarks>
    [Parameter] public SelectionMode SelectionMode { get; set; }

    /// <summary>
    /// Gets or sets the collection of items currently selected in the listbox.
    /// </summary>
    [Parameter] public ICollection<T>? SelectedItems { get; set; }

    /// <summary>
    /// Gets or sets the callback that is invoked when the selection of items in the listbox changes.
    /// </summary>
    [Parameter] public EventCallback<ICollection<T>> SelectedItemsChanged { get; set; }

    /// <summary>
    /// Gets or sets the collection of items currently disabled in the listbox.
    /// </summary>
    [Parameter] public ICollection<T>? DisabledItems { get; set; }

    private readonly static RenderFragment _emptyContent = builder =>
    {
        builder.AddContent( 0, "No items." );
    };

    private readonly ListboxContext<T> _context;
    private readonly RenderFragment _renderItems;
    private readonly RenderFragment _renderEmptyContent;

    private ListboxSlots _slots = default!;

    /// <summary>
    /// Initializes a new instance of the <see cref="LumexListbox{T}"/>.
    /// </summary>
    public LumexListbox()
    {
        _context = new ListboxContext<T>( this );
        _renderItems = RenderItems;
        _renderEmptyContent = RenderEmptyContent;

        As = "ul";
    }

    /// <inheritdoc />
    protected override void OnParametersSet()
    {
        _slots ??= Listbox.GetStyles( this, TwMerge );
    }
}