// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

namespace LumexUI.Services;

/// <summary>
/// Defines a service for managing <see cref="LumexPopover"/> instances.
/// </summary>
public interface IPopoverService
{
	/// <summary>
	/// Gets the last shown popover.
	/// </summary>
	LumexPopover? LastShown { get; }

	/// <summary>
	/// Registers a popover with the service.
	/// </summary>
	/// <param name="popover">The popover to register.</param>
	void Register( LumexPopover popover );

	/// <summary>
	/// Unregisters a popover from the service.
	/// </summary>
	/// <param name="popover">The popover to unregister.</param>
	void Unregister( LumexPopover popover );

	/// <summary>
	/// Sets the last shown popover.
	/// </summary>
	/// <param name="popover">The popover to set as the last shown instance.</param>
	void SetLastShown( LumexPopover? popover );
}
