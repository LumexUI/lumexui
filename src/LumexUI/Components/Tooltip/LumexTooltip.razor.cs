// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Utilities;

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
	[Parameter] public RenderFragment? ChildContent { get; set; }

	/// <summary>
	/// Gets or sets the content to display within the tooltip.
	/// </summary>
	[Parameter] public object? Content { get; set; }

	/// <summary>
	/// Gets or sets the CSS class names for the tooltip slots.
	/// </summary>
	[Parameter] public TooltipSlots? Classes { get; set; }

	private readonly string _popoverId = Identifier.New();

	private bool _isOpen;

	private void OnPointerEnterAsync() => _isOpen = true;
	private void OnPointerLeaveAsync() => _isOpen = false;
}