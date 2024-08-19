// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.ComponentModel;

namespace LumexUI.Common;

/// <summary>
/// Specifies the placement options for a popover component.
/// </summary>
public enum PopoverPlacement
{
    /// <summary>
    /// Places the popover above the reference.
    /// </summary>
    [Description( "top" )]
    Top,

    /// <summary>
    /// Places the popover above the reference, aligned to the start (left) of the reference.
    /// </summary>
    [Description( "top-start" )]
    TopStart,

    /// <summary>
    /// Places the popover above the reference, aligned to the end (right) of the reference.
    /// </summary>
    [Description( "top-end" )]
    TopEnd,

    /// <summary>
    /// Places the popover to the right of the reference.
    /// </summary>
    [Description( "right" )]
    Right,

    /// <summary>
    /// Places the popover to the right of the reference, aligned to the start (top) of the reference.
    /// </summary>
    [Description( "right-start" )]
    RightStart,

    /// <summary>
    /// Places the popover to the right of the reference, aligned to the end (bottom) of the reference.
    /// </summary>
    [Description( "right-end" )]
    RightEnd,

    /// <summary>
    /// Places the popover below the reference.
    /// </summary>
    [Description( "bottom" )]
    Bottom,

    /// <summary>
    /// Places the popover below the reference, aligned to the start (left) of the reference.
    /// </summary>
    [Description( "bottom-start" )]
    BottomStart,

    /// <summary>
    /// Places the popover below the reference, aligned to the end (right) of the reference.
    /// </summary>
    [Description( "bottom-end" )]
    BottomEnd,

    /// <summary>
    /// Places the popover to the left of the reference.
    /// </summary>
    [Description( "left" )]
    Left,

    /// <summary>
    /// Places the popover to the left of the reference, aligned to the start (top) of the reference.
    /// </summary>
    [Description( "left-start" )]
    LeftStart,

    /// <summary>
    /// Places the popover to the left of the reference, aligned to the end (bottom) of reference.
    /// </summary>
    [Description( "left-end" )]
    LeftEnd
}
