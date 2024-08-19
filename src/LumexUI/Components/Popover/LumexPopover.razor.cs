// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Services;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component representing a popover, providing a floating container 
/// that displays additional content or information.
/// </summary>
public partial class LumexPopover : LumexComponentBase, ISlotComponent<PopoverSlots>, IDisposable
{
    /// <summary>
    /// Gets or sets content to be rendered inside the popover.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets a color of the popover.
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="ThemeColor.Default"/>
    /// </remarks>
    [Parameter] public ThemeColor Color { get; set; } = ThemeColor.Default;

    /// <summary>
    /// Gets or sets a size of the popover content text.
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="Size.Medium"/>
    /// </remarks>
    [Parameter] public Size Size { get; set; } = Size.Medium;

    /// <summary>
    /// Gets or sets a border radius of the popover.
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="Radius.Large"/>
    /// </remarks>
    [Parameter] public Radius Radius { get; set; } = Radius.Large;

    /// <summary>
    /// Gets or sets a shadow of the popover.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="Shadow.Small"/>
    /// </remarks>
    [Parameter] public Shadow Shadow { get; set; } = Shadow.Small;

    /// <summary>
    /// Gets or sets a placement of the popover relative to a reference.
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="PopoverPlacement.Top"/>
    /// </remarks>
    [Parameter] public PopoverPlacement Placement { get; set; }

    /// <summary>
    /// Gets or sets the offset distance between the popover and the reference, in pixels.
    /// </summary>
    /// <remarks>
    /// The default value is 8
    /// </remarks>
    [Parameter] public int Offset { get; set; } = 8;

    /// <summary>
    /// Gets or sets a value indicating whether the popover should display an arrow pointing to the reference.
    /// </summary>
    [Parameter] public bool ShowArrow { get; set; }

    /// <summary>
    /// Gets or sets the CSS class names for the popover slots.
    /// </summary>
    [Parameter] public PopoverSlots? Classes { get; set; }

    [Inject] private IPopoverService PopoverService { get; set; } = default!;

    internal string Id { get; private set; } = Identifier.New();
    internal bool IsShown { get; private set; }
    internal PopoverOptions Options { get; private set; }

    private readonly PopoverContext _context;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="LumexPopover"/>.
    /// </summary>
    public LumexPopover()
    {
        _context = new PopoverContext( this );
    }

    internal bool Show()
    {
        if( PopoverService.LastShown == this )
        {
            PopoverService.SetLastShown( null );
            return false;
        }

        IsShown = true;
        PopoverService.SetLastShown( this );
        return true;
    }

    internal void Hide()
    {
        IsShown = false;
        StateHasChanged();
    }

    /// <inheritdoc />
    protected override void OnInitialized()
    {
        PopoverService.Register( this );
    }

    /// <inheritdoc />
    protected override void OnParametersSet()
    {
        Options = new PopoverOptions( this );
    }

    /// <inheritdoc />
    public void Dispose()
    {
        Dispose( disposing: true );
        GC.SuppressFinalize( this );
    }

    /// <inheritdoc cref="IDisposable.Dispose" />
    protected virtual void Dispose( bool disposing )
    {
        if( !_disposed )
        {
            if( disposing )
            {
                PopoverService.Unregister( this );
            }

            _disposed = true;
        }
    }

    /// <summary>
    /// Represents the configuration options for a <see cref="LumexPopover"/> component.
    /// </summary>
    /// <param name="popover">The <see cref="LumexPopover"/> instance associated with these options.</param>
    internal readonly struct PopoverOptions( LumexPopover popover )
    {
        public int Offset { get; } = popover.Offset;
        public bool ShowArrow { get; } = popover.ShowArrow;
        public string Placement { get; } = popover.Placement.ToDescription();
    }
}
