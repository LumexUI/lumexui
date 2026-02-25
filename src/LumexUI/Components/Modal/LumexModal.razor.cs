// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component representing a modal dialog overlay.
/// </summary>
public partial class LumexModal : LumexComponentBase, ISlotComponent<ModalSlots>
{
	/// <summary>
	/// Gets or sets the content to be rendered inside the modal.
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	/// <summary>
	/// Gets or sets the size of the modal.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="ModalSize.Medium"/>
	/// </remarks>
	[Parameter] public ModalSize Size { get; set; } = ModalSize.Medium;

	/// <summary>
	/// Gets or sets the border radius of the modal.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Radius.Large"/>
	/// </remarks>
	[Parameter] public Radius Radius { get; set; } = Radius.Large;

	/// <summary>
	/// Gets or sets the shadow of the modal.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Shadow.Large"/>
	/// </remarks>
	[Parameter] public Shadow Shadow { get; set; } = Shadow.Large;

	/// <summary>
	/// Gets or sets the backdrop style of the modal.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Backdrop.Opaque"/>
	/// </remarks>
	[Parameter] public Backdrop Backdrop { get; set; } = Backdrop.Opaque;

	/// <summary>
	/// Gets or sets the scroll behavior of the modal.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="ScrollBehavior.Normal"/>
	/// </remarks>
	[Parameter] public ScrollBehavior ScrollBehavior { get; set; } = ScrollBehavior.Normal;

	/// <summary>
	/// Gets or sets the placement of the modal within the viewport.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="ModalPlacement.Auto"/>
	/// </remarks>
	[Parameter] public ModalPlacement Placement { get; set; } = ModalPlacement.Auto;

	/// <summary>
	/// Gets or sets a value indicating whether the modal is currently open.
	/// </summary>
	[Parameter] public bool Open { get; set; }

	/// <summary>
	/// Gets or sets a callback that is invoked when the <see cref="Open"/> state changes.
	/// </summary>
	[Parameter] public EventCallback<bool> OpenChanged { get; set; }

	/// <summary>
	/// Gets or sets a callback that is invoked when the modal is closed.
	/// </summary>
	[Parameter] public EventCallback OnClose { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the close button is shown.
	/// </summary>
	[Parameter] public bool ShowCloseButton { get; set; } = true;

	/// <summary>
	/// Gets or sets the CSS class names for the modal slots.
	/// </summary>
	[Parameter] public ModalSlots? Classes { get; set; }

	internal string Id { get; } = $"dialog-{Interlocked.Increment( ref _id )}";
	internal Dictionary<string, ComponentSlot> Slots { get; private set; } = [];

	private static long _id;

	private readonly ModalContext _context;

	/// <summary>
	/// Initializes a new instance of the <see cref="LumexModal"/>.
	/// </summary>
	public LumexModal()
	{
		_context = new ModalContext( this );
	}

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		var modal = Styles.Modal.Style( TwMerge );
		Slots = modal( new()
		{
			[nameof( Size )] = Size.ToString(),
			[nameof( Radius )] = Radius.ToString(),
			[nameof( Shadow )] = Shadow.ToString(),
			[nameof( Backdrop )] = Backdrop.ToString(),
			[nameof( Placement )] = Placement.ToString(),
			[nameof( ScrollBehavior )] = ScrollBehavior.ToString(),
		} );
	}
	
	/// <summary>
	/// Opens the modal dialog.
	/// </summary>
	/// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
	public async Task OpenAsync()
	{
		Open = true;
		await OpenChanged.InvokeAsync( true );

		// Ensure the re-render propagates to LumexModalContent
		StateHasChanged();
	}

	/// <summary>
	/// Closes the modal dialog.
	/// </summary>
	/// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
	public async Task CloseAsync()
	{
		Open = false;
		await OpenChanged.InvokeAsync( false );
		await OnClose.InvokeAsync();
	}

	[ExcludeFromCodeCoverage]
	internal string? GetStyles( string slot, string? @class = null )
	{
		if( !Slots.TryGetValue( slot, out var styles ) )
		{
			throw new NotImplementedException();
		}

		return slot switch
		{
			nameof( ModalSlots.Base ) => styles( Classes?.Base, Class ),
			nameof( ModalSlots.Trigger ) => styles( Classes?.Trigger, @class ),
			nameof( ModalSlots.Header ) => styles( Classes?.Header, @class ),
			nameof( ModalSlots.Body ) => styles( Classes?.Body, @class ),
			nameof( ModalSlots.Footer ) => styles( Classes?.Footer, @class ),
			nameof( ModalSlots.CloseButton ) => styles( Classes?.CloseButton, @class ),
			_ => throw new NotImplementedException()
		};
	}
}
