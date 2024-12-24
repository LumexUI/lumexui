using LumexUI.Common;

namespace LumexUI;

internal class SelectContext<TValue>( LumexSelect<TValue> owner ) : IComponentContext<LumexSelect<TValue>>
{
    private bool _collectingItems;

    public LumexSelect<TValue> Owner { get; } = owner;
    public List<LumexSelectItem<TValue>> Items { get; } = [];
    public HashSet<LumexSelectItem<TValue>> SelectedItems { get; } = [];
    public bool IsMultiSelect { get; set; }

    // Just for a component context API consistency.
    // Chore: make it prettier, more robust.
    public void Register( LumexSelectItem<TValue> item )
    {
        if( _collectingItems )
        {
            Items.Add( item );
        }
    }

    // Just for a component context API consistency.
    // Chore: make it prettier, more robust.
    public void Unregister( LumexSelectItem<TValue> item )
    {
        Items.Remove( item );
    }

    public void StartCollectingItems()
    {
        Items.Clear();
        _collectingItems = true;
    }

    public void FinishCollectingItems()
    {
        _collectingItems = false;
    }

    public void UpdateSelectedItem( TValue? currentValue )
    {
        if( currentValue is null )
        {
            return;
        }

        var item = Items.Find( i => EqualityComparer<TValue>.Default.Equals( currentValue, i.Value ) );
        if( item is not null )
        {
            SelectedItems.Clear();
            SelectedItems.Add( item );
        }
    }

    public void UpdateSelectedItems( ICollection<TValue>? currentValues )
    {
        if( currentValues is null )
        {
            return;
        }

        var valueSet = new HashSet<TValue>( currentValues, EqualityComparer<TValue>.Default );
        var matchedItems = Items.Where( i => valueSet.Contains( i.Value! ) ).ToList();

        SelectedItems.RemoveWhere( item => !matchedItems.Contains( item ) );
        SelectedItems.UnionWith( matchedItems );
    }
}
