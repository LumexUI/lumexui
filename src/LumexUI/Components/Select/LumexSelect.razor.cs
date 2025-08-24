// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Styles;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component representing a select input component, allowing users to choose from a list of options.
/// </summary>
/// <typeparam name="TValue">The type of the value associated with the options in the select.</typeparam>
public partial class LumexSelect<TValue> : LumexInputBase<TValue>, ISlotComponent<SelectSlots>
{
    /// <summary>
    /// Gets or sets the content to be rendered inside the select input.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the content to be rendered at the start of the select input.
    /// </summary>
    [Parameter] public RenderFragment? StartContent { get; set; }

    /// <summary>
    /// Gets or sets the content to be rendered at the end of the select input.
    /// </summary>
    [Parameter] public RenderFragment? EndContent { get; set; }

    /// <summary>
    /// Gets or sets the content to display for the currently selected value.
    /// </summary>
    [Parameter] public RenderFragment<TValue?>? ValueContent { get; set; }

    /// <summary>
    /// Gets or sets the label for the select input.
    /// </summary>
    [Parameter] public string? Label { get; set; }

    /// <summary>
    /// Gets or sets the placeholder text to display when no value is selected.
    /// </summary>
    [Parameter] public string? Placeholder { get; set; }

    /// <summary>
    /// Gets or sets the description text to display below the select input.
    /// </summary>
    [Parameter] public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the error message to display when the select input is in an invalid state.
    /// </summary>
    [Parameter] public string? ErrorMessage { get; set; }

    /// <summary>
    /// Gets or sets the placement of the label of the select input.
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="LabelPlacement.Inside"/>
    /// </remarks>
    [Parameter] public LabelPlacement LabelPlacement { get; set; }

    /// <summary>
    /// Gets or sets the appearance variant of the select input.
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="InputVariant.Flat"/>
    /// </remarks>
    [Parameter] public InputVariant Variant { get; set; }

    /// <summary>
    /// Gets or sets the border radius of the select input.
    /// </summary>
    [Parameter] public Radius? Radius { get; set; }

    /// <summary>
    /// Gets or sets the maximum height of the options listbox.
    /// </summary>
    /// <remarks>
    /// The default value is 256
    /// </remarks>
    [Parameter] public float ListboxMaxHeight { get; set; } = 256;

    /// <summary>
    /// Gets or sets a value indicating whether the select input is full-width.
    /// </summary>
    /// <remarks>
    /// The default value is <see langword="true"/>
    /// </remarks>
    [Parameter] public bool FullWidth { get; set; } = true;

    /// <summary>
    /// Gets or sets the collection of items currently disabled in the select input.
    /// </summary>
    [Parameter] public ICollection<TValue?>? DisabledItems { get; set; }

    /// <summary>
    /// Gets or sets the collection of selected values in the select input.
    /// </summary>
    [Parameter] public ICollection<TValue>? Values { get; set; }

    /// <summary>
    /// Gets or sets the callback invoked when the collection of selected values changes.
    /// </summary>
    [Parameter] public EventCallback<ICollection<TValue>> ValuesChanged { get; set; }

    /// <summary>
    /// Gets or sets the CSS class names for the select slots.
    /// </summary>
    [Parameter] public SelectSlots? Classes { get; set; }

    /// <summary>
    /// Gets or sets the CSS class names for the listbox slots.
    /// </summary>
    [Parameter] public PopoverSlots? PopoverClasses { get; set; }

    /// <summary>
    /// Gets or sets the CSS class names for the listbox slots.
    /// </summary>
    [Parameter] public ListboxSlots? ListboxClasses { get; set; }

    private string? ListboxStyles => ElementStyle.Empty()
        .Add( "max-height", $"{ListboxMaxHeight}px" )
        .ToString();

    private ICollection<TValue>? CurrentValues
    {
        get => Values;
        set => _ = SetCurrentValuesAsync( value );
    }

    private bool ShouldLabelBeOutside => LabelPlacement is LabelPlacement.Outside;

    private bool HasValue => _context.IsMultiSelect
        ? CurrentValues is { Count: > 0 }
        : CurrentValue is not null;

    private bool HasHelper =>
        !string.IsNullOrEmpty( Description ) ||
        !string.IsNullOrEmpty( ErrorMessage );

    private bool Filled =>
        _isOpen ||
        HasValue ||
        StartContent is not null ||
        EndContent is not null ||
        !string.IsNullOrEmpty( Placeholder );

    private readonly SelectContext<TValue> _context;
    private readonly Memoizer<SelectSlots> _slotsMemoizer;
    private readonly Memoizer<PopoverSlots> _popoverSlotsMemoizer;
    private readonly Memoizer<ListboxSlots> _listboxSlotsMemoizer;
    private readonly RenderFragment _renderMenu;
    private readonly RenderFragment _renderLabel;
    private readonly RenderFragment _renderValue;
    private readonly RenderFragment _renderHelperWrapper;

    private SelectSlots _slots = default!;
    private PopoverSlots _popoverSlots = default!;
    private ListboxSlots _listboxSlots = default!;
    private LumexPopover? _popoverRef;

