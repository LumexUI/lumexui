// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Extensions;
using LumexUI.Styles;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TValue"></typeparam>
public partial class LumexSelect<TValue> : LumexInputBase<TValue>, ISlotComponent<SelectSlots>
{
    /// <summary>
    /// 
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [Parameter] public RenderFragment? StartContent { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [Parameter] public RenderFragment? EndContent { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [Parameter] public string? Label { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [Parameter] public string? Placeholder { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [Parameter] public string? Description { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [Parameter] public string? ErrorMessage { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="LabelPlacement.Inside"/>
    /// </remarks>
    [Parameter] public LabelPlacement LabelPlacement { get; set; } = LabelPlacement.Inside;

    /// <summary>
    /// Gets or sets the appearance variant of the select.
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="InputVariant.Flat"/>
    /// </remarks>
    [Parameter] public InputVariant Variant { get; set; }

    /// <summary>
    /// Gets or sets the border radius of the select.
    /// </summary>
    [Parameter] public Radius? Radius { get; set; }

    /// <summary>
    /// Gets or sets a maximum height of the listbox containing options.
    /// </summary>
    /// <remarks>
    /// The default value is 256
    /// </remarks>
    [Parameter] public float ListboxMaxHeight { get; set; } = 256;

    /// <summary>
    /// Gets or sets a value indicating whether the select is full-width.
    /// </summary>
    /// <remarks>
    /// The default value is <see langword="true"/>
    /// </remarks>
    [Parameter] public bool FullWidth { get; set; } = true;

    /// <summary>
    /// Gets or sets the collection of items currently disabled in the select.
    /// </summary>
    [Parameter] public ICollection<TValue?>? DisabledItems { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [Parameter] public ICollection<TValue>? Values { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [Parameter] public EventCallback<ICollection<TValue>> ValuesChanged { get; set; }

    /// <summary>
    /// Gets or sets the CSS class names for the select slots.
    /// </summary>
    [Parameter] public SelectSlots? Classes { get; set; }

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
        _isOpened ||
        HasValue ||
        StartContent is not null ||
        EndContent is not null ||
        !string.IsNullOrEmpty( Placeholder );

    private readonly SelectContext<TValue> _context;
    private readonly Memoizer<SelectSlots> _slotsMemoizer;
    private readonly RenderFragment _renderMenu;
    private readonly RenderFragment _renderLabel;
    private readonly RenderFragment _renderValue;
    private readonly RenderFragment _renderHelperWrapper;

    private SelectSlots _slots = default!;
    private LumexPopover? _popoverRef;

    private bool _isOpened;
    private bool _hasInitializedParameters;

    /// <summary>
    /// Initializes a new instance of the <see cref="LumexSelect{TValue}"/>.
    /// </summary>
    public LumexSelect()
    {
        _context = new SelectContext<TValue>( this );
        _slotsMemoizer = new Memoizer<SelectSlots>();
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
    }

    /// <inheritdoc />
    protected override bool TryParseValueFromString( string? value, [MaybeNullWhen( false )] out TValue result )
        => this.TryParseSelectableValueFromString( value, out result );

    /// <inheritdoc />
    protected override string? FormatValueAsString( TValue? value )
    {
        // We special-case bool values because BindConverter reserves bool conversion for conditional attributes.
        if( typeof( TValue ) == typeof( bool ) )
        {
            return (bool)(object)value! ? "true" : "false";
        }
        else if( typeof( TValue ) == typeof( bool? ) )
        {
            return value is not null && (bool)(object)value ? "true" : "false";
        }

        return base.FormatValueAsString( value );
    }

    /// <inheritdoc />
    protected override ValueTask SetValidationMessageAsync()
    {
        // This component doesn't have a validation message by default.
        return ValueTask.CompletedTask;
    }

    private Task TriggerAsync()
    {
        if( _popoverRef is null )
        {
            return Task.CompletedTask;
        }

        return _popoverRef.TriggerAsync();
    }

    private async Task OnValueChangedAsync( TValue? value )
    {
        Debug.Assert( _popoverRef is not null );

        await SetCurrentValueAsync( value );
        await _popoverRef.HideAsync();
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
}
