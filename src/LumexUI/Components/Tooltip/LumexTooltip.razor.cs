// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component that represents a tooltip for displaying additional information.
/// </summary>
public partial class LumexTooltip : LumexComponentBase, ISlotComponent<TooltipSlots>
{
	/// <summary>
	/// Gets or sets the CSS class names for the tooltip slots.
	/// </summary>
	[Parameter] public TooltipSlots? Classes { get; set; }
}