    private bool _isOpen;
    private bool _hasInitializedParameters;

    /// <summary>
    /// Initializes a new instance of the <see cref="LumexSelect{TValue}"/>.
    /// </summary>
    public LumexSelect()
    {
        _context = new SelectContext<TValue>( this );
        _slotsMemoizer = new Memoizer<SelectSlots>();
        _popoverSlotsMemoizer = new Memoizer<PopoverSlots>();
        _listboxSlotsMemoizer = new Memoizer<ListboxSlots>();

        _renderMenu = RenderMenu;
        _renderLabel = RenderLabel;
        _renderValue = RenderValue;
        _renderHelperWrapper = RenderHelperWrapper;

        As = "button";
    }

    /// <inheritdoc />
    public override async Task SetParametersAsync( ParameterView parameters )
    {
        await base.SetParametersAsync( parameters );

        if( !_hasInitializedParameters )
        {
            if( parameters.TryGetValue<TValue>( nameof( Value ), out var _ ) &&
                parameters.TryGetValue<ICollection<TValue>>( nameof( Values ), out var _ ) )
            {
                throw new InvalidOperationException(
                    $"{GetType()} requires one of {nameof( Value )} or {nameof( Values )}, but both were specified." );
            }

            // Set the selection mode depending on the 2-way bindable parameter.
            _context.IsMultiSelect = parameters.TryGetValue<ICollection<TValue>>( nameof( Values ), out _ );

            // Set the LabelPlacement to 'Outside' by default if both Label and LabelPlacement are not specified.
            if( !parameters.TryGetValue<string>( nameof( Label ), out var _ ) &&
                !parameters.TryGetValue<LabelPlacement>( nameof( LabelPlacement ), out var _ ) )
            {
                LabelPlacement = LabelPlacement.Outside;
            }

            _hasInitializedParameters = true;
        }
    }

    /// <inheritdoc />
    protected override void OnParametersSet()
    {
        // Perform a re-building only if the dependencies have changed
        _slots = _slotsMemoizer.Memoize( GetSlots, [
            LabelPlacement,
            FullWidth,
            Required,
            Disabled,
            Invalid,
            Variant,
            Radius,
            Color,
            Size,
            Class,
            Classes
        ] );

        // Perform a re-building only if the dependencies have changed
        _popoverSlots = _popoverSlotsMemoizer.Memoize( GetPopoverSlots, [
            _slots.PopoverContent,
            Classes?.PopoverContent,
            PopoverClasses
        ] );

        // Perform a re-building only if the dependencies have changed
        _listboxSlots = _listboxSlotsMemoizer.Memoize( GetListboxSlots, [
            _slots.Listbox,
            Classes?.Listbox,
            ListboxClasses
        ] );
    }

    /// <inheritdoc />
    [ExcludeFromCodeCoverage]
    protected override bool TryParseValueFromString( string? value, [MaybeNullWhen( false )] out TValue result )
    {
        result = default;
        return false;
    }

    private Task TriggerAsync()
    {
        if( _popoverRef is null || ReadOnly )
        {
            return Task.CompletedTask;
        }

        return _popoverRef.TriggerAsync();
    }

    private async Task OnValueChangedAsync( TValue? value )
    {
        Debug.Assert( _popoverRef is not null );

        await SetCurrentValueAsync( value );
        await _popoverRef.CloseAsync();
        _context.UpdateSelectedItem( CurrentValue );
    }

    private async Task OnValuesChangedAsync( ICollection<TValue> values )
    {
        await SetCurrentValuesAsync( values );
        _context.UpdateSelectedItems( CurrentValues );
    }

    private Task SetCurrentValuesAsync( ICollection<TValue>? values )
    {
        Values = values;
        return ValuesChanged.InvokeAsync( Values );
    }

    private SelectSlots GetSlots()
    {
        return Select.GetStyles( this, TwMerge );
    }

    private PopoverSlots GetPopoverSlots()
    {
        return new PopoverSlots
        {
            Base = ElementClass.Empty()
                .Add( PopoverClasses?.Base )
                .ToString(),

            Content = ElementClass.Empty()
                .Add( _slots.PopoverContent )
                .Add( Classes?.PopoverContent )
                .Add( PopoverClasses?.Content )
                .ToString(),

            Trigger = ElementClass.Empty()
                .Add( PopoverClasses?.Trigger )
                .ToString(),

            Arrow = ElementClass.Empty()
                .Add( PopoverClasses?.Arrow )
                .ToString()
        };
    }

    private ListboxSlots GetListboxSlots()
    {
        return new ListboxSlots
        {
            Base = ElementClass.Empty()
                .Add( _slots.Listbox )
                .Add( Classes?.Listbox )
                .Add( ListboxClasses?.Base )
                .ToString(),

            List = ElementClass.Empty()
                .Add( ListboxClasses?.List )
                .ToString(),

            EmptyContent = ElementClass.Empty()
                .Add( ListboxClasses?.EmptyContent )
                .ToString()
        };
    }
}
