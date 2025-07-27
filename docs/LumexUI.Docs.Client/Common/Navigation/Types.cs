namespace LumexUI.Docs.Client.Common;

public class Navigation
{
    private readonly List<NavigationCategory> _categories = [];

    public IEnumerable<NavigationCategory> Categories => _categories.AsEnumerable();

    public Navigation Add( NavigationCategory category )
    {
        _categories.Add( category );
        return this;
    }
}

public class NavigationCategory( string name, string? icon = null )
{
    private readonly List<NavigationItem> _items = [];

    public string Name { get; } = name;
    public string? Icon { get; } = icon;
    public IEnumerable<NavigationItem> Items => _items.AsEnumerable();

    public NavigationCategory Add( NavigationItem item )
    {
        _items.Add( item );
        return this;
    }
}

public class NavigationItem( string name, PageStatus? status = null )
{
    public string Name { get; } = name;
    public PageStatus? Status { get; } = status;
}
