// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace LumexUI;

/// <summary>
/// A component representing the content container of the <see cref="LumexModal"/>.
/// </summary>
[CompositionComponent( typeof( LumexModal ) )]
public partial class LumexModalContent : LumexComponentBase, IAsyncDisposable
{
	private const string JavaScriptFile = "./_content/LumexUI/js/components/modal.js";

	/// <summary>
	/// Gets or sets the content to be rendered inside the modal content container.
	/// </summary>
	[Parameter] public RenderFragment<LumexModal>? ChildContent { get; set; }

	[CascadingParameter] internal ModalContext Context { get; set; } = default!;

	[Inject] private IJSRuntime JSRuntime { get; set; } = default!;

	private LumexModal Modal => Context.Owner;

	private ElementReference _ref;
	private IJSObjectReference? _jsModule;
	private DotNetObjectReference<LumexModalContent>? _dotNetRef;

	private bool _previousOpen;

	/// <inheritdoc />
	protected override void OnInitialized()
	{
		ContextNullException.ThrowIfNull( Context, nameof( LumexModalContent ) );
	}

	/// <inheritdoc />
	protected override async Task OnAfterRenderAsync( bool firstRender )
	{
		if( firstRender )
		{
			_dotNetRef = DotNetObjectReference.Create( this );
			_jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>( "import", JavaScriptFile );
			await _jsModule.InvokeVoidAsync( "modal.initialize", _ref, _dotNetRef );
		}

		if( _jsModule is not null && Modal.Open != _previousOpen )
		{
			_previousOpen = Modal.Open;

			if( Modal.Open )
			{
				await _jsModule.InvokeVoidAsync( "modal.open", _ref );
			}
			else
			{
				await _jsModule.InvokeVoidAsync( "modal.close", _ref );
			}
		}
	}

	/// <summary>
	/// Invoked from JavaScript when the dialog is closed.
	/// </summary>
	/// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
	[JSInvokable]
	public Task OnClose() => Modal.CloseAsync();

	/// <inheritdoc />
	[ExcludeFromCodeCoverage]
	public async ValueTask DisposeAsync()
	{
		try
		{
			if( _jsModule is not null )
			{
				await _jsModule.InvokeVoidAsync( "modal.destroy", _ref );
				await _jsModule.DisposeAsync();
			}

			_dotNetRef?.Dispose();
		}
		catch( JSDisconnectedException )
		{
			// The JS side may routinely be gone already if the reason we're disposing is that
			// the client disconnected. This is not an error.
		}
	}
}
