// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;

namespace LumexUI.Internal;

/// <summary>
/// For internal use only.
/// </summary>
[EditorBrowsable( EditorBrowsableState.Never )]
[SuppressMessage( "Style", "IDE1006:Naming Styles", Justification = "For internal use only." )]
public sealed class PopoverWrapper : LumexComponentBase, IAsyncDisposable
{
	private const string JavaScriptFile = "./_content/LumexUI/js/components/popover.bundle.js";

	/// <summary>
	/// Gets or sets content to be rendered inside the popover wrapper.
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	[CascadingParameter] internal PopoverContext Context { get; set; } = default!;

	[Inject] private IJSRuntime JSRuntime { get; set; } = default!;

	private readonly string? _style = new ElementStyle()
		.Add( "position", "absolute" )
		.Add( "z-index", "10000" )
		.ToString();

	private LumexPopover Popover => Context.Owner;

	private IJSObjectReference _jsModule = default!;
	private bool _jsModuleLoaded;

	/// <inheritdoc />
	protected override void BuildRenderTree( RenderTreeBuilder builder )
	{
		if( _jsModuleLoaded )
		{
			builder.OpenElement( 0, As );
			builder.AddAttribute( 1, "class", Class );
			builder.AddAttribute( 2, "style", _style );
			builder.AddAttribute( 3, "data-popover", Popover.Id );
			builder.AddMultipleAttributes( 4, AdditionalAttributes );
			builder.AddContent( 5, ChildContent );
			builder.CloseElement();
		}
	}

	/// <inheritdoc />
	protected override async Task OnAfterRenderAsync( bool firstRender )
	{
		if( !_jsModuleLoaded )
		{
			_jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>( "import", JavaScriptFile );
			_jsModuleLoaded = true;
			StateHasChanged(); // Trigger a second render for initialization
			return;
		}

		await _jsModule.InvokeVoidAsync( "popover.initialize", Context.Owner.Id, Context.Owner.Options );
	}

	/// <inheritdoc />
	[ExcludeFromCodeCoverage]
	async ValueTask IAsyncDisposable.DisposeAsync()
	{
		try
		{
			if( _jsModule is not null )
			{
				await _jsModule.InvokeVoidAsync( "popover.destroy" );
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
