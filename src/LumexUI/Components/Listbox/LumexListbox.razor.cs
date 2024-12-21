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
/// <typeparam name="TValue">The type of the values associated with the items in the listbox.</typeparam>
[CascadingTypeParameter( nameof( TValue ) )]
public partial class LumexListbox<TValue> : LumexComponentBase
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
    /// Gets or sets the collection of items currently disabled in the listbox.
    /// </summary>
    [Parameter] public ICollection<TValue?>? DisabledItems { get; set; }

    /// <summary>
    /// Gets or sets an item currently selected in the listbox.
    /// </summary>
    [Parameter] public TValue? Value { get; set; }

    /// <summary>
    /// Gets or sets the collection of items currently selected in the listbox.
    /// </summary>
    [Parameter] public ICollection<TValue?>? Values { get; set; }

    /// <summary>
    /// Gets or sets the callback that is invoked when the selection of item in the listbox changes.
    /// </summary>
    [Parameter] public EventCallback<TValue?> ValueChanged { get; set; }

    /// <summary>
    /// Gets or sets the callback that is invoked when the selection of items in the listbox changes.
    /// </summary>
    [Parameter] public EventCallback<ICollection<TValue?>> ValuesChanged { get; set; }

    private readonly static RenderFragment _emptyContent = builder =>
    {
        builder.AddContent( 0, "No items." );
    };

    private readonly ListboxContext<TValue> _context;
    private readonly RenderFragment _renderItems;
    private readonly RenderFragment _renderEmptyContent;

    private ListboxSlots _slots = default!;

    /// <summary>
    /// Initializes a new instance of the <see cref="LumexListbox{T}"/>.
    /// </summary>
    public LumexListbox()
    {
        _context = new ListboxContext<TValue>( this );
        _renderItems = RenderItems;
        _renderEmptyContent = RenderEmptyContent;

        As = "ul";
    }

    /// <inheritdoc />
    public override Task SetParametersAsync( ParameterView parameters )
    {
        parameters.SetParameterProperties( this );

        if( parameters.TryGetValue<TValue>( nameof( Value ), out var _ ) &&
            parameters.TryGetValue<ICollection<TValue>>( nameof( Values ), out var _ ) )
        {
            throw new InvalidOperationException(
                $"{GetType()} requires one of {nameof( Value )} or {nameof( Values )}, but both were specified." );
        }

        // Automatically set the SelectionMode depending on
        // which of the 2-way bindable parameters are provided.
        if( parameters.TryGetValue<TValue>( nameof( Value ), out var _ ) )
        {
            _context.SelectionMode = SelectionMode.Single;
        }
        else if( parameters.TryGetValue<ICollection<TValue>>( nameof( Values ), out var _ ) )
        {
            _context.SelectionMode = SelectionMode.Multiple;
        }

        return base.SetParametersAsync( ParameterView.Empty );
    }

    /// <inheritdoc />
    protected override void OnParametersSet()
    {
        _slots ??= Listbox.GetStyles( this, TwMerge );
    }
}