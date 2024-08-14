using LumexUI.Common;

namespace LumexUI;

internal class PopoverContext( LumexPopover owner ) : IComponentContext<LumexPopover>
{
    public LumexPopover Owner { get; } = owner;

    public event Func<ValueTask> OnShow = default!;

    public async Task ToggleAsync()
    {
        if( Owner.IsShown )
        {
            Owner.Hide();
        }
        else
        {
            Owner.Show();
            await NotifyStateChangedAsync();
        }
    }

    private ValueTask NotifyStateChangedAsync() => OnShow.Invoke();
}
