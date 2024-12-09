// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Styles;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace LumexUI;

/// <summary>
/// A component representing an item within the <see cref="LumexListbox{T}"/>.
/// </summary>
/// <typeparam name="T">The type of the value associated with the listbox item.</typeparam>
public partial class LumexListboxItem<T> : LumexComponentBase, IDisposable
{
    /// <summary>
    /// Gets or sets a unique identifier for the listbox item.
    /// </summary>
    [Parameter, EditorRequired] public T Id { get; set; } = default!;

    /// <summary>
    /// Gets or sets content to be rendered inside the listbox item.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets content to be rendered at the start of the listbox item.
    /// </summary>
    [Parameter] public RenderFragment? StartContent { get; set; }

    /// <summary>
    /// Gets or sets content to be rendered at the end of the listbox item.
    /// </summary>
    [Parameter] public RenderFragment? EndContent { get; set; }

    /// <summary>
    /// Gets or sets a description of the listbox item.
    /// </summary>
    [Parameter] public string? Description { get; set; }

    /// <summary>
    /// Gets or sets an appearance style of the listbox item.
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="ListboxVariant.Solid"/>
    /// </remarks>
    [Parameter] public ListboxVariant Variant { get; set; }

    /// <summary>
    /// Gets or sets a color of the listbox item.
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="ThemeColor.Default"/>
    /// </remarks>
    [Parameter] public ThemeColor Color { get; set; } = ThemeColor.Default;

    /// <summary>
    /// Gets or sets a value indicating whether the listbox item is disabled.
    /// </summary>
    [Parameter] public bool Disabled { get; set; }

    /// <summary>
    /// Gets or sets a callback that is fired whenever the listbox item is clicked.
    /// </summary>
    [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

    [CascadingParameter] internal ListboxContext<T> Context { get; set; } = default!;

    private LumexListbox<T> Listbox => Context.Owner;

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
        if( Id is null )
        {
            throw new InvalidOperationException( $"{GetType()} requires a value for parameter '{nameof( Id )}'." );
        }

        _slots ??= ListboxItem.GetStyles( this, TwMerge );
    }

    internal bool GetSelectedState() =>
        Listbox.SelectedItems is not null && Listbox.SelectedItems.Contains( Id );

    internal bool GetDisabledState() =>
        Listbox.DisabledItems is not null && Listbox.DisabledItems.Contains( Id );

    private async Task OnClickAsync( MouseEventArgs args )
    {
        if( GetDisabledState() )
        {
            return;
        }

        await OnClick.InvokeAsync( args );

        if( Listbox.SelectionMode is not SelectionMode.None )
        {
            await SelectAsync();
        }
    }

    private Task SelectAsync()
    {
        if( Listbox.SelectedItems is null )
        {
            return Task.CompletedTask;
        }

        var selectedItems = Listbox.SelectedItems;
        if( selectedItems.Remove( Id ) )
        {
            return Listbox.SelectedItemsChanged.InvokeAsync( selectedItems );
        }

        switch( Listbox.SelectionMode )
        {
            case SelectionMode.Single:
                selectedItems.Clear();
                selectedItems.Add( Id );
                break;

            case SelectionMode.Multiple:
                selectedItems.Add( Id );
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