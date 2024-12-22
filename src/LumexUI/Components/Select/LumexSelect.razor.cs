// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Extensions;
using LumexUI.Styles;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TValue"></typeparam>
public partial class LumexSelect<TValue> : LumexInputBase<TValue>
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
    /// Gets or sets a value indicating whether the select is full-width.
    /// </summary>
    /// <remarks>
    /// The default value is <see langword="true"/>
    /// </remarks>
    [Parameter] public bool FullWidth { get; set; } = true;

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// The default is <see cref="SelectionMode.Single"/>
    /// </remarks>
    [Parameter] public SelectionMode SelectionMode { get; set; } = SelectionMode.Single;

    /// <summary>
    /// 
    /// </summary>
    [Parameter] public ICollection<TValue> Values { get; set; } = new HashSet<TValue>();

    /// <summary>
    /// 
    /// </summary>
    [Parameter] public EventCallback<ICollection<TValue>> ValuesChanged { get; set; }

    private ICollection<TValue> CurrentValues
    {
        get => Values;
        set => SetCurrentValuesAsync( value );
    }

    private string? CurrentValuesAsString
    {
        get => CurrentValues is null ? null : string.Join( ", ", CurrentValues );
    }

    private bool HasValue =>
        CurrentValue is not null ||
        CurrentValues.Count > 0;

    private bool HasHelper =>
        !string.IsNullOrEmpty( Description ) ||
        !string.IsNullOrEmpty( ErrorMessage );

    private bool Filled =>
        _isOpened ||
        HasValue ||
        StartContent is not null ||
        EndContent is not null ||
        !string.IsNullOrEmpty( Placeholder );

    private bool ShouldLabelBeOutside => LabelPlacement is LabelPlacement.Outside;
    private bool IsMultipleSelect => SelectionMode is SelectionMode.Multiple;

    private readonly SelectContext<TValue> _context;
    private readonly RenderFragment _renderMenu;
    private readonly RenderFragment _renderLabel;
    private readonly RenderFragment _renderValue;
    private readonly RenderFragment _renderHelperWrapper;

    private bool _isOpened;
    private LumexPopover? _popoverRef;
    private SelectSlots _slots = default!;

    /// <summary>
    /// Initializes a new instance of the <see cref="LumexSelect{TValue}"/>.
    /// </summary>
    public LumexSelect()
    {
        _context = new SelectContext<TValue>( this );
        _renderMenu = RenderMenu;
        _renderLabel = RenderLabel;
        _renderValue = RenderValue;
        _renderHelperWrapper = RenderHelperWrapper;

        As = "button";
    }

    /// <inheritdoc />
    public override Task SetParametersAsync( ParameterView parameters )
    {
        if( parameters.TryGetValue<LabelPlacement>( nameof( LabelPlacement ), out var labelPlacement ) )
        {
            LabelPlacement = labelPlacement;
        }
        // Default LabelPlacement to 'Outside' if the label and the placement are not set
        else if( !parameters.TryGetValue<string>( nameof( Label ), out var _ ) )
        {
            LabelPlacement = LabelPlacement.Outside;
        }

        return base.SetParametersAsync( parameters );
    }

    /// <inheritdoc />
    protected override void OnParametersSet()
    {
        _slots ??= Select.GetStyles( this, TwMerge );
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

    private async Task OnSelectionChangeAsync( ICollection<TValue> items )
    {
        Debug.Assert( _popoverRef is not null );

        if( IsMultipleSelect )
        {
            await SetCurrentValuesAsync( items );
        }
        else
        {
            var value = items.FirstOrDefault()?.ToString();

            await SetCurrentValueAsStringAsync( value );
            await _popoverRef.HideAsync();
        }

        _context.SetSelectedItems( items );
    }

    private Task SetCurrentValuesAsync( ICollection<TValue> values )
    {
        Values = values;
        return ValuesChanged.InvokeAsync( values );
    }
}
