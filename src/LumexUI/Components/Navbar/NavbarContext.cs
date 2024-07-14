using LumexUI.Common;

namespace LumexUI;

internal class NavbarContext( LumexNavbar owner ) : IComponentContext<LumexNavbar>
{
    public LumexNavbar Owner { get; } = owner;
    public LumexNavbarMenu? Menu { get; private set; }
    public bool IsMenuExpanded { get; private set; }

    public event Action OnMenuToggle = default!;

    public void Register( LumexNavbarMenu menu )
    {
        Menu = menu;
    }

    public void ToggleMenu()
    {
        IsMenuExpanded = !IsMenuExpanded;
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnMenuToggle.Invoke();
}
