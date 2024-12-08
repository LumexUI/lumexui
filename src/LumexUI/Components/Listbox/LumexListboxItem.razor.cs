// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Styles;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public partial class LumexListboxItem<T> : LumexComponentBase, IDisposable
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
    [Parameter, EditorRequired] public T Key { get; set; } = default!;

    /// <summary>
    /// 
    /// </summary>
    [Parameter] public string? Description { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="ListboxVariant.Solid"/>
    /// </remarks>
    [Parameter] public ListboxVariant Variant { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="ThemeColor.Default"/>
    /// </remarks>
    [Parameter] public ThemeColor Color { get; set; } = ThemeColor.Default;

    [CascadingParameter] internal ListboxContext<T> Context { get; set; } = default!;

    private LumexListbox<T> Listbox => Context.Owner;
    private bool IsSelected => Listbox.SelectedItems.Contains( Key );

    private readonly RenderFragment _renderSelectedIcon;

    private ListboxItemSlots _slots = default!;

    /// <summary>
    /// Initializes a new instance of the <see cref="LumexListboxItem{T}"/>.
    /// </summary>
    public LumexListboxItem()
    {
        _renderSelectedIcon = RenderSelectedIcon;

        As = "li";
    }

    /// <inheritdoc />
    public override Task SetParametersAsync( ParameterView parameters )
    {
        parameters.SetParameterProperties( this );

        // Respect the Variant value if provided; otherwise, use the owner's
        Variant = parameters.TryGetValue<ListboxVariant>( nameof( Variant ), out var variant )
            ? variant
            : Context.Owner.Variant;

        // Respect the Color value if provided; otherwise, use the owner's
        Color = parameters.TryGetValue<ThemeColor>( nameof( Color ), out var color )
            ? color
            : Context.Owner.Color;

        return base.SetParametersAsync( ParameterView.Empty );
    }

    /// <inheritdoc />
    protected override void OnInitialized()
    {
        ContextNullException.ThrowIfNull( Context, nameof( LumexListboxItem<T> ) );
    }

    /// <inheritdoc />
    protected override void OnParametersSet()
    {
        if( Key is null )
        {
            throw new InvalidOperationException( $"{GetType()} requires a value for parameter '{nameof( Key )}'." );
        }

        _slots ??= ListboxItem.GetStyles( this, TwMerge );
    }

    private Task SelectItemAsync()
    {
        if( Listbox.SelectionMode is SelectionMode.None )
        {
            return Task.CompletedTask;
        }

        var selectedItems = Listbox.SelectedItems;
        if( selectedItems.Remove( Key ) )
        {
            return Listbox.SelectedItemsChanged.InvokeAsync( selectedItems );
        }

        switch( Listbox.SelectionMode )
        {
            case SelectionMode.Single:
                selectedItems.Clear();
                selectedItems.Add( Key );
                break;

            case SelectionMode.Multiple:
                selectedItems.Add( Key );
                break;
        }

        return Listbox.SelectedItemsChanged.InvokeAsync( selectedItems );
    }

    /// <inheritdoc />
    public void Dispose()
    {
        Context.Unregister( this );
    }
}