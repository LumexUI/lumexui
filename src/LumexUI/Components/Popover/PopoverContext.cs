using LumexUI.Common;

namespace LumexUI;

internal class PopoverContext( LumexPopover owner ) : IComponentContext<LumexPopover>
{
    public LumexPopover Owner { get; } = owner;

    public event Func<ValueTask> OnTrigger = default!;

    public async Task TriggerAsync()
    {
        if( await Owner.ShowAsync() )
        {
            await NotifyStateChangedAsync();
        }
    }

    private ValueTask NotifyStateChangedAsync() => OnTrigger.Invoke();
}
