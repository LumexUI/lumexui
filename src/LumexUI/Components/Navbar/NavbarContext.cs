using LumexUI.Common;

namespace LumexUI;

internal class NavbarContext( LumexNavbar owner ) : IComponentContext<LumexNavbar>
{
    public LumexNavbar Owner { get; } = owner;
    public LumexNavbarMenu? Menu { get; private set; }

    public void RegisterMenu( LumexNavbarMenu menu )
    {
        Menu = menu;
    }
}
