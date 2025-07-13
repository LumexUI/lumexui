// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Motion.Types;

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

	[CascadingParameter] internal PopoverContext Context { get; set; } = default!;

	private LumexPopover Popover => Context.Owner;

	private readonly MotionProps _motionProps; 

	/// <summary>
	/// 
	/// </summary>
	public LumexPopoverContent()
	{
		_motionProps = new MotionProps
		{
			Enter = new
			{
				Opacity = new float[] { 0, 1 } // Animate opacity from 0 to 1.
			}
		};
	}

	/// <inheritdoc />
	protected override void OnInitialized()
	{
		ContextNullException.ThrowIfNull( Context, nameof( LumexPopoverContent ) );
	}
}
