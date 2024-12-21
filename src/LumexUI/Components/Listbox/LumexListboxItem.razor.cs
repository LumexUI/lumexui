// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics;

using LumexUI.Common;
using LumexUI.Styles;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace LumexUI;

/// <summary>
/// A component representing an item within the <see cref="LumexListbox{T}"/>.
/// </summary>
/// <typeparam name="TValue">The type of the value associated with the listbox item.</typeparam>
public partial class LumexListboxItem<TValue> : LumexComponentBase, IDisposable
{
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
    /// Gets or sets a value representing the listbox item.
    /// </summary>
    [Parameter] public TValue? Value { get; set; }

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

    [CascadingParameter] internal ListboxContext<TValue>? Context { get; set; }

    private LumexListbox<TValue>? Listbox => Context?.Owner;

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

        if( Listbox is not null )
        {
            // Respect the Variant value if provided; otherwise, use the owner's
            Variant = parameters.TryGetValue<ListboxVariant>( nameof( Variant ), out var variant )
                ? variant
                : Listbox.Variant;

            // Respect the Color value if provided; otherwise, use the owner's
            Color = parameters.TryGetValue<ThemeColor>( nameof( Color ), out var color )
                ? color
                : Listbox.Color;
        }

        return base.SetParametersAsync( ParameterView.Empty );
    }

    /// <inheritdoc />
    protected override void OnInitialized()
    {
        ContextNullException.ThrowIfNull( Context, nameof( LumexListboxItem<TValue> ) );
    }

    /// <inheritdoc />
    protected override void OnParametersSet()
    {
        _slots ??= ListboxItem.GetStyles( this, TwMerge );
    }

    internal bool GetSelectedState() =>
        Listbox?.Value?.Equals( Value ) is true ||
        Listbox?.Values?.Contains( Value ) is true;

    internal bool GetDisabledState() =>
        Listbox?.DisabledItems?.Contains( Value ) is true;

    private async Task OnClickAsync( MouseEventArgs args )
    {
        if( GetDisabledState() )
        {
            return;
        }

        if( Context?.SelectionMode is not SelectionMode.None )
        {
            await SelectAsync();
        }

        await OnClick.InvokeAsync( args );
    }

    private Task SelectAsync()
    {
        Debug.Assert( Context is not null && Listbox is not null );

        if( Context.SelectionMode is SelectionMode.Single )
        {
            return Listbox.ValueChanged.InvokeAsync( Value );
        }
        else if( Context.SelectionMode is SelectionMode.Multiple )
        {
            var selectedItems = Listbox.Values ?? [];
            if( !selectedItems.Remove( Value ) )
            {
                selectedItems.Add( Value );
            }

            return Listbox.ValuesChanged.InvokeAsync( selectedItems );
        }

        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public virtual void Dispose()
    {
        Context?.Unregister( this );
    }
}