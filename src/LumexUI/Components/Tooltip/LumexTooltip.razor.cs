// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component that represents a tooltip for displaying additional information.
/// </summary>
public partial class LumexTooltip : LumexComponentBase, ISlotComponent<TooltipSlots>
{
	/// <summary>
	/// Gets or sets the content around which the tooltip is rendered.
	/// </summary>
	[Parameter, EditorRequired] public RenderFragment ChildContent { get; set; } = default!;

	/// <summary>
	/// Gets or sets the content to display within the tooltip.
	/// </summary>
	[Parameter] public object? Content { get; set; }

	/// <summary>
	/// Gets or sets a color of the tooltip.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="ThemeColor.Default"/>
	/// </remarks>
	[Parameter] public ThemeColor Color { get; set; } = ThemeColor.Default;

	/// <summary>
	/// Gets or sets a size of the tooltip content text.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Size.Medium"/>
	/// </remarks>
	[Parameter] public Size Size { get; set; } = Size.Medium;

	/// <summary>
	/// Gets or sets a border radius of the tooltip.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Radius.Medium"/>
	/// </remarks>
	[Parameter] public Radius Radius { get; set; } = Radius.Medium;

	/// <summary>
	/// Gets or sets a shadow of the tooltip.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Shadow.Small"/>
	/// </remarks>
	[Parameter] public Shadow Shadow { get; set; } = Shadow.Small;

	/// <summary>
	/// Gets or sets a placement of the tooltip relative to a reference.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="TooltipPlacement.Top"/>
	/// </remarks>
	[Parameter] public TooltipPlacement Placement { get; set; }

	/// <summary>
	/// Gets or sets the offset distance between the tooltip and the reference, in pixels.
	/// </summary>
	/// <remarks>
	/// The default value is 8
	/// </remarks>
	[Parameter] public int Offset { get; set; } = 8;

	/// <summary>
	/// Gets or sets a value indicating whether the tooltip should display an arrow pointing to the reference.
	/// </summary>
	[Parameter] public bool ShowArrow { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the tooltip is currently open.
	/// </summary>
	[Parameter] public bool Open { get; set; }

	/// <summary>
	/// Gets or sets a callback that is invoked when the open state of the tooltip changes.
	/// </summary>
	[Parameter] public EventCallback<bool> OpenChanged { get; set; }

	/// <summary>
	/// Gets or sets the CSS class names for the tooltip slots.
	/// </summary>
	[Parameter] public TooltipSlots? Classes { get; set; }

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		ArgumentNullException.ThrowIfNull( ChildContent );
	}

	private Task OnMouseEnterAsync() => OpenAsync();
	private Task OnMouseLeaveAsync() => CloseAsync();
	private Task OnFocusInAsync() => OpenAsync();
	private Task OnFocusOutAsync() => CloseAsync();
	private Task OnClickAsync() => CloseAsync();

	private Task OpenAsync()
	{
		return SetOpenAsync( true );
	}

	private Task CloseAsync()
	{
		return SetOpenAsync( false );
	}

	private Task SetOpenAsync( bool value )
	{
		Open = value;
		return OpenChanged.InvokeAsync( value );
	}

	[ExcludeFromCodeCoverage]
	private PopoverPlacement GetPlacement()
	{
		return Placement switch
		{
			TooltipPlacement.Top => PopoverPlacement.Top,
			TooltipPlacement.TopStart => PopoverPlacement.TopStart,
			TooltipPlacement.TopEnd => PopoverPlacement.TopEnd,
			TooltipPlacement.Right => PopoverPlacement.Right,
			TooltipPlacement.RightStart => PopoverPlacement.RightStart,
			TooltipPlacement.RightEnd => PopoverPlacement.RightEnd,
			TooltipPlacement.Bottom => PopoverPlacement.Bottom,
			TooltipPlacement.BottomStart => PopoverPlacement.BottomStart,
			TooltipPlacement.BottomEnd => PopoverPlacement.BottomEnd,
			TooltipPlacement.Left => PopoverPlacement.Left,
			TooltipPlacement.LeftStart => PopoverPlacement.LeftStart,
			TooltipPlacement.LeftEnd => PopoverPlacement.LeftEnd,
			_ => throw new NotImplementedException()
		};
	}
}