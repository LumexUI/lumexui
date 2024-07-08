using LumexUI.Common;

namespace LumexUI;

internal class NavbarContext( LumexNavbar owner ) : IComponentContext<LumexNavbar>
{
    public LumexNavbar Owner { get; } = owner;
}
