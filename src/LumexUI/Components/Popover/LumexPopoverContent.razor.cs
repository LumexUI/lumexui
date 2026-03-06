// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component representing the content of the <see cref="LumexPopover"/>.
/// </summary>
[CompositionComponent( typeof( LumexPopover ) )]
public partial class LumexPopoverContent : LumexComponentBase
{
	/// <summary>
	/// Gets or sets content to be rendered as the popover content.
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	[Parameter] public EventCallback OnTransitionEnd { get; set; }

	[CascadingParameter] internal PopoverContext Context { get; set; } = default!;

	private LumexPopover Popover => Context.Owner;

	/// <inheritdoc />
	protected override void OnInitialized()
	{
		ContextNullException.ThrowIfNull( Context, nameof( LumexPopoverContent ) );
	}

	private async Task HandleTransitionEnd( EventArgs e )
	{
		Console.WriteLine("Transition end: {0}", Popover.State);

		Popover.SetTransitionState();
		await OnTransitionEnd.InvokeAsync();
	}
}