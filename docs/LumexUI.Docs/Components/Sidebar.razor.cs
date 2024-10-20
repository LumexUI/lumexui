using LumexUI.Docs.Common;

namespace LumexUI.Docs.Components;

public partial class Sidebar
{
    private Navigation _navigation = default!;

    protected override void OnInitialized()
    {
        _navigation = NavigationStore.GetNavigation();
    }
}
