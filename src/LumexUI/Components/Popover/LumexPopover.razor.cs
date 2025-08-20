// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Extensions;
using LumexUI.Styles;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component representing a popover that displays additional content within a floating container.
/// </summary>
public partial class LumexPopover : LumexComponentBase, ISlotComponent<PopoverSlots>
{
	/// <summary>
	/// Gets or sets content to be rendered inside the popover.
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	/// <summary>
	/// Gets or sets the unique identifier for the popover.
	/// </summary>
	[Parameter] public string Id { get; set; } = Identifier.New();

	/// <summary>
	/// Gets or sets a color of the popover.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="ThemeColor.Default"/>
	/// </remarks>
	[Parameter] public ThemeColor Color { get; set; } = ThemeColor.Default;

	/// <summary>
	/// Gets or sets a size of the popover content text.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Size.Medium"/>
	/// </remarks>
	[Parameter] public Size Size { get; set; } = Size.Medium;

	/// <summary>
	/// Gets or sets a border radius of the popover.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Radius.Medium"/>
	/// </remarks>
	[Parameter] public Radius Radius { get; set; } = Radius.Medium;

	/// <summary>
	/// Gets or sets a shadow of the popover.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Shadow.Medium"/>
	/// </remarks>
	[Parameter] public Shadow Shadow { get; set; } = Shadow.Medium;

	/// <summary>
	/// Gets or sets a placement of the popover relative to a reference.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="PopoverPlacement.Top"/>
	/// </remarks>
	[Parameter] public PopoverPlacement Placement { get; set; }

	/// <summary>
	/// Gets or sets the offset distance between the popover and the reference, in pixels.
	/// </summary>
	/// <remarks>
	/// The default value is 8
	/// </remarks>
	[Parameter] public int Offset { get; set; } = 8;

	/// <summary>
	/// Gets or sets a value indicating whether the popover should display an arrow pointing to the reference.
	/// </summary>
	[Parameter] public bool ShowArrow { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the popover should match the width of the reference element.
	/// </summary>
	[Parameter] public bool MatchRefWidth { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the popover is currently open.
	/// </summary>
	[Parameter] public bool Open { get; set; }

	/// <summary>
	/// Gets or sets a callback that is invoked when the open state of the popover changes.
	/// </summary>
	[Parameter] public EventCallback<bool> OpenChanged { get; set; }

	/// <summary>
	/// Gets or sets the CSS class names for the popover slots.
	/// </summary>
	[Parameter] public PopoverSlots? Classes { get; set; }

	internal bool IsTooltip { get; private set; }
	internal PopoverOptions Options { get; private set; }
	internal Dictionary<string, ComponentSlot> Slots { get; private set; } = [];

	private readonly PopoverContext _context;

	/// <summary>
	/// Initializes a new instance of the <see cref="LumexPopover"/>.
	/// </summary>
	public LumexPopover()
	{
		_context = new PopoverContext( this );
	}

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		if( string.IsNullOrEmpty( Id ) )
		{
			throw new InvalidOperationException( $"{GetType()} requires a value for the {nameof( Id )} parameter." );
		}

		if( AdditionalAttributes?.TryGetValue( "role", out var value ) ?? false )
		{
			IsTooltip = value is "tooltip";
		}

		Options = new PopoverOptions( this );

		var popover = Popover.Style( TwMerge );
		Slots = popover( new()
		{
			[nameof( Size )] = Size.ToString(),
			[nameof( Color )] = Color.ToString(),
			[nameof( Radius )] = Radius.ToString(),
			[nameof( Shadow )] = Shadow.ToString(),
		} );
	}

	internal async Task TriggerAsync()
	{
		Open = !Open;

		if( Open )
		{
			await OpenAsync();
		}
		else
		{
			await CloseAsync();
		}

		StateHasChanged();
	}

	internal Task OpenAsync()
	{
		Open = true;
		return OpenChanged.InvokeAsync( true );
	}

	internal Task CloseAsync()
	{
		Open = false;
		return OpenChanged.InvokeAsync( false );
	}

	/// <summary>
	/// Represents the configuration options for a <see cref="LumexPopover"/> component.
	/// </summary>
	/// <param name="popover">The <see cref="LumexPopover"/> instance associated with these options.</param>
	internal readonly struct PopoverOptions( LumexPopover popover )
	{
		public int Offset { get; } = popover.Offset;
		public bool ShowArrow { get; } = popover.ShowArrow;
		public bool MatchRefWidth { get; } = popover.MatchRefWidth;
		public string Placement { get; } = popover.Placement.ToDescription();
	}
}
