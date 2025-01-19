using LumexUI.Motion.Types;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace LumexUI.Motion;

internal sealed class MotionInterop : IAsyncDisposable
{
    private const string JavaScriptPrefix = "motion";

    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

    public MotionInterop( IJSRuntime jsRuntime )
    {
        _moduleTask = new( () => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/LumexUI.Motion/motion.js" ).AsTask() );
    }

    public async Task AnimateEnterAsync( ElementReference @ref, MotionProps props )
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync( $"{JavaScriptPrefix}.animateEnter", @ref, props );
    }

    public async Task AnimateExitAsync( ElementReference @ref, MotionProps props )
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync( $"{JavaScriptPrefix}.animateExit", @ref, props );
    }

    public async Task AnimateLayoutIdAsync( ElementReference @ref, MotionProps? props, string layoutId )
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync( $"{JavaScriptPrefix}.animateLayoutId", @ref, props, layoutId );
    }

    public async ValueTask DisposeAsync()
    {
        if( _moduleTask.IsValueCreated )
        {
            var module = await _moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}
