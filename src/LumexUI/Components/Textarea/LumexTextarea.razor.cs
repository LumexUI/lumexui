// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace LumexUI;

/// <summary>
/// A component that represents a multi-line input field for entering <see cref="string"/> values.
/// </summary>
public partial class LumexTextarea : LumexDebouncedInputBase<string?>
{
	private const string JavaScriptFile = "./_content/LumexUI/js/components/textarea.js";

	/// <summary>
	/// Gets or sets the minimum number of rows the textarea will display.
	/// </summary>
	/// <remarks>
	/// The default value is <c>3</c>.
	/// </remarks>
	[Parameter] public int MinRows { get; set; } = 3;

	/// <summary>
	/// Gets or sets the maximum number of rows the textarea will grow to before scrolling.
	/// </summary>
	/// <remarks>
	/// The default value is <c>8</c>.
	/// </remarks>
	[Parameter] public int MaxRows { get; set; } = 8;

	/// <summary>
	/// Gets or sets a value indicating whether automatic height adjustment is disabled.
	/// When <see langword="true"/>, the textarea height is locked to <see cref="MinRows"/>.
	/// </summary>
	/// <remarks>
	/// The default value is <see langword="false"/>.
	/// </remarks>
	[Parameter] public bool DisableAutosize { get; set; }

	private IJSObjectReference? _textareaJsModule;

	private int _previousMinRows;
	private int _previousMaxRows;
	private bool _previousDisableAutosize;

	/// <inheritdoc />
	protected override bool TryParseValueFromString( string? value, out string? result )
	{
		result = value;
		return true;
	}

	/// <inheritdoc />
	protected override async Task OnAfterRenderAsync( bool firstRender )
	{
		await base.OnAfterRenderAsync( firstRender );

		if( firstRender )
		{
			_textareaJsModule = await JSRuntime.InvokeAsync<IJSObjectReference>( "import", JavaScriptFile );
			await _textareaJsModule.InvokeVoidAsync( "textarea.initialize", ElementReference, GetOptions() );

			_previousMinRows = MinRows;
			_previousMaxRows = MaxRows;
			_previousDisableAutosize = DisableAutosize;
		}
		else if( _textareaJsModule is not null && OptionsChanged() )
		{
			await _textareaJsModule.InvokeVoidAsync( "textarea.update", ElementReference, GetOptions() );

			_previousMinRows = MinRows;
			_previousMaxRows = MaxRows;
			_previousDisableAutosize = DisableAutosize;
		}
	}

	private bool OptionsChanged() =>
		_previousMinRows != MinRows ||
		_previousMaxRows != MaxRows ||
		_previousDisableAutosize != DisableAutosize;

	private object GetOptions() => new
	{
		minRows = MinRows,
		maxRows = MaxRows,
		disableAutosize = DisableAutosize,
	};

	/// <inheritdoc />
	public override async ValueTask DisposeAsync()
	{
		try
		{
			if( _textareaJsModule is not null )
			{
				await _textareaJsModule.InvokeVoidAsync( "textarea.destroy", ElementReference );
				await _textareaJsModule.DisposeAsync();
			}
		}
		catch( Exception ex ) when( ex is JSDisconnectedException or OperationCanceledException )
		{
			// Connection already gone — nothing to clean up on the JS side.
		}

		await base.DisposeAsync();
	}
}
