namespace LumexUI.Services;

public interface IPopoverService
{
    LumexPopover? LastShown { get; }

    void Register( LumexPopover popover );
    void Unregister( LumexPopover popover );
    void SetLastShown( LumexPopover? popover );
}
