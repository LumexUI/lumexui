using LumexUI.Docs.Client.Common;

namespace LumexUI.Docs.Client.Components;

public partial class Sidebar
{
    private Navigation _navigation = default!;

    protected override void OnInitialized()
    {
        _navigation = NavigationStore.GetNavigation();
    }
}
