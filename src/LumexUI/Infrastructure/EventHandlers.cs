// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using Microsoft.AspNetCore.Components;

namespace LumexUI.Infrastructure;

/// <summary>
/// Configures event handlers for the components.
/// </summary>
[EventHandler( "onclickoutside", typeof( EventArgs ), enableStopPropagation: true, enablePreventDefault: true )]
[EventHandler( "onanimationend", typeof( AnimationEventArgs ), enableStopPropagation: true, enablePreventDefault: true )]
public static class EventHandlers
{
}

/// <summary>
/// Arguments for the animation events.
/// </summary>
public class AnimationEventArgs : EventArgs
{
	/// <summary>
	/// Gets the name of the animation.
	/// </summary>
	public string AnimationName { get; set; } = string.Empty;
	/// <summary>
	/// Gets the elapsed time of the animation in seconds.
	/// </summary>
	public double ElapsedTime { get; set; }
	/// <summary>
	/// Gets the name of the pseudo-element the animation is applied to.
	/// </summary>
	public string PseudoElement { get; set; } = string.Empty;
}