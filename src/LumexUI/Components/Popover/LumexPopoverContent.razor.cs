// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Styles;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace LumexUI;

/// <summary>
/// A component representing the content of the <see cref="LumexPopover"/>.
/// </summary>
[CompositionComponent( typeof( LumexPopover ) )]
public partial class LumexPopoverContent : LumexComponentBase, IAsyncDisposable
{
    private const string JavaScriptFile = "./_content/LumexUI/js/components/popover.bundle.js";

    /// <summary>
    /// Gets or sets content to be rendered as the popover content.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    [CascadingParameter] internal PopoverContext Context { get; set; } = default!;

    [Inject] private IJSRuntime JSRuntime { get; set; } = default!;

    private protected override string? RootClass =>
        TwMerge.Merge( Popover.GetContentStyles( this ) );

    private string? InnerWrapperClass =>
        TwMerge.Merge( Popover.GetInnerWrapperStyles() );

    private string? ArrowClass =>
        TwMerge.Merge( Popover.GetArrowStyles( this ) );

    private IJSObjectReference _jsModule = default!;

    /// <inheritdoc />
    protected override void OnInitialized()
    {
        ContextNullException.ThrowIfNull( Context, nameof( LumexPopoverContent ) );

        Context.OnTrigger += ShowAsync;
    }

    /// <inheritdoc />
    protected override async Task OnAfterRenderAsync( bool firstRender )
    {
        if( firstRender )
        {
            _jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>( "import", JavaScriptFile );
        }
    }

    private ValueTask ShowAsync()
    {
        // We need to render a popover first.
        StateHasChanged();

        // Then we initialize the popover on the JS side by:
        //  1. Adding a 'clickoutside' event handler
        //  2. Applying a proper positioning
        return _jsModule.InvokeVoidAsync( "popover.initialize", Context.Owner.Id, Context.Owner.Options );
    }

    private async ValueTask ClickOutsideAsync()
    {
        await Context.Owner.HideAsync();
        await _jsModule.InvokeVoidAsync( "popover.destroy" );
    }

    /// <inheritdoc />
    [ExcludeFromCodeCoverage]
    public async ValueTask DisposeAsync()
    {
        try
        {
            if( _jsModule is not null )
            {
                await _jsModule.InvokeVoidAsync( "popover.destroy" );
                await _jsModule.DisposeAsync();
            }

            Context.OnTrigger -= ShowAsync;
        }
        catch( Exception ex ) when( ex is JSDisconnectedException or OperationCanceledException )
        {
            // The JSRuntime side may routinely be gone already if the reason we're disposing is that
            // the client disconnected. This is not an error.
        }
    }
}
