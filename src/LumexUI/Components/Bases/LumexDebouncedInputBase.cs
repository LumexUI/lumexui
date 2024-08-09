// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// Represents a base class for input components with debounced value updates.
/// </summary>
/// <typeparam name="TValue">The type of the input value.</typeparam>
public abstract class LumexDebouncedInputBase<TValue> : LumexInputBase<TValue>, IDisposable
{
    /// <summary>
    /// Gets or sets the delay, in milliseconds, for debouncing input events.
    /// </summary>
    [Parameter] public int DebounceDelay { get; set; }

    private readonly Debouncer _debouncer;

    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="LumexDebouncedInputBase{TValue}"/>.
    /// </summary>
    public LumexDebouncedInputBase()
    {
        _debouncer = new Debouncer();
    }

    /// <summary>
    /// Handles the input event asynchronously, applying a debounce delay if provided.
    /// </summary>
    /// <param name="args">The change event arguments.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous value input operation.</returns>
    protected virtual Task OnInputAsync( ChangeEventArgs args )
    {
        if( DebounceDelay > 0 )
        {
            return _debouncer.DebounceAsync( SetCurrentValueAsStringAsync, (string?)args.Value, DebounceDelay );
        }

        return SetCurrentValueAsStringAsync( (string?)args.Value );
    }

    /// <summary>
    /// Handles the change event asynchronously.
    /// </summary>
    /// <param name="args">The change event arguments.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous value change operation.</returns>
    protected virtual Task OnChangeAsync( ChangeEventArgs args )
    {
        return SetCurrentValueAsStringAsync( (string?)args.Value );
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
                _debouncer.Dispose();
            }

            _disposed = true;
        }
    }

    /// <summary>
    /// Represents a debouncer for handling debounced input events.
    /// </summary>
    private sealed class Debouncer : IDisposable
    {
        private bool _disposed;
        private CancellationTokenSource? _cts;

        public async Task DebounceAsync( Func<string?, Task> workItem, string? arg, int milliseconds )
        {
            ArgumentNullException.ThrowIfNull( workItem );

            _cts?.Cancel();
            _cts?.Dispose();

            var cts = _cts = new CancellationTokenSource();
            using var timer = new PeriodicTimer( TimeSpan.FromMilliseconds( milliseconds ) );

            while( await timer.WaitForNextTickAsync( cts.Token ) )
            {
                // Debounce time has passed without further input; trigger the debounced event
                await workItem( arg );
                break;
            }
        }

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose( disposing: true );
            GC.SuppressFinalize( this );
        }

        private void Dispose( bool disposing )
        {
            if( !_disposed )
            {
                if( disposing )
                {
                    _cts?.Cancel();
                    _cts?.Dispose();
                }

                _disposed = true;
            }
        }
    }
}
