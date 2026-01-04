// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// Represents a base class for input components with debounced value updates.
/// </summary>
/// <typeparam name="TValue">The type of the input value.</typeparam>
public abstract class LumexDebouncedInputBase<TValue> : LumexInputFieldBase<TValue>
{
	/// <summary>
	/// Gets or sets the delay, in milliseconds, for debouncing input events.
	/// </summary>
	[Parameter] public int DebounceDelay { get; set; }

	private readonly Debouncer _debouncer;

	/// <summary>
	/// Initializes a new instance of the <see cref="LumexDebouncedInputBase{TValue}"/>.
	/// </summary>
	public LumexDebouncedInputBase()
	{
		_debouncer = new Debouncer();
	}

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		if( DebounceDelay > 0 && Behavior is not InputBehavior.OnInput )
		{
			throw new InvalidOperationException(
				$"{GetType()} requires '{nameof( InputBehavior.OnInput )}' behavior" +
				$" to be used when '{nameof( DebounceDelay )}' is not zero." );
		}
	}

	/// <inheritdoc />
	protected override Task OnInputCoreAsync( ChangeEventArgs args )
	{
		if( DebounceDelay > 0 )
		{
			return _debouncer.DebounceAsync( SetCurrentValueAsStringAsync, (string?)args.Value, DebounceDelay );
		}

		return SetCurrentValueAsStringAsync( (string?)args.Value );
	}

	/// <inheritdoc />
	protected override Task OnChangeCoreAsync( ChangeEventArgs args )
	{
		return SetCurrentValueAsStringAsync( (string?)args.Value );
	}

	/// <inheritdoc />
	public override async ValueTask DisposeAsync()
	{
		_debouncer.Dispose();
		await base.DisposeAsync();
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
			ObjectDisposedException.ThrowIf( _disposed, this );
			ArgumentNullException.ThrowIfNull( workItem );

			// Cancel/dispose any pending debounce.
			_cts?.Cancel();
			_cts?.Dispose();

			var cts = _cts = new CancellationTokenSource();

			if( milliseconds <= 0 )
			{
				await workItem( arg );
				return;
			}

			try
			{
				await Task.Delay( milliseconds, cts.Token );

				// Debounce time has passed without further input; trigger the debounced event.
				await workItem( arg );
			}
			catch( OperationCanceledException ) when( cts.IsCancellationRequested )
			{
				// Expected: new input or disposal cancelled the pending debounce.
			}
		}

		/// <inheritdoc />
		public void Dispose()
		{
			if( _disposed )
			{
				return;
			}

			_disposed = true;

			_cts?.Cancel();
			_cts?.Dispose();
		}
	}
}
