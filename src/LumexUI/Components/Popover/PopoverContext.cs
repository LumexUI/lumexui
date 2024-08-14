using LumexUI.Common;

namespace LumexUI;

internal class PopoverContext( LumexPopover owner ) : IComponentContext<LumexPopover>
{
    public LumexPopover Owner { get; } = owner;

    public event Func<Task> OnToggle = default!;

    public void Toggle()
    {
        Owner.Show = !Owner.Show;
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnToggle.Invoke();
}
