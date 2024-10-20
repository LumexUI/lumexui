namespace LumexUI.Docs.Common;

internal class Navigation
{
    private readonly List<NavigationCategory> _categories = [];

    public IEnumerable<NavigationCategory> Categories => _categories.AsEnumerable();

    public Navigation Add( NavigationCategory category )
    {
        _categories.Add( category );
        return this;
    }
}

internal class NavigationCategory( string name, string icon )
{
    private readonly List<NavigationItem> _items = [];

    public string Name { get; } = name;
    public string Icon { get; } = icon;
    public IEnumerable<NavigationItem> Items => _items.AsEnumerable();

    public NavigationCategory Add( NavigationItem item )
    {
        _items.Add( item );
        return this;
    }
}

internal class NavigationItem( string name, bool locked = false )
{
    public string Name { get; } = name;
    public bool Locked { get; } = locked;
}
