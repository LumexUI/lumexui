namespace LumexUI.Services;

public class PopoverService : IPopoverService
{
    private readonly HashSet<LumexPopover> _registeredPopovers = [];

    public LumexPopover? LastShown { get; private set; }

    public void SetLastShown( LumexPopover? popover )
    {
        LastShown = popover;
    }

    public void Register( LumexPopover popover )
    {
        _registeredPopovers.Add( popover );
    }

    public void Unregister( LumexPopover popover )
    {
        _registeredPopovers.Remove( popover );
    }
}
