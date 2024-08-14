// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Services;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

public partial class LumexPopover : LumexComponentBase, IDisposable
{
    /// <summary>
    /// Gets or sets content to be rendered inside the popover.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    [Inject] private IPopoverService PopoverService { get; set; } = default!;

    internal bool IsShown { get; set; }
    internal string Id { get; private set; } = Identifier.New();

    private readonly PopoverContext _context;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="LumexPopover"/>.
    /// </summary>
    public LumexPopover()
    {
        _context = new( this );
    }

    public void Show()
    {
        PopoverService.NotifyOpened( this );
        IsShown = true;
    }

    public void Hide()
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
}
