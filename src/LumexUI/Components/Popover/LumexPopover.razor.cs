// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace LumexUI;

public partial class LumexPopover : LumexComponentBase, IAsyncDisposable
{
    private const string JavaScriptFile = "./_content/LumexUI/js/dist/popover.js";

    /// <summary>
    /// Gets or sets content to be rendered inside the popover.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    [Inject] private IJSRuntime JSRuntime { get; set; } = default!;

    internal bool Show { get; set; }
    internal string Id { get; private set; } = Identifier.New();

    private readonly PopoverContext _context;

    private IJSObjectReference _jsModule = default!;

    /// <summary>
    /// Initializes a new instance of the <see cref="LumexPopover"/>.
    /// </summary>
    public LumexPopover()
    {
        _context = new( this );
    }

    /// <inheritdoc />
    protected override async Task OnAfterRenderAsync( bool firstRender )
    {
        if( firstRender )
        {
            _jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>( "import", JavaScriptFile );
        }
    }

    internal ValueTask ToggleAsync()
    {
        if( !Show )
        {
            return ValueTask.CompletedTask;
        }

        return _jsModule.InvokeVoidAsync( "popover.show", Id );
    }

    public async ValueTask DisposeAsync()
    {
        try
        {
            if( _jsModule is not null )
            {
                await _jsModule.DisposeAsync();
            }
        }
        catch( Exception ex ) when( ex is JSDisconnectedException or OperationCanceledException )
        {
            // The JSRuntime side may routinely be gone already if the reason we're disposing is that
            // the client disconnected. This is not an error.
        }
    }
}
