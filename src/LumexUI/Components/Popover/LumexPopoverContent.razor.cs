// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Styles;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

public partial class LumexPopoverContent : LumexComponentBase, IDisposable
{
    /// <summary>
    /// Gets or sets content to be rendered as the popover content.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    [CascadingParameter] internal PopoverContext Context { get; set; } = default!;

    private protected override string? RootClass =>
        TwMerge.Merge( Popover.GetContentStyles( this ) );

    private bool _disposed;
    private string _popoverId = default!;

    /// <inheritdoc />
    protected override void OnInitialized()
    {
        ContextNullException.ThrowIfNull( Context, nameof( LumexPopoverContent ) );

        Context.OnToggle += ComputePositionAsync;
    }

    /// <inheritdoc />
    protected override void OnParametersSet()
    {
        _popoverId = $"popover-{Context.Owner.Id}";
    }

    private async Task ComputePositionAsync()
    {
        StateHasChanged();
        await Context.Owner.ToggleAsync();
    }

    public void Dispose()
    {
        Dispose( disposing: true );
        GC.SuppressFinalize( this );
    }

    protected virtual void Dispose( bool disposing )
    {
        if( !_disposed )
        {
            if( disposing )
            {
                Context.OnToggle -= ComputePositionAsync;
            }

            _disposed = true;
        }
    }
}
