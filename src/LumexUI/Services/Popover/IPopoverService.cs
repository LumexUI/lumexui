namespace LumexUI.Services;

public interface IPopoverService
{
    void Register( LumexPopover popover );
    void Unregister( LumexPopover popover );
    void NotifyOpened( LumexPopover popover );
}
