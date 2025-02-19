// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

namespace LumexUI.Services;

/// <summary>
/// Provides an implementation of <see cref="IPopoverService"/> for managing popover components.
/// </summary>
public class PopoverService : IPopoverService
{
	private readonly Dictionary<string, LumexPopover> _registeredPopovers = [];

	/// <inheritdoc />
	public LumexPopover? LastShown { get; private set; }

	/// <inheritdoc />
	public void SetLastShown( LumexPopover? popover )
	{
		LastShown = popover;
	}

	/// <inheritdoc />
	public void Register( LumexPopover popover )
	{
		if( !string.IsNullOrEmpty( popover.Id ) )
		{
			_registeredPopovers.Add( popover.Id, popover );
		}
	}

	/// <inheritdoc />
	public void Unregister( LumexPopover popover )
	{
		_registeredPopovers.Remove( popover.Id );
	}

	/// <inheritdoc />
	public Task TriggerAsync( string id )
	{
		if( _registeredPopovers.TryGetValue( id, out var popover ) )
		{
			return popover.TriggerAsync();
		}

		return Task.CompletedTask;
	}
}
