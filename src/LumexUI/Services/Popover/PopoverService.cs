namespace LumexUI.Services;

public class PopoverService : IPopoverService
{
    private readonly HashSet<LumexPopover> _registeredPopovers = [];

    public void Register( LumexPopover popover )
    {
        _registeredPopovers.Add( popover );
    }

    public void Unregister( LumexPopover popover )
    {
        _registeredPopovers.Remove( popover );
    }

    public void NotifyOpened( LumexPopover popover )
    {
        foreach( var regPopover in _registeredPopovers )
        {
            if( regPopover != popover )
            {
                regPopover.Hide();
            }
        }
    }
}
