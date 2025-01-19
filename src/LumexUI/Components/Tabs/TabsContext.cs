// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;

namespace LumexUI;

internal class TabsContext( LumexTabs owner ) : IComponentContext<LumexTabs>
{
    private bool _collectingTabs;
    private LumexTab _activeTab = default!;

    public LumexTabs Owner { get; } = owner;
    public List<LumexTab> Tabs { get; } = [];

    public event Action? OnTabsChanged;

    public void Register( LumexTab tab )
    {
        if( _collectingTabs )
        {
            _activeTab ??= tab;
            Tabs.Add( tab );
        }
    }

    public void Unregister( LumexTab tab )
    {
        _ = Tabs.Remove( tab );
    }

    public void StartCollectingTabs()
    {
        Tabs.Clear();
        _collectingTabs = true;
    }

    public void StopCollectingTabs()
    {
        _collectingTabs = false;
    }

    public LumexTab GetActiveTab()
    {
        return _activeTab;
    }

    public void SetActiveTab( LumexTab tab )
    {
        _activeTab = tab;
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnTabsChanged?.Invoke();
}
